using ZXing.Net.Maui;
using System.Text.Json;

namespace QRCodeScanner;

public partial class MainPage : ContentPage
{
    private bool _isScanning = true;

    public MainPage()
    {
        InitializeComponent();

        barcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false
        };
    }

    public class QRScanRequest
    {
        public string QrValue { get; set; } = string.Empty;
        public DateTime ScannedAt { get; set; }
        public string DeviceName { get; set; } = string.Empty;
        public string AppName { get; set; } = string.Empty;
    }

    private void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        if (!_isScanning)
            return;

        var first = e.Results?.FirstOrDefault();

        if (first is null || string.IsNullOrWhiteSpace(first.Value))
            return;

        _isScanning = false;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var decodedText = first.Value;

            var request = new QRScanRequest
            {
                QrValue = decodedText,
                ScannedAt = DateTime.Now,
                DeviceName = DeviceInfo.Name,
                AppName = AppInfo.Name
            };

            var json = JsonSerializer.Serialize(request);

            resultLabel.Text = decodedText;

            await DisplayAlert(
                "QR Code خوانده شد",
                $"متن QR:\n{decodedText}\n\nPayload آماده ارسال:\n{json}",
                "OK");

            _isScanning = true;
        });
    }
}