using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorServices.Base;
using TextEditorServices.Contracts;

namespace TextEditorServices
{
    public class InsertCharService : ICommand
    {
        char _input;
        private TextEditorService _textEditor;
        int _row;
        int _col;

        public InsertCharService(char input, TextEditorService textEditor, int row, int col)
        {
            _input = input;
            _textEditor = textEditor;
            _row = row;
            _col = col;
        }

        public void Execute()
        {
            _textEditor.charList[_row].Insert(_col, _input);
        }

        public void Undo()
        {
            ICommand deleteChar = new DeleteCharService(_textEditor);
            deleteChar.Execute();
        }

        public void Redo()
        {
            ICommand insertCharTo = new InsertCharService(_input, _textEditor, _row, _col);
            insertCharTo.Execute();
        }
    }
}
