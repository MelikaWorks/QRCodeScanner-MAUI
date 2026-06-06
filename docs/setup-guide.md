# Setup Guide

## Project Background

This project was initially developed as a web-based proof of concept (PoC) to validate the QR code processing workflow and data structure.

After successful validation of the business requirements and scanning workflow, the solution was migrated to a .NET MAUI Android application to provide real-time QR scanning capabilities on mobile devices.

## Prerequisites

Before running the application, make sure the following tools are installed:

- Visual Studio 2022
- .NET MAUI Workload
- Android SDK
- Physical Android Device (recommended)

## Required NuGet Packages

- ZXing.Net.Maui

## Build Steps

1. Clone the repository.
2. Open the solution in Visual Studio 2022.
3. Restore NuGet packages.
4. Select Android as the startup target.
5. Build and run the application.

## Verification

After launching the application:

- Grant camera permission.
- Open the scanner page.
- Scan the sample QR code located in the samples folder.
- Verify that a JSON payload is generated successfully.
