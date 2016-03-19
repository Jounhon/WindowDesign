using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DeleteCommand : ICommand
    {
        Model _model;
        int _index;
        Shape _shape;
        // init
        public DeleteCommand(Model model, int index, Shape shape)
        {
            _model = model;
            _index = index;
            _shape = shape;
        }

        // excute
        public void Execute()
        {
            _model.DeleteShape(_index);
        }

        // unexcute
        public void ReverseExecute()
        {
            _model.RecoverShape(_index, _shape);
        }
    }
}
