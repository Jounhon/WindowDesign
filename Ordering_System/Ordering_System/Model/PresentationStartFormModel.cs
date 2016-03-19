using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering_System.Model;

namespace Ordering_System
{
    public class PresentationStartFormModel
    {
        SystemModel _model;
        public PresentationStartFormModel(SystemModel systemModel)
        {
            this._model = systemModel;
        }
        
        // get system model
        public SystemModel GetSystemModel()
        {
            return _model;
        }
    }
}
