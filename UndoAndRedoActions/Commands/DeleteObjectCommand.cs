using System;
using System.Collections.Generic;
using UndoAndRedoActions.Interfaces;

namespace UndoAndRedoActions
{
    public class DeleteObjectCommand<T> : ICommand where T : IEquatable<T>
    {
        private T _item;
        private List<T> _source;
        private int _position;

        public DeleteObjectCommand(T item, List<T> source)
        {
            _item = item;
            _source = source;
        }

        public void DoAction()
        {
            if (CommandsTools.HistoryForwardStack.Count > 0)
            {
                CommandsTools.HistoryForwardStack.Pop();
            }

            _position = _source.FindIndex(item => item.Equals(_item));

            _source.Remove(_item);
            CommandsTools.HistoryBackStack.Push(this);
        }

        public void UndoAction()
        {
            if (_position != -1)
            {
                _source.Insert(_position,_item);
            }

            var command = CommandsTools.HistoryBackStack.Pop();
            CommandsTools.HistoryForwardStack.Push(command);
        }
    } 
}
