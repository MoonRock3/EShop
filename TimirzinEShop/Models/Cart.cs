using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.DB_Context;

namespace TimirzinEShop.Models
{
    [Serializable]
    public class Cart
    {
        public List<CartItem> Products { get; set; } = new List<CartItem>();
        public Cart()
        {
        }
        public Cart(Cart original)
        {
            Products = new List<CartItem>(original.Products);
        }
        public void AddProduct(ProductView productV)
        {
            if (Products.Any(x => x.Product.Equals(productV)))
            {
                Products.FirstOrDefault(x => x.Product.Equals(productV)).IncreaseNum();
            }
            else
            {
                CartItem cartItem = new CartItem(productV);
                Products.Add(cartItem);
            }
        }
        public void Delete(ProductView productV)
        {
            Products.Remove(Products.FirstOrDefault(x => x.Product.Equals(productV)));
        }
        public void SetNumber(ProductView productV, int number)
        {
            if (Products.Any(x => x.Product.Equals(productV)))
            {
                Products.FirstOrDefault(x => x.Product.Equals(productV)).Number = number;
            }
            else
            {
                CartItem cartItem = new CartItem(productV);
                cartItem.Number = number;
                Products.Add(cartItem);
            }
        }
        public int GetTotalNumber()
        {
            int toReturn = 0;
            foreach (var item in Products)
                toReturn += item.Number;
            return toReturn;
        }
        public double GetTotalCost()
        {
            double toReturn = 0;
            foreach (var item in Products)
                toReturn += item.GetCost();
            return toReturn;
        }
    }
}
