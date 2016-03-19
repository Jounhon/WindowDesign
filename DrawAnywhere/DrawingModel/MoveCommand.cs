using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class MoveCommand : ICommand
    {
        Model _model;
        int _index;
        double[] _position = { };
        const int ORIGIN_X = 0;
        const int ORIGIN_Y = 1;
        const int NEW_X = 2;
        const int NEW_Y = 3;

        // init
        public MoveCommand(Model model, int index, double[] position)
        {
            _model = model;
            _index = index;
            _position = position;
        }

        // excute
        public void Execute()
        {
            _model.MoveShape(_index, _position[NEW_X], _position[NEW_Y]);
        }

        // unexcute
        public void ReverseExecute()
        {
            _model.MoveBackShape(_index, _position[ORIGIN_X], _position[ORIGIN_Y]);
        }
    }
}
