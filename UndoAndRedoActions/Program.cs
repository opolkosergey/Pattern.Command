using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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
                var command = new AddObjectCommand(list,random.Next(0,20));
                command.DoAction();
            }

            list.ForEach(a => Write($"{a} "));
            WriteLine();
            
            var deleteCommand = new DeleteObjectCommand(list.First(),list);
            deleteCommand.DoAction();

            list.ForEach(a => Write($"{a} "));
            WriteLine();

            CommandsTools.UndoAction();
            list.ForEach(a => Write($"{a} "));

            ReadKey();
        }
    }
}
