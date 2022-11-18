using System;
using System.Collections.Generic;
using TimirzinEShop.DB_Context;

namespace TimirzinEShop.Models
{
    [Serializable]
    public class CartItem
    {
        public CartItem(ProductView product)
        {
            Product = product;
            Number = 1;
        }

        public ProductView Product { get; set; }
        public int Number { get; set; }
        public void IncreaseNum(int value = 1) => Number += value;
        public override bool Equals(object obj)
        {
            return obj is CartItem item &&
                   EqualityComparer<ProductView>.Default.Equals(Product, item.Product);
        }

        public double GetCost() => Product.Price * Number;
    }
}