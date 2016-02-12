using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoAndRedoActions
{
    public static class CommandsTools
    {
        public static void UndoAction()
        {
            if (HistoryBackStack.Count > 0)
                HistoryBackStack.Peek().UndoAction();
        }
        public static void RedoAction()
        {
            if (HistoryForwardStack.Count > 0)
                HistoryForwardStack.Peek().DoAction();
        }

        public static Stack<ICommand> HistoryBackStack = new Stack<ICommand>();
        public static Stack<ICommand> HistoryForwardStack = new Stack<ICommand>();
    }
}
