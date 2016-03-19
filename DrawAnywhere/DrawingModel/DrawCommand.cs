using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawCommand : ICommand
    {
        Model _model;
        Shape _shape;

        // init
        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        // excute
        public void Execute()
        {
            _model.AddToList(_shape);
        }

        // unexcute
        public void ReverseExecute()
        {
            _model.DeleteFromBackShape();
        }
    }
}
