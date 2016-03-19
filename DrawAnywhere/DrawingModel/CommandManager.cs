using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();
        const string EXCEPTION = "Cannot Undo exception\n";

        //執行
        public void Execute(ICommand command)
        {
            command.Execute();
            // push command 進 undo stack
            _undo.Push(command);
            // 清除redo stack
            _redo.Clear();      
        }

        // undo
        public void Undo()
        {
            if (_undo.Count <= 0)
                return;
                //throw new Exception(EXCEPTION);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.ReverseExecute();
        }

        // redo
        public void Redo()
        {
            if (_redo.Count <= 0)
                return;
                //throw new Exception(EXCEPTION);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        // is redo enabled ?
        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        // is undo enabled ?
        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
