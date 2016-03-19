using DrawingModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        ButtonControl _buttonControl;
        const string CIRCLE_TYPE = "DrawingModel.Circles";
        const string RECTANGLE_TYPE = "DrawingModel.Rectangles";
        const string SMILE_TYPE = "DrawingModel.Smiles";
        const int ALPHA = 3;
        const int BLUE = 2;
        const int MAX = 255;
        int[] _colors = { 120, 217, 237, MAX };
        public MainPage()
        {
            this.InitializeComponent();
            _model = new Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _buttonControl = new ButtonControl();
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;

            _circleButton.Click += HandleCircleButtonClick;
            _rectangleButton.Click += HandleRectangleButtonClick;
            _smileButton.Click += HandleSmileButtonClick;
            _undoButton.Click += HandleUndoButtonClick;
            _redoButton.Click += HandleRedoButtonClick;
            _deleteButton.Click += HandleDeleteButtonClick;
            _clearButton.Click += HandleClearButtonClick;
            _saveButton.Click += HandleSaveButtonClick;
            _colorButton.Click += HandleChangeColorButtonClick;
            _exitButton.Click += HandleExitButtonClick;
            _model._modelChanged += HandleModelChanged;

            Color color = Color.FromArgb((byte)_colors[ALPHA], (byte)_colors[0], (byte)_colors[1], (byte)_colors[BLUE]);
            _showColorBorder.Background = new SolidColorBrush(color);
            _redTextBox.Text = _colors[0].ToString();
            _greenTextBox.Text = _colors[1].ToString();
            _blueTextBox.Text = _colors[BLUE].ToString();

            _redTextBox.LostFocus += ChangeColor;
            _greenTextBox.LostFocus += ChangeColor;
            _blueTextBox.LostFocus += ChangeColor;

            _model.ChangeShape(CIRCLE_TYPE);
            _model.ChangeColor(_colors);
            RefreshButton();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // circle button click
        private void HandleCircleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ChangeShape(CIRCLE_TYPE);
            _buttonControl.IsCircleEnabled = false;
            _buttonControl.IsRectangleEnabled = true;
            _buttonControl.IsSmileEnabled = true;
            HandleModelChanged();
        }

        // rectangle button click
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ChangeShape(RECTANGLE_TYPE);
            _buttonControl.IsCircleEnabled = true;
            _buttonControl.IsRectangleEnabled = false;
            _buttonControl.IsSmileEnabled = true;
            HandleModelChanged();
        }

        // smile button click
        private void HandleSmileButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ChangeShape(SMILE_TYPE);
            _buttonControl.IsCircleEnabled = true;
            _buttonControl.IsRectangleEnabled = true;
            _buttonControl.IsSmileEnabled = false;
            HandleModelChanged();
        }

        // undo button click
        private void HandleUndoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Undo();
            HandleModelChanged();
        }

        // redo button click
        private void HandleRedoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Redo();
            HandleModelChanged();
        }

        //delete button click
        private void HandleDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            _model.DeleteSelectedShape();
            HandleModelChanged();
        }

        //clear button click
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.MakeClear();
            RefreshButton();
        }

        //save button click
        private void HandleSaveButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.GenerateImageDataFile();
        }

        //color button click
        private void HandleChangeColorButtonClick(object sender, RoutedEventArgs e)
        {
            _colors = new int[] { Convert.ToInt32(_redTextBox.Text), Convert.ToInt32(_greenTextBox.Text), Convert.ToInt32(_blueTextBox.Text), 255 };
            _model.ChangeColor(_colors);
        }

        //exit button click
        private void HandleExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        //canvas mouse down
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.Press(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // canvas mouse up
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.Release(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // canvas mouse move
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            string cursor = _model.Move(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            if (cursor == "Default")
                Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
            else if (cursor == "SizeAll")
                Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.SizeAll, 1);
            else if (cursor == "SizeNESW")
                Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.SizeNortheastSouthwest, 1);
            else if (cursor == "SizeNWSE")
                Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.SizeNorthwestSoutheast, 1);
        }

        // model changed
        public void HandleModelChanged()
        {
            _buttonControl.IsRedoEnabled = _model.IsRedoEnabled;
            _buttonControl.IsUndoEnabled = _model.IsUndoEnabled;
            _buttonControl.IsDeleteEnabled = _model.IsSelected;
            _presentationModel.Draw();
            RefreshButton();
        }

        // refresh button
        public void RefreshButton()
        {
            _redoButton.IsEnabled = _buttonControl.IsRedoEnabled;
            _undoButton.IsEnabled = _buttonControl.IsUndoEnabled;
            _circleButton.IsEnabled = _buttonControl.IsCircleEnabled;
            _rectangleButton.IsEnabled = _buttonControl.IsRectangleEnabled;
            _smileButton.IsEnabled = _buttonControl.IsSmileEnabled;
            _deleteButton.IsEnabled = _buttonControl.IsDeleteEnabled;
        }

        // change color
        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            Color color = Color.FromArgb((byte)MAX, (byte)(Convert.ToInt32(_redTextBox.Text)), (byte)(Convert.ToInt32(_greenTextBox.Text)), (byte)(Convert.ToInt32(_blueTextBox.Text)));
            _showColorBorder.Background = new SolidColorBrush(color);
        }
    }
}
