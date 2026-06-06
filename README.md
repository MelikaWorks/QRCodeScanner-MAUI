# QRCodeScanner-MAUI

<p align="center">
  <img src="images/app_icon.jpg" width="180">
</p>

A cross-platform QR Code Scanner built with .NET MAUI.

This project was initially developed as a web-based Proof of Concept (PoC) to validate the QR processing workflow and inventory data structure. After successful validation, the solution was migrated to a .NET MAUI Android application to provide real-time QR scanning capabilities on mobile devices.

---

## Project Overview

The application scans QR codes using the device camera and generates structured JSON payloads that can be consumed by inventory, warehouse, or ERP systems.

Current version focuses on:

- QR Code Scanning
- Camera Integration
- JSON Payload Generation
- Android Device Deployment
- Real Device Testing

Future versions may include:

- ERP Integration
- Warehouse Management System (WMS) Integration
- REST API Connectivity
- Authentication & Authorization
- Online Synchronization

---

## Technology Stack

- .NET MAUI
- C#
- Android
- ZXing.Net.Maui
- JSON Serialization

---

## Project Evolution

### Phase 1 – Web Prototype

A web-based prototype was developed to:

- Validate the QR workflow
- Test payload structure
- Verify inventory-related data models

### Phase 2 – Mobile Application

The project was migrated to .NET MAUI to:

- Enable real-time camera scanning
- Support Android deployment
- Improve usability in warehouse environments

---

## Screenshots

### Application Installed

![Installed App](images/app_icon.jpg)

### Main Screen

![Main Screen](images/main_screen.jpg)

### Successful QR Scan

![QR Scan Result](images/qr_scan_success.jpg)

---

## Sample QR Payload

```json
{
  "PartCode": "P1001",
  "BatchNo": "B20260606",
  "Location": "WH-A1"
}
```

Sample files are available in:

```text
samples/
```

---

## Running the Project

1. Clone the repository

```bash
git clone https://github.com/your-username/QRCodeScanner-MAUI.git
```

2. Open the solution in Visual Studio 2022

3. Restore NuGet packages

4. Connect an Android device or start an emulator

5. Build and run the application

Additional documentation can be found in:

```text
docs/
```

---

## Security Notice

This repository contains only the public demonstration version of the project.

The following items are intentionally excluded:

- ERP/WMS Integration Details
- API Endpoints
- Authentication Credentials
- Database Connections
- Internal Business Logic
- Production Configuration

All sample data included in this repository is fictional and used only for demonstration purposes.

---

---

## Author

👩‍💻 **Melika Mehranpour**

Senior Software Engineer | .NET Developer | Enterprise Applications

**Technologies**

C# • .NET • ASP.NET Core • SQL Server • PostgreSQL • Power BI • Python • MAUI

### Connect with me

- GitHub: (https://github.com/MelikaWorks)
- LinkedIn: [(https://www.linkedin.com/in/melika-mehranpour-41b627161/)]

---

## License

See the LICENSE file for license information.
