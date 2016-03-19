using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingApp.GoogleDriveForApp;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using Windows.Graphics.Display;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Popups;

namespace DrawingApp.PresentationModel
{
    class PresentationModel
    {
        Model _model;
        IGraphics _graphics;
        Canvas _canvas;
        StorageFolder _storagePath = ApplicationData.Current.LocalFolder;
        const string APPLICATION_NAME = "DrawAnywhereApp";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
        const string DATA_FILE_NAME = "ImageData.txt";
        const string IMAGE_FILE_NAME = "image.png";
        const string DIRECTORY_TYPE = @"application/vnd.google-apps.folder";
        const string COMMA = ",";
        const string WRAP = "\n";
        GoogleDriveServiceForApp _service;
        const int RED = 5;
        const int GREEN = 6;
        const int BLUE = 7;
        const int ALPHA = 8;
        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            this._canvas = canvas;
            _graphics = new WindowsStoreGraphics(canvas);
            this.PrepareService();
        }

        // 畫圓
        public void Draw()
        {
            // 重複使用graphics物件
            _model.Draw(_graphics);
        }

        // prepare service
        public void PrepareService()
        {
            _service = new GoogleDriveServiceForApp(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
            GetFileFromDrive();
        }

        // generate image & data file
        public async void GenerateImageDataFile()
        {
            await SaveImageData();
            await SaveImage();
            await SaveFileToDrive();
        }

        // save image data

        async Task SaveImageData()
        {
            const int TWO = 2;
            const int THIRD = 3;
            String content = "";
            StorageFile dataFile = await _storagePath.CreateFileAsync(DATA_FILE_NAME, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            foreach (Shape step in _model.GetShapes)
            {
                content += step.GetType().ToString() + COMMA + step.PositionX + COMMA + step.PositionY + COMMA + step.Width + COMMA + step.Height + COMMA + step.Color[0] + COMMA + step.Color[1] + COMMA + step.Color[TWO] + COMMA + step.Color[THIRD] + WRAP;
            }
            await FileIO.WriteTextAsync(dataFile, content);
        }

        // save image
        async Task SaveImage()
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(_canvas);
            IBuffer pictureElement = await bitmap.GetPixelsAsync();
            StorageFile file = await _storagePath.CreateFileAsync(IMAGE_FILE_NAME, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight, DisplayInformation.GetForCurrentView().LogicalDpi, DisplayInformation.GetForCurrentView().LogicalDpi, pictureElement.ToArray());
                await encoder.FlushAsync();
            }
        }

        // upload file to google drive
        public async Task SaveFileToDrive()
        {
            const string IMAGE_TYPE = "image/jpeg";
            const string TEXT_TYPE = "Text/plain";
            await _service.UploadFile(DATA_FILE_NAME, TEXT_TYPE);
            await _service.UploadFile(IMAGE_FILE_NAME, IMAGE_TYPE);
        }

        // download file to solve data file
        public async void GetFileFromDrive()
        {
            const int TIME = 500;
            await Task.Delay(TIME);
            List<Google.Apis.Drive.v2.Data.File> rootFiles = _service.ListRootFileAndFolder();
            rootFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == DIRECTORY_TYPE;
            });
            foreach (Google.Apis.Drive.v2.Data.File item in rootFiles)
            {
                if (item.OriginalFilename != null && item.OriginalFilename.Equals(DATA_FILE_NAME))
                {
                    _service.DownloadFile(item);
                    await Task.Delay(TIME + TIME);
                    AnalyzeDataFile();
                    break;
                }
            }
        }

        // analyze data file to paint
        public async void AnalyzeDataFile()
        {
            const int POSITION_X = 1;
            const int POSITION_Y = 2;
            const int WIDTH = 3;
            const int HEIGHT = 4;
            StorageFile dataFile = await _storagePath.GetFileAsync(DATA_FILE_NAME);
            String content = await FileIO.ReadTextAsync(dataFile);
            string[] lines = content.Split(WRAP.ToCharArray()[0]);
            foreach (string line in lines)
            {
                if (line.Equals(""))
                    continue;
                string[] attribute = line.Split(COMMA.ToCharArray()[0]);
                double[] data = { Convert.ToDouble(attribute[POSITION_X]), Convert.ToDouble(attribute[POSITION_Y]), Convert.ToDouble(attribute[WIDTH]), Convert.ToDouble(attribute[HEIGHT]) };
                int[] colors = { Convert.ToInt32(attribute[RED]), Convert.ToInt32(attribute[GREEN]), Convert.ToInt32(attribute[BLUE]), Convert.ToInt32(attribute[ALPHA]) };
                _model.AddDataShape(attribute[0], data, colors);
            }
            Draw();
        }
    }
}
