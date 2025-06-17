from flask import Flask, request, jsonify
import paho.mqtt.client as mqtt
import json
import threading
import time
import requests

app = Flask(__name__)


BROKER = 'broker.mqttdashboard.com'
TOPIC_REQUEST = 'sensor/silo/request'
TOPIC_RESPONSE = 'sensor/silo'
API_DESTINO = 'http://localhost:5082/CreateData'  
mqtt_timeout = 10  


dados_recebidos = None
resposta_recebida_event = threading.Event()


def on_connect(client, userdata, flags, rc):
    print(f"MQTT conectado com código: {rc}")
    client.subscribe(TOPIC_RESPONSE)

def on_message(client, userdata, msg):
    global dados_recebidos
    if msg.topic == TOPIC_RESPONSE:
        dados_recebidos = json.loads(msg.payload.decode())
        print("Resposta recebida da ESP32:", dados_recebidos)
        resposta_recebida_event.set()

mqtt_client = mqtt.Client()
mqtt_client.on_connect = on_connect
mqtt_client.on_message = on_message
mqtt_client.connect(BROKER)
mqtt_thread = threading.Thread(target=mqtt_client.loop_forever)
mqtt_thread.start()


@app.route('/solicitar-dados', methods=['GET'])
def solicitar_dados():
    global dados_recebidos
    dados_recebidos = None
    resposta_recebida_event.clear()

    
    mqtt_client.publish(TOPIC_REQUEST, 'obter_dados')
    print("Solicitação enviada para ESP32 via MQTT")

    
    if resposta_recebida_event.wait(timeout=mqtt_timeout):
        
        try:
            r = requests.post(API_DESTINO, json=dados_recebidos)
            print("Enviado para API externa:", r.status_code)
        except Exception as e:
            return jsonify({"erro": "Falha ao enviar para API externa", "detalhes": str(e)}), 500

        return jsonify(dados_recebidos), 200
    else:
        return jsonify({"erro": "Tempo de resposta da ESP32 excedido"}), 504


if __name__ == '__main__':
    app.run(debug=True, port=5000)
