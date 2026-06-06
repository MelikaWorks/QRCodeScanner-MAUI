
# Android Run Guide

## Enable Developer Mode

1. Open Android Settings.
2. Go to About Phone.
3. Tap Build Number seven times.
4. Developer Options will be enabled.

## Enable USB Debugging

1. Open Settings.
2. Open Developer Options.
3. Enable USB Debugging.

## Connect Device

1. Connect the Android device using a USB cable.
2. Allow USB Debugging authorization on the phone.
3. Verify the device appears in Visual Studio.

## Run Application

1. Select the connected device.
2. Build the solution.
3. Deploy the application.
4. Launch the QR Scanner.

## Testing

Use the sample QR image included in:

```text
samples/sample-inventory-qr.png
```

Expected Result:

The application should successfully scan the QR code and generate a JSON payload.
