using System;
using System.Collections.Generic;
using TimirzinEShop.DB_Context;

namespace TimirzinEShop.Models
{
    public class DetailedProduct
    {
        public ProductView ProductView { get; }
        public Dictionary<string, string> attrVals { get; } = new Dictionary<string, string>();
        public DetailedProduct()
        {
            ProductView = new ProductView();
        }
        public DetailedProduct(List<ProductAttributesView> list)
        {
            if (!(list == null || list.Count == 0))
            {
                var view = list[0];
                ProductView = new ProductView
                {
                    Id = view.Id,
                    Brand = view.ProductBrand,
                    Price = view.ProductPrice,
                    CategoryName = view.CategoryName,
                    Description = view.ProductDescription,
                    Image = view.ProductImage,
                    Country = view.ProductCountry,
                    Model = view.ProductModel
                };
                foreach (var item in list)
                {
                    attrVals.Add(
                        item.AttributeName,
                        (item.AttributeInt?.ToString() ??
                        item.AttributeString ??
                        BoolToStr(item.AttributeBool) ??
                        item.AttributeFloat?.ToString() ??
                        "нет информации") +
                        ((" " + item.AttributeUnits) ?? ""));
                }
            }
            else
            {
                ProductView = new ProductView();
            }
        }

        private string BoolToStr(bool? attributeBool)
        {
            switch (attributeBool)
            {
                case null:
                    return null;
                case true:
                    return "Есть";
                case false:
                    return "Нет";
            }
        }
    }
}
