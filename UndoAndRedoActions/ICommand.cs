using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoAndRedoActions
{
    public interface ICommand
    {
        void DoAction();
        void UndoAction();
    }
}
