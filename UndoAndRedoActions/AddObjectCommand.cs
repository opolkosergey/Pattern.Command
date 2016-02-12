using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoAndRedoActions
{
    public class AddObjectCommand : ICommand
    {
        private List<int> list;
        private int i;
        private int position;

        public AddObjectCommand(List<int> source, int i)
        {
            this.i = i;
            this.list = source;
            this.position = -1;
        }

        public void DoAction()
        {
            if (CommandsTools.HistoryForwardStack.Count > 0)
                CommandsTools.HistoryForwardStack.Pop();
            if (position == -1)
                list.Add(i);
            else list.Insert(position,i);
            CommandsTools.HistoryBackStack.Push(this);
        }

        public void UndoAction()
        {
            position = list.FindIndex(a => a == i);
            list.Remove(i);
            var command = CommandsTools.HistoryBackStack.Pop();
            CommandsTools.HistoryForwardStack.Push(command);
        }
    }
}
