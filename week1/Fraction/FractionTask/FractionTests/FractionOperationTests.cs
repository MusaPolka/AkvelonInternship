using FractionTask;
using System;
using Xunit;

namespace FractionTests
{
    public class FractionOperationTests
    {
        [Fact]
        public void Multiply_Fraction()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 2);

            var expected = new Fraction(1, 4);

            var actual = fractionA.Multiply(fractionB);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_Fraction()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 2);

            var expected = new Fraction(1, 1);

            var actual = fractionA.Divide(fractionB);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_Fraction()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 2);

            var expected = new Fraction(1, 1);

            var actual = fractionA.Add(fractionB);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Different_Fraction()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 2);

            var expected = new Fraction(0, 2);

            var actual = fractionA.Difference(fractionB);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Fraction_DivideByZero()
        {
            Assert.Throws<DivideByZeroException>(() => new Fraction(1, 0));
        }

        [Fact]
        public void ToDouble_ShouldReturnDouble()
        {
            Fraction fractionA = new Fraction(1, 2);

            var expected = 0.5;

            var actual = fractionA.ToDouble();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToEquals_ShouldReturnTrue()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 2);

            Assert.True(fractionA.Equals(fractionB));
        }

        [Fact]
        public void ToEquals_ReturnFalse()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 3);

            Assert.False(fractionA.Equals(fractionB));
        }
    }
}
