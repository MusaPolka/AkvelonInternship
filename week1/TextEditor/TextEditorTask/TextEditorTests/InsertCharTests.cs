using System;
using System.Collections.Generic;
using TextEditorServices;
using TextEditorServices.Base;
using TextEditorServices.Contracts;
using Xunit;

namespace TextEditorTests
{
    public class InsertCharTests
    {
        [Fact]
        public void Execute_InsertChar_ShoulTeturn_Char()
        {
            List<List<char>> charList = new List<List<char>>();
            charList.Add(new List<char>());
            charList.Add(new List<char>());

            ICommand command = new InsertCharService('m', new TextEditorService(charList), 0, 0);
            command.Execute();

            var expected = 'm';

            var actual = charList[0][0];

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Undo_ShoulReturnTrue()
        {
            List<List<char>> charList = new List<List<char>>();
            charList.Add(new List<char>());
            charList.Add(new List<char>());

            ICommand command = new InsertCharService('m', new TextEditorService(charList), 0, 0);
            command.Execute();
            command.Execute();
            command.Undo();

            Assert.True(charList[0].Count == 1);
        }
    }
}
