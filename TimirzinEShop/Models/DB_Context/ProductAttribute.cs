using System;
using System.Collections.Generic;

#nullable disable

namespace TimirzinEShop.DB_Context
{
    public partial class ProductAttribute
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public int? IntValue { get; set; }
        public string StringValue { get; set; }
        public bool? BoolValue { get; set; }
        public double? FloatValue { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Product Product { get; set; }
    }
}
