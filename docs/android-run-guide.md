# Android Run Guide

## Overview

The Android application is the second phase of the project.

Phase 1:
- Web-based prototype
- QR workflow validation
- Payload structure validation

Phase 2:
- .NET MAUI Android application
- Real-time camera scanning
- Mobile deployment and testing

## Enable Developer Mode

1. Open Android Settings.
2. Go to About Phone.
3. Tap Build Number seven times.

## Enable USB Debugging

1. Open Developer Options.
2. Enable USB Debugging.

## Connect Device

1. Connect the device using a USB cable.
2. Accept the debugging authorization prompt.
3. Verify that the device appears in Visual Studio.

## Run Application

1. Select the connected device.
2. Build the solution.
3. Deploy the application.
4. Launch the QR Scanner.

## Testing

Sample QR Code:

```text
samples/sample-inventory-qr.png
```

Expected Output:

A structured JSON payload containing inventory-related information.
