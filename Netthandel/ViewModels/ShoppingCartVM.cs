using Netthandel.Models;

namespace Netthandel.ViewModels;

public class ShoppingCartVM
{
    public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
    public double OrderTotal { get; set; }
}