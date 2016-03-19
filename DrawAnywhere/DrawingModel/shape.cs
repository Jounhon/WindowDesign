using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        private double _positionX; // x-axis
        private double _positionY; // y-axis
        private double _width;
        private double _height;
        private int[] _color;
        private bool _border = false;

        // draw
        public virtual void Draw(IGraphics graphics)
        {
        } 

        // set x , y , w , h
        public void SetData(double positionX, double positionY, double width, double height)
        {
            _positionX = positionX;
            _positionY = positionY;
            _width = width;
            _height = height;
        }

        public double PositionX
        {
            get
            {
                return _positionX;
            }
            set
            {
                _positionX = value;
            }
        }

        public double PositionY
        {
            get
            {
                return _positionY;
            }
            set
            {
                _positionY = value;
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public int[] Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public bool Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
            }
        }
    }
}
