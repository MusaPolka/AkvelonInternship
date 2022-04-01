using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorServices.Base;
using TextEditorServices.Contracts;

namespace TextEditorServices
{
    public class UndoService
    {
        TextEditorService _textEditor;
        public UndoService(TextEditorService textEditor)
        {
            _textEditor = textEditor;
        }

        public void Undo()
        {
            var temp = _textEditor.Stack.Pop();
            _textEditor.Temp.Push(temp);
            temp.Undo();
        }
    }
}
