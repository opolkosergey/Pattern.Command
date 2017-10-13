using System.Collections.Generic;
using UndoAndRedoActions.Interfaces;

namespace UndoAndRedoActions
{
    public static class CommandsTools
    {
        public static Stack<ICommand> HistoryBackStack = new Stack<ICommand>();
        public static Stack<ICommand> HistoryForwardStack = new Stack<ICommand>();

        public static void UndoAction()
        {
            if (HistoryBackStack.Count > 0)
            {
                HistoryBackStack.Peek().UndoAction();
            }                
        }

        public static void RedoAction()
        {
            if (HistoryForwardStack.Count > 0)
            {
                HistoryForwardStack.Peek().DoAction();
            }                
        }
    }
}
