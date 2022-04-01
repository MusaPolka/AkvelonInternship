using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorServices.Base;
using TextEditorServices.Contracts;

namespace TextEditorServices
{
    public class MoveCursorToService : ICommand
    {
        private int _row;
        private int _column;
        private int _lastRow;
        private int _lastColumn;
        private TextEditorService _textEditorService;

        public MoveCursorToService(int row, int column, TextEditorService textEditorService)
        {
            _row = row;
            _column = column;
            _textEditorService = textEditorService;
            _lastRow = _textEditorService.Row;
            _lastColumn = _textEditorService.Column;
        }

        public void Execute()
        {
            _textEditorService.Row = _row;
            _textEditorService.Column = _column;
            
        }

        public void Undo()
        {
            _textEditorService.Row = _lastRow;
            _textEditorService.Column = _lastColumn;
        }
        public void Redo()
        {
            ICommand moveCursorTo = new MoveCursorToService(_row, _column, _textEditorService);
            moveCursorTo.Execute();
        }
    }
}
