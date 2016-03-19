using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        CommandManager _commandManager = new CommandManager();
        MouseEventModel _mouseEventModel;
        string _shapeType;
        int[] _colors;
        const int THIRD = 3;
        const int TWO = 2;
        public Model()
        {
            this._mouseEventModel = new MouseEventModel(this);
        }

        // get _circles
        public List<Shape> GetShapes
        {
            get
            {
                return _mouseEventModel.ShapeList;
            }
        }

        // change _hint shape
        public void ChangeShape(string typeName)
        {
            _shapeType = typeName;
            Type type = Type.GetType(typeName);
            _mouseEventModel.Hint = (Shape)Activator.CreateInstance(type);
            _mouseEventModel.Hint.Color = _colors;
        }

        // change _hint color
        public void ChangeColor(int[] colors)
        {
            _mouseEventModel.Hint.Color = colors;
            if (_mouseEventModel.Selected != -1)
                _commandManager.Execute(new ColorCommand(this, _mouseEventModel.Selected, _mouseEventModel.ShapeList[_mouseEventModel.Selected].Color, colors));
            _colors = colors;
            NotifyModelChanged();
        }

        // change shape color
        public void ChangeShapeColor(int index, int[] colors)
        {
            _mouseEventModel.ShapeList[index].Color = colors;
        }

        // mouse click down
        public void Press(double positionX, double positionY)
        {
            _mouseEventModel.PressDown(positionX, positionY);
        }

        // mouse move
        public string Move(double positionX, double positionY)
        {
            return _mouseEventModel.Move(positionX, positionY);
        }

        // mouse click up
        public void Release(double positionX, double positionY)
        {
            _mouseEventModel.Release(positionX, positionY, _commandManager);
            ChangeShape(_shapeType);
        }

        // add shape to list by draw
        public void AddNewShape()
        {
            Shape hint = (Shape)Activator.CreateInstance(_mouseEventModel.Hint.GetType());
            hint.PositionX = _mouseEventModel.Hint.PositionX;
            hint.PositionY = _mouseEventModel.Hint.PositionY;
            hint.Width = _mouseEventModel.Hint.Width;
            hint.Height = _mouseEventModel.Hint.Height;
            hint.Color = _mouseEventModel.Hint.Color;
            _commandManager.Execute(new DrawCommand(this, hint));
        }
        
        // modify select shape by move
        public void MoveShape(int index, double positionX, double positionY)
        {
            _mouseEventModel.ShapeList[index].PositionX = positionX;
            _mouseEventModel.ShapeList[index].PositionY = positionY;
        }

        // back move shape
        public void MoveBackShape(int index, double originX, double originY)
        {
            _mouseEventModel.ShapeList[index].PositionX = originX;
            _mouseEventModel.ShapeList[index].PositionY = originY;
        }

        // add shape to list by data file
        public void AddDataShape(string typeName, double[] data, int[] colors)
        {
            Type type = Type.GetType(typeName);
            Shape hint = (Shape)Activator.CreateInstance(type);
            hint.PositionX = data[0];
            hint.PositionY = data[1];
            hint.Width = data[TWO];
            hint.Height = data[THIRD];
            hint.Color = colors;
            AddToList(hint);
        }

        // shape add to list
        public void AddToList(Shape shape)
        {
            _mouseEventModel.ShapeList.Add(shape);
        }

        // detele event
        public void DeleteSelectedShape()
        {
            if (_mouseEventModel.Selected != -1)
                _commandManager.Execute(new DeleteCommand(this, _mouseEventModel.Selected, _mouseEventModel.ShapeList[_mouseEventModel.Selected]));
        }

        // delete one shape
        public void DeleteShape(int index)
        {
            _mouseEventModel.ShapeList.RemoveAt(index);
        }

        // recover one shape
        public void RecoverShape(int index, Shape shape)
        {
            shape.Border = false;
            _mouseEventModel.ShapeList.Insert(index, shape);
        }

        // resize
        public void Resize(int index, double[] point, double[] data)
        {
            _mouseEventModel.SizeMode = (int)point[0];
            _mouseEventModel.ResizeShape(_mouseEventModel.ShapeList[index], point[1], point[TWO], data);
        }

        //revocer size
        public void RecoverSize(int index, double[] data)
        {
            _mouseEventModel.ShapeList[index].PositionX = data[0];
            _mouseEventModel.ShapeList[index].PositionY = data[1];
            _mouseEventModel.ShapeList[index].Width = data[TWO];
            _mouseEventModel.ShapeList[index].Height = data[THIRD];
        }

        // delete last shape of list
        public void DeleteFromBackShape()
        {
            _mouseEventModel.ShapeList.RemoveAt(_mouseEventModel.ShapeList.Count - 1);
        }

        // clear all circles
        public void MakeClear()
        {
            _mouseEventModel.IsPressed = false;
            _commandManager.Execute(new ClearCommand(this, _mouseEventModel.ShapeList));
            NotifyModelChanged();
        }

        // clear
        public void Clear()
        {
            _mouseEventModel.ShapeList.Clear();
        }

        // claer back
        public void ClearBack(List<Shape> list)
        {
            foreach (Shape item in list)
                _mouseEventModel.ShapeList.Add(item);
            NotifyModelChanged();
        }

        // draw circle by interface
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aLine in _mouseEventModel.ShapeList)
            {
                if (_mouseEventModel.IsSelected != null && _mouseEventModel.ShapeList.IndexOf(aLine) == _mouseEventModel.Selected)
                {
                    _mouseEventModel.Hint.Draw(graphics);
                    continue;
                }
                aLine.Draw(graphics);
            }
            if (_mouseEventModel.IsPressed)
                _mouseEventModel.Hint.Draw(graphics);
        }

        // notify model changed
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // execute undo 
        public void Undo()
        {
            _commandManager.Undo();
        }

        // execute redo
        public void Redo()
        {
            _commandManager.Redo();
        }

        // get redo enabled
        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        // det undo enabled
        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        // is selected shape
        public bool IsSelected
        {
            get
            {
                return _mouseEventModel.Selected != -1;
            }
        }
    }
}
