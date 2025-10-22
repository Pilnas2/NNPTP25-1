using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPTPZ1
{
    public class ComplexNumber
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                ComplexNumber x = obj as ComplexNumber;
                return x.RealPart == RealPart && x.ImaginaryPart == ImaginaryPart;
            }
            return base.Equals(obj);
        }

        public readonly static ComplexNumber ZeroValue = new ComplexNumber()
        {
            RealPart = 0,
            ImaginaryPart = 0
        };

        public ComplexNumber Multiply(ComplexNumber complexNumberToMultiply)
        {
            return new ComplexNumber()
            {
                RealPart = this.RealPart * complexNumberToMultiply.RealPart - this.ImaginaryPart * complexNumberToMultiply.ImaginaryPart,
                ImaginaryPart = this.RealPart * complexNumberToMultiply.ImaginaryPart + this.ImaginaryPart * complexNumberToMultiply.RealPart
            };
        }
        public double GetAbsoluteValue()
        {
            return Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
        }

        public ComplexNumber Add(ComplexNumber complexNumberToAdd)
        {
            return new ComplexNumber()
            {
                RealPart = this.RealPart + complexNumberToAdd.RealPart,
                ImaginaryPart = this.ImaginaryPart + complexNumberToAdd.ImaginaryPart
            };
        }
        public double GetAngleInDegrees()
        {
            return Math.Atan2(ImaginaryPart, RealPart) * (180 / Math.PI);
        }
        public ComplexNumber Subtract(ComplexNumber complexNumberToSubtract)
        {
            return new ComplexNumber()
            {
                RealPart = this.RealPart - complexNumberToSubtract.RealPart,
                ImaginaryPart = this.ImaginaryPart - complexNumberToSubtract.ImaginaryPart
            };
        }

        public override string ToString()
        {
            return $"({RealPart} + {ImaginaryPart}i)";
        }

        internal ComplexNumber Divide(ComplexNumber complexNumberToDivide)
        {

            if (complexNumberToDivide.RealPart == 0 && complexNumberToDivide.ImaginaryPart == 0)
                throw new DivideByZeroException("Cannot divide by zero complex number.");


            var conjugate = new ComplexNumber
            {
                RealPart = complexNumberToDivide.RealPart,
                ImaginaryPart = -complexNumberToDivide.ImaginaryPart
            };

            var numerator = this.Multiply(conjugate);
            var denominator = complexNumberToDivide.RealPart * complexNumberToDivide.RealPart + complexNumberToDivide.ImaginaryPart * complexNumberToDivide.ImaginaryPart;

            return new ComplexNumber
            {
                RealPart = numerator.RealPart / denominator,
                ImaginaryPart = numerator.ImaginaryPart / denominator
            };
        }
    }
}
