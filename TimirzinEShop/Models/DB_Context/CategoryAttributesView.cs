using System;
using System.Collections.Generic;

#nullable disable

namespace TimirzinEShop.DB_Context
{
    public partial class CategoryAttributesView
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string AttributeName { get; set; }
        public string Units { get; set; }
    }
}
