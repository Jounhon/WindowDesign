using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ColorCommand : ICommand
    {
        Model _model;
        int _index;
        int[] _originColors = { };
        int[] _newColors = { };

        // init
        public ColorCommand(Model model, int index, int[] originColors, int[] newColors)
        {
            _model = model;
            _index = index;
            _originColors = originColors;
            _newColors = newColors;
        }

        // excute
        public void Execute()
        {
            _model.ChangeShapeColor(_index, _newColors);
        }

        // unexcute
        public void ReverseExecute()
        {
            _model.ChangeShapeColor(_index, _originColors);
        }
    }
}
