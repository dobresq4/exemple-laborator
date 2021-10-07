using System.Text.RegularExpressions;

namespace Lab1_DobrescuAndrei.Domain
{
    public record ValidatedShoppingCart(string Quantity, string ProductCode, string Address);
}
