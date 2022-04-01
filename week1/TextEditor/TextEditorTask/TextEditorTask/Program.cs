using System;
using System.Collections.Generic;
using TextEditorServices.Base;

namespace TextEditorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> charList = new List<List<char>>();
            charList.Add(new List<char>());
            charList.Add(new List<char>());

            TextEditorService textEditor = new TextEditorService(charList);
            textEditor.MoveCursorTo(0, 0);
            textEditor.InsertChar('M');
            textEditor.MoveCursorTo(0, 1);
            textEditor.InsertChar('u');
            textEditor.MoveCursorTo(0, 2);
            textEditor.InsertChar('s');
            textEditor.MoveCursorTo(0, 3);
            textEditor.InsertChar('a');

            textEditor.MoveCursorTo(1, 0);

            textEditor.InsertChar('i');
            textEditor.MoveCursorTo(1, 1);
            textEditor.InsertChar('s');
            textEditor.MoveCursorTo(1, 2);
            textEditor.MoveCursorTo(1, 3);
            textEditor.Undo();
            textEditor.InsertChar('E');


            textEditor.Print();
        }
    }
}
