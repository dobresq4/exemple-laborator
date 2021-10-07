using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_DobrescuAndrei.Domain
{
    public record UnvalidatedShoppingCart(string Quantity, string ProductCode, string Address);
}
