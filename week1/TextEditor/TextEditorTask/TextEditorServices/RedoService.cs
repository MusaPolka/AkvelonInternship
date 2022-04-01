using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorServices.Base;
using TextEditorServices.Contracts;

namespace TextEditorServices
{
    public class RedoService
    {
        private TextEditorService _textEditor;

        public RedoService(TextEditorService textEditor)
        {
            _textEditor = textEditor;
        }

        public void Redo()
        {
            var temp = _textEditor.Temp.Pop();
            temp.Redo();
        }
    }
}
