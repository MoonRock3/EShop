using System;
using System.Collections.Generic;

#nullable disable

namespace TimirzinEShop.DB_Context
{
    public partial class CategoryAttribute
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Category Category { get; set; }
    }
}
