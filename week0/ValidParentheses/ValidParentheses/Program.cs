using System;

namespace ValidParentheses
{
    internal class Program
    {
        public static bool IsValid(string s)
        {
            var chars = s.ToCharArray();

            if (chars.Length % 2 == 1)
            {
                return false;
            }

            for (int i = 0; i < chars.Length; i += 2)
            {
                if ((chars[i] == '(' && chars[i + 1] != ')') ||
                    (chars[i] == '{' && chars[i + 1] != '}') ||
                    (chars[i] == '[' && chars[i + 1] != ']'))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            var isValidParen = IsValid("()[}");

            Console.WriteLine(isValidParen);
        }
    }
}
