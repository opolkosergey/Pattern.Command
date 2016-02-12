using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoAndRedoActions
{
    public class DeleteObjectCommand : ICommand
    {
        private int i;
        private List<int> list;
        private int position;

        public DeleteObjectCommand(int i, List<int> source)
        {
            this.i = i;
            this.list = source;
        }

        public void DoAction()
        {
            if (CommandsTools.HistoryForwardStack.Count > 0)
                CommandsTools.HistoryForwardStack.Pop();
            position = list.FindIndex(a => a == i);
            list.Remove(i);
            CommandsTools.HistoryBackStack.Push(this);
        }

        public void UndoAction()
        {
            if(position != -1)
                list.Insert(position,i);
            var command = CommandsTools.HistoryBackStack.Pop();
            CommandsTools.HistoryForwardStack.Push(command);
        }
    } 
}
