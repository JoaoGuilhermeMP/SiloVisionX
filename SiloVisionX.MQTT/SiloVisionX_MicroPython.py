import dht
from machine import Pin, time_pulse_us, PWM
import network
import time
from umqtt.simple import MQTTClient
import machine
import json

SSID = 'Visitantes'
PASSWORD = ''

MQTT_BROKER = 'broker.mqttdashboard.com' 
MQTT_TOPIC = 'sensor/silo'
CLIENT_ID = "esp32_silo"  

def conecta_wifi():
    wifi = network.WLAN(network.STA_IF)
    wifi.active(True)
    if not wifi.isconnected():
        print('Conectando ao WiFi...')
        wifi.connect(SSID, PASSWORD)
        while not wifi.isconnected():
            time.sleep(1)
    print('WiFi conectado:', wifi.ifconfig())


conecta_wifi()

led1 = Pin(13, Pin.OUT)
led2 = Pin(2, Pin.OUT)
led3 = Pin(23, Pin.OUT)
buzzer = PWM(Pin(25), freq=2000, duty=0)
sensor = dht.DHT11(Pin(21))
TRIG = Pin(5, Pin.OUT)
ECHO = Pin(15, Pin.IN)
ALTURA_SILO = 400

mqtt_client = MQTTClient(CLIENT_ID, MQTT_BROKER)
mqtt_client.connect()
def medir_distancia():
    max_tentativas = 3
    for tentativa in range(max_tentativas):
        TRIG.off()
        time.sleep_us(2)
        TRIG.on()
        time.sleep_us(10)
        TRIG.off()
        
        try:
            duracao = time_pulse_us(ECHO, 1, 50000)  
            if duracao <= 0:
                print(f"Tentativa {tentativa+1}: Falha na leitura (duração inválida)")
                continue
            distancia = (duracao / 2) / 58
            return distancia
        except Exception as e:
            print(f"Tentativa {tentativa+1}: Erro ao medir distância: {e}")
            continue

    print("Erro persistente na medição! Retornando altura máxima do silo.")
    return ALTURA_SILO

def checkWeather():
    sensor.measure()
    return sensor.temperature(), sensor.humidity()

def checkNivel():
    distancia = medir_distancia()
    print("Distância bruta medida (cm):", distancia)
    return ALTURA_SILO - distancia

def controleSistema(temp, humidity, nivel):
    led1.value(0)
    led2.value(0)
    led3.value(0)


    erro = False
    
    if erro != "fatal":
        buzzer.duty(0)

    if (12 <= temp <= 18) and (55 <= humidity <= 65):
        pass
    elif (18 < temp <= 25) or (temp < 12) or (50 <= humidity < 55) or (65 < humidity <= 70):
        erro = "warning"
    else:
        erro = "fatal"

    if nivel >= 380:
        erro = "fatal"
    elif 300 <= nivel < 380:
        if erro != "fatal":
            erro = "warning"
    else:
        if erro is False:
            erro = False
    

    if erro == "fatal":
        led2.value(1)
        buzzer.freq(2000)
        buzzer.duty(512)
    elif erro == "warning":
        led3.value(1)
    else:
        led1.value(1)

    return erro

while True:
    temperatura, umidade = checkWeather()
    print("Temperatura: ",temperatura, "Umidade:", umidade)
    nivel_silo = checkNivel()
    print("Nivel do silo", nivel_silo)
    status = controleSistema(temperatura, umidade, nivel_silo)

    dados = {
        "temperatura": temperatura,
        "umidade": umidade,
        "nivel_silo": nivel_silo,
        "status": status
    }

    mqtt_client.publish(MQTT_TOPIC, json.dumps(dados))
    print("Dados enviados:", dados)
    time.sleep(2)
