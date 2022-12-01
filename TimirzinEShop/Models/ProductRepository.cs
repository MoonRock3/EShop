using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.DB_Context;

namespace TimirzinEShop.Models
{
    public static class ProductRepository
    {
        //readonly List<Product> _products;
        public static List<ProductView> GetAll()
        {
            List<ProductView> products = null;
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    products = context.ProductViews?.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products ?? new List<ProductView>();
        }
        public static DetailedProduct GetDetailedById(int id)
        {
            List<ProductAttributesView> prodAttrs = null;
            DetailedProduct detailedProduct = null;
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    prodAttrs = context.ProductAttributesViews.Where(x => x.ProductArticle == id)?.ToList() 
                        ?? new List<ProductAttributesView>();
                    detailedProduct = new DetailedProduct(prodAttrs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DetailedProduct();
            }
            return detailedProduct ?? new DetailedProduct();
        }
        public static ProductView GetViewById(int id)
        {
            ProductView toReturn = null;
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    toReturn = context.ProductViews.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return toReturn ?? new ProductView();
        }
        public static List<HtmlOption> GetCommonFilterValuesList(FilterType type)
        {
            List<HtmlOption> htmlOptions = new List<HtmlOption>();
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    List<string> propValsList = type switch
                    {
                        FilterType.Brand => context.ProductViews.Select(x => x.Brand).ToList(),
                        FilterType.CategoryName => context.ProductViews.Select(x => x.CategoryName).ToList(),
                        FilterType.Country => context.ProductViews.Select(x => x.Country).ToList(),
                        _ => new List<string>(),
                    };
                    propValsList = propValsList.Distinct().ToList();
                    for (int i = 0; i < propValsList.Count; i++)
                    {
                        string item = propValsList[i];
                        htmlOptions.Add(
                            new HtmlOption
                            {
                                Text = item,
                                Value = $"value{i}"
                            }
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return htmlOptions;
        }
    }
}
