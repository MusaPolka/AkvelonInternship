using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorServices.Contracts;

namespace TextEditorServices.Base
{
    public class TextEditorService : ITextEditorService
    {
        public int Row;
        public int Column;
        public List<List<char>> charList;
        public Stack<ICommand> Stack = new Stack<ICommand>();
        public Stack<ICommand> Temp = new Stack<ICommand>();
        public char lastChar;

        public TextEditorService(List<List<char>> list)
        {
            charList = list;
        }

        public void MoveCursorTo(int row, int col)
        {
            ICommand moveCursorTo = new MoveCursorToService(row, col, this);
            moveCursorTo.Execute();
            Stack.Push(moveCursorTo);  
        }

        public void InsertChar(char c)
        {
            ICommand insertCharTo = new InsertCharService(c, this, Row, Column);
            insertCharTo.Execute();
            Stack.Push(insertCharTo);
            lastChar = c;
        }

        public void DeleteChar()
        {
            ICommand deleteChar = new DeleteCharService(this);
            deleteChar.Execute();
            Stack.Push(deleteChar);
        }

        public void Undo()
        {
            UndoService undoService = new UndoService(this);
            undoService.Undo();
        }
        public void Redo()
        {
            RedoService redoService = new RedoService(this);
            redoService.Redo();
        }

        public void Print()
        {

            for (int i = 0; i < charList.Count; i++)
            {
                for (int j = 0; j < charList[i].Count; j++)
                {
                    Console.Write(charList[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
