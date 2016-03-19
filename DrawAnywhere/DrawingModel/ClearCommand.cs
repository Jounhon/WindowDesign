using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ClearCommand : ICommand
    {
        Model _model;
        List<Shape> _list = new List<Shape>();

        // init
        public ClearCommand(Model model, List<Shape> list)
        {
            _model = model;
            foreach (Shape item in list)
                _list.Add(item);
        }

        // excute
        public void Execute()
        {
            _model.Clear();
        }

        // unexcute
        public void ReverseExecute()
        {
            _model.ClearBack(_list);
        }
    }
}
