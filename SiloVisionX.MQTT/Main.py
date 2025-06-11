import paho.mqtt.client as mqtt
import json


BROKER = 'broker.mqttdashboard.com' 

TOPIC = 'sensor/silo'

def on_connect(client, userdata, flags, rc):
    print(f"Conectado com o código {rc}")
    client.subscribe(TOPIC)

def on_message(client, userdata, msg):
    payload = msg.payload.decode()
    dados = json.loads(payload)
    print(f"Dados recebidos: {dados} \n")

client = mqtt.Client()
client.on_connect = on_connect
client.on_message = on_message

client.connect(BROKER)
client.loop_forever()
