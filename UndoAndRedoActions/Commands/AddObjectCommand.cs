using System;
using System.Collections.Generic;
using UndoAndRedoActions.Interfaces;

namespace UndoAndRedoActions.Commands
{
    public class AddObjectCommand<T> : ICommand where T : IEquatable<T>
    {
        private List<T> _source;
        private T _item;
        private int _position;

        public AddObjectCommand(List<T> source, T item)
        {
            _item = item;
            _source = source;
            _position = -1;
        }

        public void DoAction()
        {
            if (CommandsTools.HistoryForwardStack.Count > 0)
            {
                CommandsTools.HistoryForwardStack.Pop();
            }

            if (_position == -1)
            {
                _source.Add(_item);
            }
            else
            {
                _source.Insert(_position,_item);
            }

            CommandsTools.HistoryBackStack.Push(this);
        }

        public void UndoAction()
        {
            _position = _source.FindIndex(item => item.Equals(_item));
            _source.Remove(_item);

            var command = CommandsTools.HistoryBackStack.Pop();
            CommandsTools.HistoryForwardStack.Push(command);
        }
    }
}
