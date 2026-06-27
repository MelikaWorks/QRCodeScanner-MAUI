using ZXing.Net.Maui;
using Android.Content;
using Android.Provider;

namespace QRCodeScanner;

public partial class MainPage : ContentPage
{
    private bool _isScanning = true;

    private readonly List<string> _scannedItems = new();

    // جلوگیری از ثبت QR تکراری
    private readonly HashSet<string> _uniqueItems = new();

    public MainPage()
    {
        InitializeComponent();

        barcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false,
            TryHarder = true
        };
    }

    private void BarcodesDetected(
        object sender,
        BarcodeDetectionEventArgs e)
    {
        if (!_isScanning)
            return;

        var value = e.Results?.FirstOrDefault()?.Value?.Trim();

        if (string.IsNullOrWhiteSpace(value))
            return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (_uniqueItems.Add(value))
            {
                _scannedItems.Add(value);

                resultLabel.Text = value;
                statusLabel.Text = "ثبت شد؛ کویل بعدی";
                countLabel.Text = $"تعداد ثبت شده: {_scannedItems.Count}";

                try
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                }
                catch 
                {
                    
                }
            }
        });
    }

    private async void StopButton_Clicked(
    object sender,
    EventArgs e)
    {
        var button = (Button)sender;
        button.IsEnabled = false;
        _isScanning = false;

        try
        {

            if (_scannedItems.Count == 0)
            {
                await DisplayAlert(
                    "توجه",
                    "هیچ QR کدی ثبت نشده است.",
                    "باشه");               

                return;
            }

            var fileName =
                $"QRScans_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            var fileContent =
                string.Join(Environment.NewLine, _scannedItems);

            // مسیر موقت برای Share
            var shareFilePath =
                Path.Combine(FileSystem.CacheDirectory, fileName);

            await File.WriteAllTextAsync(
                shareFilePath,
                fileContent);

#if ANDROID

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                var resolver =
                    Android.App.Application.Context.ContentResolver;

                var values = new ContentValues();

                values.Put(
                    MediaStore.IMediaColumns.DisplayName,
                    fileName);

                values.Put(
                    MediaStore.IMediaColumns.MimeType,
                    "text/plain");

                values.Put(
                    MediaStore.IMediaColumns.RelativePath,
                    Android.OS.Environment.DirectoryDownloads + "/QRScans");

                var uri = resolver.Insert(
                    MediaStore.Downloads.ExternalContentUri,
                    values);

                if (uri != null)
                {
                    using var stream =
                        resolver.OpenOutputStream(uri);

                    using var writer =
                        new StreamWriter(stream!);

                    await writer.WriteAsync(fileContent);
                }
            }
            else
            {
                // Android زیر 10
                var downloadsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryDownloads)!.AbsolutePath;

                var folder = Path.Combine(downloadsPath, "QRScans");
                Directory.CreateDirectory(folder);

                var destPath = Path.Combine(folder, fileName);
                await File.WriteAllTextAsync(destPath, fileContent);
            }
#endif

            statusLabel.Text =
                "✅ فایل ذخیره شد";

            await DisplayAlert(
                "ذخیره شد",
                $"فایل در Download/QRScans ذخیره شد.\n\nنام فایل:\n{fileName}",
                "باشه");

            // Share فایل
            await Share.Default.RequestAsync(
                new ShareFileRequest
                {
                    Title = "ارسال فایل اسکن‌ها",
                    File = new ShareFile(shareFilePath)
                });
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطا", $"مشکلی پیش آمد:\n{ex.Message}", "باشه");

        }
        finally
        {
            // ریست برنامه
            _scannedItems.Clear();
            _uniqueItems.Clear();

            _isScanning = true;

            resultLabel.Text = "-";
            statusLabel.Text = "آماده اسکن";
            countLabel.Text = "تعداد ثبت شده: 0";
            button.IsEnabled = true;
        }       
    }
}