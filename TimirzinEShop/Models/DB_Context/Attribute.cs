using System;
using System.Collections.Generic;

#nullable disable

namespace TimirzinEShop.DB_Context
{
    public partial class Attribute
    {
        public Attribute()
        {
            CategoryAttributes = new HashSet<CategoryAttribute>();
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        public string DataType { get; set; }

        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
