using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorServices.Contracts
{
    public interface ITextEditorService
    {
        void MoveCursorTo(int row, int col);
        void InsertChar(char c);
        void DeleteChar();
    }
}
