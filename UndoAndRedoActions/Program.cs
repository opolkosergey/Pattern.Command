using System;
using System.Collections.Generic;
using System.Linq;
using UndoAndRedoActions.Commands;

namespace UndoAndRedoActions
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var list = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                var command = new AddObjectCommand<int>(list, random.Next(0, 20));
                command.DoAction();
            }

            list.ForEach(a => Console.Write(string.Format("{0} ", a)));
            Console.WriteLine();
            
            var deleteCommand = new DeleteObjectCommand<int>(list.First(), list);
            deleteCommand.DoAction();

            list.ForEach(a => Console.Write(string.Format("{0} ", a)));
            Console.WriteLine();

            CommandsTools.UndoAction();
            list.ForEach(a => Console.Write(string.Format("{0} ", a)));
            Console.WriteLine();

            CommandsTools.RedoAction();

            list.ForEach(a => Console.Write(string.Format("{0} ", a)));

            Console.ReadKey();
        }
    }
}
