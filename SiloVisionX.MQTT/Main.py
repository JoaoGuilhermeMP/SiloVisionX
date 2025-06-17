from flask import Flask, jsonify
import paho.mqtt.client as mqtt
import json
import threading
import requests
import time

app = Flask(__name__)

BROKER = 'broker.mqttdashboard.com'
TOPIC_REQUEST = 'sensor/silo/request'
TOPIC_RESPONSE = 'sensor/silo'
API_DESTINO = 'http://localhost:5082/api/Dashboard/CreateData'  
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

        
        try:
            response = requests.post(API_DESTINO, json=dados_recebidos)
            print(f"Enviado para API C#: {response.status_code} - {response.text}")
        except Exception as e:
            print(f"Erro ao enviar para API: {str(e)}")

        resposta_recebida_event.set()

mqtt_client = mqtt.Client()
mqtt_client.on_connect = on_connect
mqtt_client.on_message = on_message
mqtt_client.connect(BROKER)
mqtt_thread = threading.Thread(target=mqtt_client.loop_forever)
mqtt_thread.start()


def loop_solicitacao_automatica():
    while True:
        mqtt_client.publish(TOPIC_REQUEST, 'obter_dados')
        print("Solicitação automática enviada via MQTT.")
        time.sleep(10)


solicitacao_thread = threading.Thread(target=loop_solicitacao_automatica)
solicitacao_thread.daemon = True
solicitacao_thread.start()


@app.route('/solicitar-dados', methods=['GET'])
def solicitar_dados():
    global dados_recebidos
    dados_recebidos = None
    resposta_recebida_event.clear()

    mqtt_client.publish(TOPIC_REQUEST, 'obter_dados')
    print("Solicitação manual enviada via MQTT")

    if resposta_recebida_event.wait(timeout=mqtt_timeout):
        return jsonify(dados_recebidos), 200
    else:
        return jsonify({"erro": "Tempo de resposta da ESP32 excedido"}), 504

if __name__ == '__main__':
    app.run(debug=True, port=5000)
