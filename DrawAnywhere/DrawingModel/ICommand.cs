using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface ICommand
    {
        //執行
        void Execute();

        //反執行
        void ReverseExecute();
    }
}
