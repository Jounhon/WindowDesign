using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.PresentationModel
{
    class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;

        // init
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
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
