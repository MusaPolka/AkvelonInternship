using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionTask
{
    public class Fraction
    {
        private int numenator;
        private int denominator;

        public Fraction(int numenator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            this.numenator = numenator;
            this.denominator = denominator;
        }
        public double ToDouble()
        {
            return (double)numenator / (double)denominator;
        }

        public override String ToString()
        {
            return $"{numenator}/{denominator}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numenator, denominator);
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction fraction && numenator == fraction.numenator && fraction.denominator == denominator)
            {
                return true;
            }

            return false;
        }

        void Reduce()
        {
            int i = Math.Min(Math.Abs(numenator), Math.Abs(denominator));

            if (i == 0)
            {
                return;
            }

            while((numenator % i != 0) || (denominator % i != 0))
            {
                i--;
            }

            numenator = numenator / i;
            denominator = denominator / i;
        }

        public Fraction Multiply(Fraction fraction)
        {
            Fraction result = new Fraction(numenator * fraction.numenator, denominator * fraction.denominator);

            result.Reduce();

            return result;
        }

        public Fraction Divide(Fraction fraction)
        {
            Fraction result = new Fraction(numenator * fraction.denominator, denominator * fraction.numenator);

            result.Reduce();

            return result;
        }

        public Fraction Add(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                Fraction res = new Fraction(numenator + fraction.numenator, denominator);
                res.Reduce();
                return res;
            }

            var numenatorA = numenator * (numenator * fraction.denominator);
            var denominatorA = denominator * (numenator * fraction.denominator);

            var numenatorB = fraction.numenator * (fraction.numenator * denominator);

            Fraction result = new Fraction(numenatorA + numenatorB, denominatorA);

            result.Reduce();

            return result;
        }

        public Fraction Difference(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                Fraction res = new Fraction(numenator - fraction.numenator, denominator);
                res.Reduce();
                return res;
            }

            var numenatorA = numenator * (numenator * fraction.denominator);
            var denominatorA = denominator * (numenator * fraction.denominator);

            var numenatorB = fraction.numenator * (fraction.numenator * denominator);

            Fraction result = new Fraction(numenatorA - numenatorB, denominatorA);

            result.Reduce();

            return result;
        }

    }
}
