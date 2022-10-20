using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimirzinEShop.Models
{
    public class Product
    {
        public Product()
        {

        }
        public Product(int id, string brand, string description, int price, string image, string country, string category, string model)
        {
            Id = id;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price;
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }

        public override string ToString() => Brand + " " + Model;
    }
}
