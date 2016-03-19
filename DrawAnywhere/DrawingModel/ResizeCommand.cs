using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ResizeCommand : ICommand
    {
        Model _model;
        int _index;
        double[] _origin = { };
        double[] _newPoint = { };

        // init
        public ResizeCommand(Model model, int index, double[] origin, double[] newPoint)
        {
            _model = model;
            _index = index;
            _origin = origin;
            _newPoint = newPoint;
        }

        // excute
        public void Execute()
        {
            _model.Resize(_index, _newPoint, _origin);
        }

        // unexcute
        public void ReverseExecute()
        {
            _model.RecoverSize(_index, _origin);
        }
    }
}
