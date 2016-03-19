using DrawingModel;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphics : IGraphics
    {
        Canvas _canvas;
        SolidColorBrush _color = new SolidColorBrush(Colors.Red);
        const int POSITION_X = 0;
        const int POSITION_Y = 1;
        const int WIDTH = 2;
        const int HEIGHT = 3;
        const int BORDER = 3;
        const int POSITION_OFFSET = 4;
        const int OFFSET = 8;
        const double LEFT_EYE_MARGIN_LEFT = 0.25;
        const double RIGHT_EYE_MARGIN_LEFT = 0.6;
        const double EYE_MARGIN_TOP = 0.3;
        const double EYE_SIZE = 0.15;
        const double SMILE_SIZE = 0.5;
        const double SMILE_MARGIN_LEFT = 0.8;
        const double SMILE_MARGIN_TOP = 0.7;
        const double START_ANGLE = 0.2;
        const double END_ANGLE = 0.7;
        const double SMILE_STROKE = 0.05;
        const int ALPHA = 3;
        const int BLUE = 2;

        public WindowsStoreGraphics(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // 清除全部
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // 畫圓
        public void DrawCircle(double[] data, int[] colors)
        {
            Color color = Color.FromArgb((byte)colors[ALPHA], (byte)colors[0], (byte)colors[1], (byte)colors[BLUE]);
            Ellipse circle = new Ellipse();
            circle.Margin = new Thickness(data[POSITION_X], data[POSITION_Y], data[WIDTH], data[HEIGHT]);
            circle.Width = Math.Abs(data[WIDTH]);
            circle.Height = Math.Abs(data[HEIGHT]);
            circle.Fill = new SolidColorBrush(color);
            _canvas.Children.Add(circle);
        }
        
        //畫矩形
        public void DrawRectangle(double[] data, int[] colors)
        {
            Color color = Color.FromArgb((byte)colors[ALPHA], (byte)colors[0], (byte)colors[1], (byte)colors[BLUE]);
            Rectangle rectangle = new Rectangle();
            rectangle.Width = Math.Abs(data[WIDTH]);
            rectangle.Height = Math.Abs(data[HEIGHT]);
            rectangle.Fill = new SolidColorBrush(color);
            rectangle.SetValue(Canvas.LeftProperty, data[POSITION_X]);
            rectangle.SetValue(Canvas.TopProperty, data[POSITION_Y]);
            _canvas.Children.Add(rectangle);
        }

        //畫笑臉
        public void DrawSmile(double[] data, int[] colors)
        {
            Color color = Color.FromArgb((byte)colors[ALPHA], (byte)colors[0], (byte)colors[1], (byte)colors[BLUE]);
            data[WIDTH] = Math.Abs(data[WIDTH]);
            data[HEIGHT] = Math.Abs(data[HEIGHT]);
            Ellipse circle = new Ellipse();
            circle.Margin = new Thickness(data[POSITION_X], data[POSITION_Y], data[WIDTH], data[HEIGHT]);
            circle.Width = data[WIDTH];
            circle.Height = data[HEIGHT];
            circle.Fill = new SolidColorBrush(color);
            _canvas.Children.Add(circle);

            DrawEye(data);
            DrawArc(data);
        }

        // 畫眼睛
        void DrawEye(double[] data)
        {
            Ellipse circle = new Ellipse();
            circle.Margin = new Thickness(data[POSITION_X] + data[WIDTH] * LEFT_EYE_MARGIN_LEFT, data[POSITION_Y] + data[HEIGHT] * EYE_MARGIN_TOP, data[WIDTH], data[HEIGHT]);
            circle.Width = data[WIDTH] * EYE_SIZE;
            circle.Height = data[HEIGHT] * EYE_SIZE;
            circle.Fill = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(circle);

            circle = new Ellipse();
            circle.Margin = new Thickness(data[POSITION_X] + data[WIDTH] * RIGHT_EYE_MARGIN_LEFT, data[POSITION_Y] + data[HEIGHT] * EYE_MARGIN_TOP, data[WIDTH], data[HEIGHT]);
            circle.Width = data[WIDTH] * EYE_SIZE;
            circle.Height = data[HEIGHT] * EYE_SIZE;
            circle.Fill = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(circle);
        }

        //畫嘴巴
        void DrawArc(double[] data)
        {
            double size = data[WIDTH] * SMILE_SIZE;
            ArcSegment arc = new ArcSegment();
            arc.SweepDirection = SweepDirection.Counterclockwise;
            arc.Size = new Size(size, size);
            arc.IsLargeArc = false;
            arc.Point = new Point(data[POSITION_X] + data[WIDTH] * SMILE_MARGIN_LEFT, data[POSITION_Y] + data[HEIGHT] * SMILE_MARGIN_TOP);
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(data[POSITION_X] + data[WIDTH] * START_ANGLE, data[POSITION_Y] + data[HEIGHT] * END_ANGLE);
            PathSegmentCollection segmentCollection = new PathSegmentCollection();
            segmentCollection.Add(arc);
            pathFigure.Segments = segmentCollection;
            PathFigureCollection figures = new PathFigureCollection();
            figures.Add(pathFigure);
            PathGeometry geometry = new PathGeometry();
            geometry.Figures = figures;
            Path arcPath = new Path();
            arcPath.Stroke = new SolidColorBrush(Colors.Black);
            arcPath.StrokeThickness = data[WIDTH] * SMILE_STROKE;
            arcPath.Data = geometry;
            _canvas.Children.Add(arcPath);
        }

        //畫選擇框
        public void DrawSelectedBorder(double[] data)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = Math.Abs(data[WIDTH] + OFFSET);
            rectangle.Height = Math.Abs(data[HEIGHT] + OFFSET);
            rectangle.SetValue(Canvas.LeftProperty, data[POSITION_X] - POSITION_OFFSET);
            rectangle.SetValue(Canvas.TopProperty, data[POSITION_Y] - POSITION_OFFSET);
            rectangle.Stroke = _color;
            rectangle.StrokeThickness = BORDER;
            _canvas.Children.Add(rectangle);
            AddAnchor(data[POSITION_X] - POSITION_OFFSET, data[POSITION_Y] - POSITION_OFFSET); // left-top
            AddAnchor(data[POSITION_X] + data[WIDTH], data[POSITION_Y] - POSITION_OFFSET); // right-top
            AddAnchor(data[POSITION_X] - POSITION_OFFSET, data[POSITION_Y] + data[HEIGHT]); // left-bottom
            AddAnchor(data[POSITION_X] + data[WIDTH], data[POSITION_Y] + data[HEIGHT]); // right-bottom
        }

        // add anchor
        void AddAnchor(double positionX, double positionY)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = Math.Abs(BORDER - 1);
            rectangle.Height = Math.Abs(BORDER - 1);
            rectangle.SetValue(Canvas.LeftProperty, positionX);
            rectangle.SetValue(Canvas.TopProperty, positionY);
            rectangle.Stroke = new SolidColorBrush(Colors.White);
            rectangle.StrokeThickness = BORDER;
            _canvas.Children.Add(rectangle);
        }
    }
}
