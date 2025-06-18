# SiloVisionX 🌾

**SiloVisionX** is an intelligent silo monitoring system designed for the **Gralha Azul Farm** as part of the *Creative Experience* course at **Pontifical Catholic University of Paraná (PUCPR)**.

This project integrates embedded systems, IoT communication, API development, and a full-stack web application to deliver real-time silo status visualization and alerts.

---

## 🔧 System Overview

The system is composed of:

- **Embedded Device:**  
  Built with **ESP32** and **MicroPython**, it includes:
  - DHT11 sensor for temperature and humidity
  - HC-SR04 ultrasonic sensor for silo level detection
  - Actuators: buzzer (auditory alert) and LEDs (visual alerts)

- **Data Communication:**  
  Utilizes **MQTT protocol** with the **Paho MQTT** library for communication between the embedded system and a lightweight **Flask-based Python API**.

- **Main Backend (C#/.NET):**  
  A strongly typed API developed in **C#**, following **Hexagonal Architecture**, with:
  - `API`, `Domain`, `Application`, and `Infrastructure` layers
  - **Entity Framework (EF Core)** for SQL Server database modeling and migrations
  - **AutoFac** for dependency injection

- **Frontend (Angular):**  
  Built with **Angular**, using:
  - **PrimeNG**, **PrimeIcons**, **Chart.js**, and **FontAwesome**
  - Email-based login system with **SMTP** token delivery

---

## 🚀 Getting Started

### 1. Embedded System Setup (ESP32 + MicroPython)

- Install **[Thonny](https://thonny.org/)** IDE
- Flash **MicroPython** to your ESP32
- Update the Wi-Fi credentials in the MicroPython script to match your network

### 2. Python API Setup (Secondary API)

```bash
pip install flask requests paho-mqtt
```

Run this API after the ESP32 is running.

### 3. C# API Setup (Primary API)

- Open the `SiloVisionX.sln` in Visual Studio
- Update the connection strings in `appsettings.json` inside `SiloVisionX.Api` project
- Generate migrations using Entity Framework:

```bash
Update-Database
```

- Run the C# API first.

### 4. Angular Frontend Setup

```bash
npm install --legacy-peer-deps
ng serve
```

> Make sure the C# API and Python API are running before starting the Angular app.

---

## 🛠️ Tech Stack

| Layer       | Technology                                       |
|-------------|--------------------------------------------------|
| Embedded    | ESP32, MicroPython, DHT11, HC-SR04               |
| API (IoT)   | Python, Flask, Paho MQTT                         |
| API (Main)  | C#, .NET 7, Entity Framework, AutoFac            |
| Database    | SQL Server                                       |
| Frontend    | Angular, PrimeNG, Chart.js, FontAwesome, SMTP    |

---

## 📸 Screenshots

> _(Include images or GIFs of the UI and system in action if possible)_

---

## 📚 License

This project was developed for academic purposes at PUCPR and is open for educational and improvement contributions.

---

## ✉️ Contact

**João Guilherme Machado Palma**  
Email: [joaoguilhermempdev@gmail.com](mailto:joaoguilhermempdev@gmail.com)

---
