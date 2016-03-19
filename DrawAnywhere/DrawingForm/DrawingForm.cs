using DrawingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        ButtonControl _buttonControl;
        Panel _canvas = new DoublePanel();
        const string CIRCLE_TYPE = "DrawingModel.Circles";
        const string RECTANGLE_TYPE = "DrawingModel.Rectangles";
        const string SMILE_TYPE = "DrawingModel.Smiles";
        int[] _colors = { 120, 217, 237, 255 };

        public DrawingForm()
        {
            InitializeComponent();
            // prepare canvas
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.White;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            // event handler
            _circleToolStripButton.Click += HandleCircleButtonClick;
            _rectangleToolStripButton.Click += HandleRectangleButtonClick;
            _smileToolStripButton.Click += HandleSmileButtonClick;
            _redoToolStripButton.Click += HandleRedoButtonClick;
            _undoToolStripButton.Click += HandleUndoButtonClick;
            _deleteToolStripButton.Click += HandleDeleteButtonClick;
            _clearToolStripButton.Click += HandleClearButtonClick;
            _saveToolStripButton.Click += HandleSaveButtonClick;
            _colorToolStripButton.Click += HandleChangeColorButtonClick;
            _showColorToolStripButton.BackColor = Color.FromArgb(_colors[3], _colors[0], _colors[1], _colors[2]);
            _saveToDriveToolStripMenuItem.Click += HandleSaveButtonClick;
            _exitToolStripMenuItem.Click += HandleExitButtonClick;
            // prepare presentation model and model
            _model = new Model();
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _buttonControl = new ButtonControl();
            _model._modelChanged += HandleModelChanged;
            _model.ChangeShape(CIRCLE_TYPE);
            _model.ChangeColor(_colors);
            
            Graphics graphic = Graphics.FromHwnd(this.Handle);
            _presentationModel.GetFileFromDrive(graphic);
            HandleModelChanged();
        }

        // circle button click
        public void HandleCircleButtonClick(object sender, System.EventArgs e)
        {
            _model.ChangeShape(CIRCLE_TYPE);
            _buttonControl.IsCircleEnabled = false;
            _buttonControl.IsRectangleEnabled = true;
            _buttonControl.IsSmileEnabled = true;
            HandleModelChanged();
        }

        // rectangle button click
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.ChangeShape(RECTANGLE_TYPE);
            _buttonControl.IsCircleEnabled = true;
            _buttonControl.IsRectangleEnabled = false;
            _buttonControl.IsSmileEnabled = true;
            HandleModelChanged();
        }

        // smile button click
        public void HandleSmileButtonClick(object sender, System.EventArgs e)
        {
            _model.ChangeShape(SMILE_TYPE);
            _buttonControl.IsCircleEnabled = true;
            _buttonControl.IsRectangleEnabled = true;
            _buttonControl.IsSmileEnabled = false;
            HandleModelChanged();
        }

        // undo button click
        public void HandleUndoButtonClick(object sender, System.EventArgs e)
        {
            _model.Undo();
            HandleModelChanged();
        }

        // redo button click
        public void HandleRedoButtonClick(object sender, System.EventArgs e)
        {
            _model.Redo();
            HandleModelChanged();
        }

        // delete button click
        public void HandleDeleteButtonClick(object sender, System.EventArgs e)
        {
            _model.DeleteSelectedShape();
            HandleModelChanged();
        }

        //clear button click
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.MakeClear();
            RefreshButton();
        }

        // save paint
        public void HandleSaveButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.GenerateImageDataFile(_canvas.Width, _canvas.Height);
        }

        // change color
        public void HandleChangeColorButtonClick(object sender, System.EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                _showColorToolStripButton.BackColor = _colorDialog.Color;
                _colors = new int[] { _colorDialog.Color.R, _colorDialog.Color.G, _colorDialog.Color.B, _colorDialog.Color.A };
                _model.ChangeColor(_colors);
            }
        }

        //canvas mouse down
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.Press(e.X, e.Y);
        }

        // canvas mouse up
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.Release(e.X, e.Y);
        }

        // canvas mouse move
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            string cursor = _model.Move(e.X, e.Y);
            if (cursor == "Default")
                this.Cursor = Cursors.Default;
            else if (cursor == "SizeAll")
                this.Cursor = Cursors.SizeAll;
            else if (cursor == "SizeNESW")
                this.Cursor = Cursors.SizeNESW;
            else if (cursor == "SizeNWSE")
                this.Cursor = Cursors.SizeNWSE;
        }

        // canvas paint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // exit
        public void HandleExitButtonClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        // model changed
        public void HandleModelChanged()
        {
            _buttonControl.IsRedoEnabled = _model.IsRedoEnabled;
            _buttonControl.IsUndoEnabled = _model.IsUndoEnabled;
            _buttonControl.IsDeleteEnabled = _model.IsSelected;
            Invalidate(true);
            RefreshButton();
        }

        // refresh button
        public void RefreshButton()
        {
            _redoToolStripButton.Enabled = _buttonControl.IsRedoEnabled;
            _undoToolStripButton.Enabled = _buttonControl.IsUndoEnabled;
            _circleToolStripButton.Enabled = _buttonControl.IsCircleEnabled;
            _rectangleToolStripButton.Enabled = _buttonControl.IsRectangleEnabled;
            _smileToolStripButton.Enabled = _buttonControl.IsSmileEnabled;
            _deleteToolStripButton.Enabled = _buttonControl.IsDeleteEnabled;
        }
    }
}
