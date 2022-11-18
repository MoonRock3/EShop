using System;
using System.Collections.Generic;

#nullable disable

namespace TimirzinEShop.DB_Context
{
    public partial class ProductView
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }
        public string Model { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductView view &&
                   Id == view.Id;
        }
    }
}
