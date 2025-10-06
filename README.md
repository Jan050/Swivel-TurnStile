# 🎫 Swivel Gate Turnstile System

A **smart RFID-based gate access system** designed to automate entry and exit monitoring for students using **ESP32**, **Wiegand RFID readers**, and a **VB.NET desktop application**.  
This project enables real-time logging, secure gate control, and database integration for efficient access management within a school campus.

![System Screenshot](d7b76f0a-6d58-4bef-b131-8f7f616c09d4.png)

---

## 📘 Overview

The **Swivel Gate Turnstile System** is a network-based access control solution developed for **Caraga State University, Philippines**.  
Students scan their RFID cards at the turnstile gate, and the ESP32 (configured as a TCP client) communicates with a PC-based server application built in **VB.NET**.  
The system logs entry/exit events into a **SQL Server database** and provides an intuitive admin dashboard for managing users, attendance, and gate control.

---

## 🛠️ Technologies Used

- **VB.NET** – for the server application (TCP server, dashboard, database integration)
- **ESP32** – handles RFID scanning, Wi-Fi communication, and relay control
- **Wiegand RFID Reader** – reads RFID student cards
- **SQL Server** – stores user and attendance data
- **Relay Modules** – control turnstile lock mechanisms

---

## ⚙️ System Architecture

**ESP32 (Client)**  
- Connects to Wi-Fi and sends scanned RFID data via TCP  
- Controls turnstile relays for IN/OUT operations  
- Supports admin card for system override  

**PC (Server Application)**  
- Listens for RFID scans via TCP  
- Logs entry and exit times to SQL Server  
- Displays student information and gate activity in real time  
- Provides a user-friendly interface for management and monitoring  

---

## 🚀 Features

✅ RFID-based entry and exit  
✅ Dual-gate (IN/OUT) control  
✅ Real-time monitoring and data logging  
✅ Admin control card for system override  
✅ Attendance and user account management  
✅ Local SQL Server integration  
✅ Secure TCP communication between ESP32 and PC  

---

## 🖥️ How to Run

### 🧩 Requirements
- Visual Studio (VB.NET)
- SQL Server or SQL Server Express
- ESP32 board
- Wiegand-compatible RFID reader
- Relay module
- Wi-Fi network connection

### ⚡ Setup Steps
1. **Import the VB.NET project** into Visual Studio.  
2. **Configure SQL Server** connection string in the app’s configuration file.  
3. **Upload the ESP32 firmware** (Arduino IDE or PlatformIO) with your Wi-Fi SSID, password, and TCP server IP (your PC’s local IP).  
4. **Run the VB.NET server app** — it will listen for RFID data from the ESP32.  
5. Scan an RFID card — watch as the gate unlocks and the event logs appear on screen!

---

## 📂 Project Structure

