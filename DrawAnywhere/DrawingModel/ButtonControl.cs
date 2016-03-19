using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ButtonControl
    {
        bool _isCircleEnabled = false;
        bool _isRectangleEnabled = true;
        bool _isSmileEnabled = true;
        bool _isRedoEnabled = false;
        bool _isUndoEnabled = false;
        bool _isDeleteEnabled = false;

        // property of _isCircleEnabled
        public bool IsCircleEnabled
        {
            get
            {
                return _isCircleEnabled;
            }
            set
            {
                _isCircleEnabled = value;
            }
        }

        // property of _isRectangleEnabled
        public bool IsRectangleEnabled
        {
            get
            {
                return _isRectangleEnabled;
            }
            set
            {
                _isRectangleEnabled = value;
            }
        }

        // property of _isSmileEnabled
        public bool IsSmileEnabled
        {
            get
            {
                return _isSmileEnabled;
            }
            set
            {
                _isSmileEnabled = value;
            }
        }

        // property of _isRedoEnabled
        public bool IsRedoEnabled
        {
            get
            {
                return _isRedoEnabled;
            }
            set
            {
                _isRedoEnabled = value;
            }
        }

        // property of _isUndoEnabled
        public bool IsUndoEnabled
        {
            get
            {
                return _isUndoEnabled;
            }
            set
            {
                _isUndoEnabled = value;
            }
        }

        // property of _isDeleteEnabled
        public bool IsDeleteEnabled
        {
            get
            {
                return _isDeleteEnabled;
            }
            set
            {
                _isDeleteEnabled = value;
            }
        }
    }
}
