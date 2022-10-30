using System;
using System.Collections.Generic;

#nullable disable

namespace TimirzinEShop.DB_Context
{
    public partial class ProductAttributesView
    {
        public int Id { get; set; }
        public int ProductArticle { get; set; }
        public string ProductBrand { get; set; }
        public double ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string ProductCountry { get; set; }
        public string ProductModel { get; set; }
        public string AttributeName { get; set; }
        public string AttributeUnits { get; set; }
        public int? AttributeInt { get; set; }
        public string AttributeString { get; set; }
        public bool? AttributeBool { get; set; }
        public double? AttributeFloat { get; set; }
    }
}
