using System;

namespace FractionTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction fractionA = new Fraction(1, 4);
            Fraction fractionB = new Fraction(1, 6);

            Fraction resultMultiply = fractionA.Multiply(fractionB);
            Fraction resultDivide = fractionA.Divide(fractionB);
            Fraction resultAdd = fractionA.Add(fractionB);
            Fraction resultDifference = fractionA.Difference(fractionB);
            bool resultEquals = fractionA.Equals(fractionB);

            Console.WriteLine($"{fractionA} * {fractionB} = {resultMultiply}");
            Console.WriteLine($"{fractionA} / {fractionB} = {resultDivide}");
            Console.WriteLine($"{fractionA} + {fractionB} = {resultAdd.ToDouble()}");
            Console.WriteLine($"{fractionA} - {fractionB} = {resultDifference}");
            Console.WriteLine($"{fractionA} is equals to {fractionB} = {resultEquals}");
            Console.WriteLine($"Hash code is {fractionA.GetHashCode()}");
        }
    }
}
