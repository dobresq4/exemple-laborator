using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_DobrescuAndrei.Domain
{
    public record Quantity
    {
        public int Value { get; }

        public Quantity(int value)
        {
            if (value > 0)
            {
                Value = value;
            }
            else
            {
                throw new InvalidQuantityException($"{value} is an invalid quantity value.");
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
