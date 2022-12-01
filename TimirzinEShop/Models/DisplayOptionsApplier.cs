using System;
using System.Collections.Generic;
using System.Linq;
using TimirzinEShop.Controllers;
using TimirzinEShop.DB_Context;

namespace TimirzinEShop.Models
{
    public class DisplayOptionsApplier
    {
        public DisplayOptionsApplier()
        {
            DisplayOptions = new DisplayOptions();
        }
        public DisplayOptionsApplier(DisplayOptions displayOptions)
        {
            DisplayOptions = displayOptions;
        }

        public DisplayOptions DisplayOptions { get; }

        public void ApplyToList(ref List<ProductView> productViews)
        {
            var sortBy = DisplayOptions.SortBy;
            var isDesc = DisplayOptions.IsDesc;
            switch (sortBy)
            {
                case SortBy.Price:
                    if (!isDesc)
                    {
                        productViews = productViews.OrderBy(x => x.Price).ToList();
                    }
                    else
                    {
                        productViews = productViews.OrderByDescending(x => x.Price).ToList();
                    }
                    break;
                case SortBy.ProductName:
                    if (!isDesc)
                    {
                        productViews = productViews.OrderBy(x => x.GetProductName()).ToList();
                    }
                    else
                    {
                        productViews = productViews.OrderByDescending(x => x.GetProductName()).ToList();
                    }
                    break;
                default:
                    break;
            }
            var search = DisplayOptions.SearchValue;
            if (!string.IsNullOrWhiteSpace(search))
            {
                productViews = productViews.Where(x => x.GetProductName().Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            var commonFilterType = DisplayOptions.CommonFilterType;
            var commonFilterValue = DisplayOptions.CommonFilterValue;
            switch (commonFilterType)
            {
                case FilterType.Brand:
                    productViews = productViews.Where(x => x.Brand.Equals(commonFilterValue)).ToList();
                    break;
                case FilterType.CategoryName:
                    productViews = productViews.Where(x => x.CategoryName.Equals(commonFilterValue)).ToList();
                    break;
                case FilterType.Country:
                    productViews = productViews.Where(x => x.Country.Equals(commonFilterValue)).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}