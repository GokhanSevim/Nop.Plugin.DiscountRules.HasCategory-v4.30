using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.DiscountRules.HasCategory.Models
{
    public class CartModel
    {
        public ShoppingCartItem CartItem { get; set; }

        public IList<ProductCategory> Category { get; set; }
    }
}
