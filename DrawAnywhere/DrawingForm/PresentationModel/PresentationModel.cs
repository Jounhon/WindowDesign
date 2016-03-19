using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        string _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        const string DATA_FILE_NAME = "\\ImageData.txt";
        const string IMAGE_FILE_NAME = "\\image.png";
        const string APPLICATION_NAME = "DrawAnywhereForm";
        const string CLIENT_SECRET_FILE_NAME = "\\clientSecret.json";
        const string DIRECTORY_TYPE = @"application/vnd.google-apps.folder";
        const string DATA_FILE = "ImageData.txt";
        GoogleDriveService _service;
        const int RED = 5;
        const int GREEN = 6;
        const int BLUE = 7;
        const int ALPHA = 8;

        public PresentationModel(Model model)
        {
            this._model = model;
        }

        // graphics物件是Paint事件帶進來的，只能在當次Paint使用
        // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
        // 因此，Adaptor不能重複使用，每次都要重新new
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new WindowsFormsGraphics(graphics));
        }

        // prepare service
        private void PrepareService()
        {
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        // generate image & data file
        public void GenerateImageDataFile(int width, int height)
        {
            PrepareService();
            SaveImageDate();
            SaveImage(width, height);
            SaveFileToDrive();
        }

        //save image data
        void SaveImageDate()
        {
            const string COMMA = ",";
            const int TWO = 2;
            const int THIRD = 3;
            using (FileStream createFile = new FileStream(_projectPath + DATA_FILE_NAME, FileMode.OpenOrCreate, FileAccess.Write))
                createFile.Close();
            using (FileStream file = new FileStream(_projectPath + DATA_FILE_NAME, FileMode.Truncate, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Shape step in _model.GetShapes)
                {
                    writer.WriteLine(step.GetType().ToString() + COMMA + step.PositionX + COMMA + step.PositionY + COMMA + step.Width + COMMA + step.Height + COMMA + step.Color[0] + COMMA + step.Color[1] + COMMA + step.Color[TWO] + COMMA + step.Color[THIRD]);
                }
            }
        }

        // save image
        void SaveImage(int width, int height)
        {
            if (_model.GetShapes.Count.Equals(0))
                return;
            Image png = new Bitmap((int)width, (int)height);
            using (Graphics graphic = Graphics.FromImage(png))
            {
                graphic.FillRectangle(Brushes.White, new Rectangle(0, 0, (int)width, (int)height));
                _model.Draw(new WindowsFormsGraphics(graphic));
                png.Save(_projectPath + IMAGE_FILE_NAME);
            }
        }

        // upload file to google drive
        private void SaveFileToDrive()
        {
            PrepareService();
            const string IMAGE_TYPE = "image/jpeg";
            const string TEXT_TYPE = "Text/plain";
            _service.UploadFile(_projectPath + DATA_FILE_NAME, TEXT_TYPE);
            _service.UploadFile(_projectPath + IMAGE_FILE_NAME, IMAGE_TYPE);
        }

        // download file to solve data file
        public void GetFileFromDrive(System.Drawing.Graphics graphics)
        {
            PrepareService();
            List<Google.Apis.Drive.v2.Data.File> rootFiles = _service.ListRootFileAndFolder();
            rootFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == DIRECTORY_TYPE;
            });
            foreach (Google.Apis.Drive.v2.Data.File item in rootFiles)
            {
                if (item.OriginalFilename != null && item.OriginalFilename.Equals(DATA_FILE))
                {
                    _service.DownloadFile(item, _projectPath);
                    AnalyzeDataFile();
                    Draw(graphics);
                    break;
                }
            }
        }

        // analyze data file to paint
        private void AnalyzeDataFile()
        {
            StreamReader file = new StreamReader(_projectPath + DATA_FILE_NAME);
            string step;
            const char COMMA = ',';
            const int SHAPE = 0;
            const int POSITION_X = 1;
            const int POSITION_Y = 2;
            const int WIDTH = 3;
            const int HEIGHT = 4;
            while ((step = file.ReadLine()) != null)
            {
                string[] attribute = step.Split(COMMA);
                double[] data = { Convert.ToDouble(attribute[POSITION_X]), Convert.ToDouble(attribute[POSITION_Y]), Convert.ToDouble(attribute[WIDTH]), Convert.ToDouble(attribute[HEIGHT]) };
                int[] colors = { Convert.ToInt32(attribute[RED]), Convert.ToInt32(attribute[GREEN]), Convert.ToInt32(attribute[BLUE]), Convert.ToInt32(attribute[ALPHA]) };
                _model.AddDataShape(attribute[SHAPE], data, colors);
            }
            file.Close();
        }
    }
}
