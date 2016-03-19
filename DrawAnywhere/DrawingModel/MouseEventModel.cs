using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class MouseEventModel
    {
        Model _model;
        List<Shape> _shapes = new List<Shape>();
        const string RECTANGLE = "DrawingModel.Rectangles";
        const string SIZE_NORTH_WEST_SOUTH_EAST = "SizeNWSE";
        const string SIZE_NORTH_EAST_SOUTH_WEST = "SizeNESW";
        const string DEFAULT = "Default";
        const string SIZE_ALL = "SizeAll";
        const int THIRD = 3; // left-bottom, offset
        const int TWO = 2; // right-top
        const int FOURTH = 4; // right-bottom
        const int FIFTH = 5;
        Shape _hint = null;
        Shape _isSelected = null;
        bool _isPressed = false;
        double _firstPointX;
        double _firstPointY;
        double _originX;
        double _originY;
        double _originWidth;
        double _originHeight;
        int _selected = -1;
        int _sizedMode = -1;

        public MouseEventModel(Model model)
        {
            this._model = model;
        }

        public Shape Hint
        {
            get
            {
                return _hint;
            }
            set
            {
                _hint = value;
            }
        }

        public List<Shape> ShapeList
        {
            get
            {
                return _shapes;
            }
            set
            {
                _shapes = value;
            }
        }

        public bool IsPressed
        {
            get
            {
                return _isPressed;
            }
            set
            {
                _isPressed = value;
            }
        }

        public int Selected
        {
            get
            {
                return _selected;
            }
        }

        public int SizeMode
        {
            set
            {
                _sizedMode = value;
            }
        }

        public Shape IsSelected
        {
            get
            {
                return _isSelected;
            }
        }       

        // check exist
        Shape CheckExist(double positionX, double positionY)
        {
            Shape selected = null;
            for (int index = _shapes.Count - 1; index >= 0; index--)
            {
                bool getShape = false;
                double radius = CalculateRadius(index);
                if (_shapes[index].GetType().ToString() == RECTANGLE && _shapes[index].PositionX <= positionX && _shapes[index].PositionY <= positionY && (_shapes[index].PositionX + _shapes[index].Width) >= positionX && (_shapes[index].PositionY + _shapes[index].Height) >= positionY)
                    getShape = true;
                else if (_shapes[index].GetType().ToString() != RECTANGLE && _shapes[index].PositionX <= positionX && _shapes[index].PositionY <= positionY && (_shapes[index].PositionX + radius) >= positionX && (_shapes[index].PositionY + radius) >= positionY)
                    getShape = true;
                if (getShape)
                {
                    selected = _shapes[index];
                    _selected = index;
                }
            }
            return selected;
        }

        // calculate radius
        double CalculateRadius(int index)
        {
            if (_shapes[index].Width > _shapes[index].Height)
                return _shapes[index].Width * Math.Sqrt(TWO) / TWO;
            else
                return _shapes[index].Height * Math.Sqrt(TWO) / TWO;
        }

        // press
        public void PressDown(double positionX, double positionY)
        {
            _firstPointX = positionX;
            _firstPointY = positionY;
            _isSelected = CheckExist(positionX, positionY);
            ClearBorder();
            if (_isSelected != null)
            {
                _hint = _isSelected;
                _hint.Border = true;
                _originX = _hint.PositionX;
                _originY = _hint.PositionY;
                _originWidth = _hint.Width;
                _originHeight = _hint.Height;
            }
            else
                _selected = -1;
            if (_isSelected == null && positionX > 0 && positionY > 0)
                _isPressed = true;
        }

        // move
        public string Move(double positionX, double positionY)
        {
            if (_isSelected == null && _isPressed)
            {
                SetShape(positionX - _firstPointX, positionY - _firstPointY); 
                _model.NotifyModelChanged();
            }
            else if (_isSelected != null)
            {
                SelectMode(positionX, positionY);
                _model.NotifyModelChanged();
                if (_sizedMode == -1)
                    return SIZE_ALL;
            }
            if (_selected != -1 && _shapes.Count != 0 && _isSelected == null)
                return CheckAnchor(positionX, positionY);
            return DEFAULT;
        }

        // release
        public void Release(double positionX, double positionY, CommandManager commandManager)
        {
            double width = positionX - _firstPointX;
            double height = positionY - _firstPointY;
            if (_isSelected == null && _isPressed)
                DrawMode(width, height);
            if (_isSelected != null)
            {
                _isSelected = null;
                double[] position = { _originX, _originY, width + _originX, height + _originY };
                double[] originSize = { _originX, _originY, _originWidth, _originHeight, _firstPointX, _firstPointY };
                double[] newSize = { _sizedMode, positionX, positionY };
                if (_sizedMode == -1 && width != 0 && height != 0)
                    commandManager.Execute(new MoveCommand(_model, _selected, position));
                else if (_sizedMode != -1)
                    commandManager.Execute(new ResizeCommand(_model, _selected, originSize, newSize));
            }
            _model.NotifyModelChanged();
        }

        // draw mode
        void DrawMode(double width, double height)
        {
            _isPressed = false;
            SetShape(width, height);
            if (width != 0 && height != 0)
                _model.AddNewShape();
        }

        // selected mode
        void SelectMode(double positionX, double positionY)
        {
            double[] origin = { _originX, _originY, _originWidth, _originHeight, _firstPointX, _firstPointY };
            if (_sizedMode == -1)
            {
                _hint.PositionX = _originX + positionX - _firstPointX;
                _hint.PositionY = _originY + positionY - _firstPointY;
            }
            else if (_sizedMode != -1)
                ResizeShape(_hint, positionX, positionY, origin);
        }

        // clear border
        void ClearBorder()
        {
            foreach (Shape item in _shapes)
                item.Border = false;
        }

        // Resize shape
        public void ResizeShape(Shape shape, double positionX, double positionY, double[] origin)
        {
            if (_sizedMode == 1)
                shape.SetData(positionX, positionY, origin[TWO] - (positionX - origin[FOURTH]), origin[THIRD] - (positionY - origin[FIFTH]));
            else if (_sizedMode == FOURTH)
                shape.SetData(origin[0], origin[1], origin[TWO] + (positionX - origin[FOURTH]), origin[THIRD] + (positionY - origin[FIFTH]));
            else if (_sizedMode == TWO)
                shape.SetData(origin[0], origin[1] + (positionY - origin[FIFTH]), origin[TWO] + (positionX - origin[FOURTH]), origin[THIRD] - (positionY - origin[FIFTH]));
            else if (_sizedMode == THIRD)
                shape.SetData(origin[0] + (positionX - origin[FOURTH]), origin[1], origin[TWO] - (positionX - origin[FOURTH]), origin[THIRD] + (positionY - origin[FIFTH]));
        }

        // check anchor position
        public string CheckAnchor(double positionX, double positionY)
        {
            Shape shape = _shapes[_selected];
            double width = shape.Width;
            double height = shape.Height;
            if (shape.GetType().ToString() != RECTANGLE)
                width = height = CalculateRadius(_selected);
            if ((shape.PositionX <= positionX && shape.PositionX + THIRD >= positionX && shape.PositionY <= positionY && shape.PositionY + THIRD >= positionY))
                _sizedMode = 1;
            else if ((shape.PositionX + width - THIRD <= positionX && shape.PositionX + width >= positionX && shape.PositionY + height - THIRD <= positionY && shape.PositionY + height >= positionY))
                _sizedMode = FOURTH;
            else if ((shape.PositionX + width - THIRD <= positionX && shape.PositionX + width >= positionX && shape.PositionY <= positionY && shape.PositionY + THIRD >= positionY))
                _sizedMode = TWO;
            else if ((shape.PositionX <= positionX && shape.PositionX + THIRD >= positionX && shape.PositionY + height - THIRD <= positionY && shape.PositionY + height >= positionY))
                _sizedMode = THIRD;
            else
                _sizedMode = -1;
            return GetSizeMode();
        }

        // size mode
        string GetSizeMode()
        {
            if (_sizedMode == 1 || _sizedMode == FOURTH)
                return SIZE_NORTH_WEST_SOUTH_EAST;
            else if (_sizedMode == TWO || _sizedMode == THIRD)
                return SIZE_NORTH_EAST_SOUTH_WEST;
            else
                return DEFAULT;
        }

        // set cursor Shape
        void SetShape(double width, double height)
        {
            if (width >= 0)
                _hint.PositionX = _firstPointX;
            else
                _hint.PositionX = _firstPointX + width;
            if (height >= 0)
                _hint.PositionY = _firstPointY;
            else
                _hint.PositionY = _firstPointY + height;
            _hint.Width = Math.Abs(width);
            _hint.Height = Math.Abs(height);
        }
    }
}
