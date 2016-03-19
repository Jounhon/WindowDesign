using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphics : IGraphics
    {
        Graphics _graphics;
        const int BORDER = 3;
        Pen _border = new Pen(Color.Red, BORDER);
        const int POSITION_X = 0;
        const int POSITION_Y = 1;
        const int WIDTH = 2;
        const int HEIGHT = 3;
        const int POSITION_OFFSET = 2;
        const int OFFSET = 3;
        const double LEFT_EYE_MARGIN_LEFT = 0.25;
        const double RIGHT_EYE_MARGIN_LEFT = 0.6;
        const double EYE_MARGIN_TOP = 0.3;
        const double EYE_SIZE = 0.15;
        const double SMILE_STROKE = 0.05;
        const double SMILE_WIDTH = 0.6;
        const double SMILE_HEIGHT = 0.4;
        const double SMILE_MARGIN_LEFT = 0.2;
        const double SMILE_MARGIN_TOP = 0.45;
        const int START_ANGLE = 10;
        const int END_ANGLE = 160;
        const int ALPHA = 3;
        const int BLUE = 2;
        
        public WindowsFormsGraphics(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //清除全部
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //畫圓
        public void DrawCircle(double[] data, int[] colors)
        {
            Color color = Color.FromArgb(colors[ALPHA], colors[0], colors[1], colors[BLUE]);
            SolidBrush brush = new SolidBrush(color);
            _graphics.FillEllipse(brush, new Rectangle((int)data[POSITION_X], (int)data[POSITION_Y], (int)data[WIDTH], (int)data[HEIGHT]));
        }

        //畫矩形
        public void DrawRectangle(double[] data, int[] colors)
        {
            Color color = Color.FromArgb(colors[ALPHA], colors[0], colors[1], colors[BLUE]);
            SolidBrush brush = new SolidBrush(color);
            _graphics.FillRectangle(brush, new Rectangle((int)data[POSITION_X], (int)data[POSITION_Y], (int)data[WIDTH], (int)data[HEIGHT]));
        }

        //畫笑臉
        public void DrawSmile(double[] data, int[] colors)
        {
            if (data[WIDTH] == 0 || data[HEIGHT] == 0)
                return;
            Color color = Color.FromArgb(colors[ALPHA], colors[0], colors[1], colors[BLUE]);
            SolidBrush brush = new SolidBrush(color);
            _graphics.FillEllipse(brush, new Rectangle((int)data[POSITION_X], (int)data[POSITION_Y], (int)data[WIDTH], (int)data[HEIGHT]));
            _graphics.FillEllipse(Brushes.Black, new Rectangle((int)(data[POSITION_X] + data[WIDTH] * LEFT_EYE_MARGIN_LEFT), (int)(data[POSITION_Y] + data[HEIGHT] * EYE_MARGIN_TOP), (int)(data[WIDTH] * EYE_SIZE), (int)(data[HEIGHT] * EYE_SIZE)));
            _graphics.FillEllipse(Brushes.Black, new Rectangle((int)(data[POSITION_X] + data[WIDTH] * RIGHT_EYE_MARGIN_LEFT), (int)(data[POSITION_Y] + data[HEIGHT] * EYE_MARGIN_TOP), (int)(data[WIDTH] * EYE_SIZE), (int)(data[HEIGHT] * EYE_SIZE)));
            Pen pen = new Pen(Color.Black, (float)(Math.Abs(data[WIDTH]) * SMILE_STROKE));
            int width = (int)(data[WIDTH] * SMILE_WIDTH);
            int height = (int)(data[HEIGHT] * SMILE_HEIGHT);
            if (width < 1) 
                width = 1;
            if (height < 1)
                height = 1;
            Rectangle rectangle = new Rectangle((int)(data[POSITION_X] + data[WIDTH] * SMILE_MARGIN_LEFT), (int)(data[POSITION_Y] + data[HEIGHT] * SMILE_MARGIN_TOP), width, height);
            _graphics.DrawArc(pen, rectangle, START_ANGLE, END_ANGLE);
        }

        //畫選擇框
        public void DrawSelectedBorder(double[] data)
        {
            _graphics.DrawRectangle(_border, (int)data[POSITION_X] - POSITION_OFFSET, (int)data[POSITION_Y] - POSITION_OFFSET, (int)data[WIDTH] + OFFSET, (int)data[HEIGHT] + OFFSET);
            _graphics.FillRectangle(Brushes.White, new Rectangle((int)data[POSITION_X] - POSITION_OFFSET, (int)data[POSITION_Y] - POSITION_OFFSET, BORDER, BORDER));
            _graphics.FillRectangle(Brushes.White, new Rectangle((int)data[POSITION_X] + (int)data[WIDTH], (int)data[POSITION_Y] - POSITION_OFFSET, BORDER, BORDER));
            _graphics.FillRectangle(Brushes.White, new Rectangle((int)data[POSITION_X] - POSITION_OFFSET, (int)data[POSITION_Y] + (int)data[HEIGHT] - 1, BORDER, BORDER));
            _graphics.FillRectangle(Brushes.White, new Rectangle((int)data[POSITION_X] + (int)data[WIDTH], (int)data[POSITION_Y] + (int)data[HEIGHT] - 1, BORDER, BORDER));

        }
    }
}
