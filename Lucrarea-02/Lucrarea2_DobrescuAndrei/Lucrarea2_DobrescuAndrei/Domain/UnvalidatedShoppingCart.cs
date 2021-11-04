using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrarea2_DobrescuAndrei.Domain
{
    public record UnvalidatedShoppingCart(ProductCode productCode, Quantity quantity, Address address, Price price);
}
