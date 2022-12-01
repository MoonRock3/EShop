using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.Controllers;
using TimirzinEShop.DB_Context;

namespace TimirzinEShop.Models
{
    public class IndexParams
    {
        public IndexParams(List<ProductView> productViews, DisplayOptions displayOptions)
        {
            ProductViews = productViews;
            DisplayOptions = displayOptions;
        }

        public List<ProductView> ProductViews { get; }
        public DisplayOptions DisplayOptions { get; }
    }
}
