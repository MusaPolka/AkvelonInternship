using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorServices.Base;
using TextEditorServices.Contracts;

namespace TextEditorServices
{
    public class DeleteCharService : ICommand
    {
        private TextEditorService _textEditorService;
        public DeleteCharService(TextEditorService textEditor)
        {
            _textEditorService = textEditor;
        }
        public void Execute()
        {
            if (_textEditorService.Column >= 0)
            {
                _textEditorService.charList[_textEditorService.Row].RemoveAt(_textEditorService.Column);
                _textEditorService.Column--;
            }
            else
            {
                _textEditorService.Row--;
                _textEditorService.Column = _textEditorService.charList[_textEditorService.Row].Count - 1;
                _textEditorService.charList[_textEditorService.Row].RemoveAt(_textEditorService.Column);
            }
        }

        public void Redo()
        {
            ICommand deleteChar = new DeleteCharService(_textEditorService);
            deleteChar.Execute();
        }

        public void Undo()
        {
            ICommand insertCharTo = new InsertCharService(_textEditorService.lastChar, _textEditorService, _textEditorService.Row, _textEditorService.Column);
            insertCharTo.Execute();
        }
    }
}
