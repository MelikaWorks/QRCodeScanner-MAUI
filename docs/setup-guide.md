# Setup Guide

## Prerequisites

Before running the application, make sure the following tools are installed:

- Visual Studio 2022
- .NET MAUI Workload
- Android SDK
- Android Emulator (optional)
- Physical Android Device (recommended)

## Required NuGet Packages

- ZXing.Net.Maui

## Build Steps

1. Clone the repository.

```bash
git clone https://github.com/your-username/QRCodeScanner-MAUI.git
```

2. Open the solution in Visual Studio 2022.

3. Restore NuGet packages.

4. Select Android as the startup target.

5. Build the project.

6. Run the application on a physical Android device or emulator.

## Verification

After launching the application:

- Grant Camera Permission.
- Open the QR Scanner page.
- Scan the sample QR code located in the samples folder.
- Verify that JSON payload information is displayed successfully.
