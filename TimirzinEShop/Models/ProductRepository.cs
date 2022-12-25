using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimirzinEShop.Areas.Identity.Data;
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

        public static List<HtmlOption> GetCategoryFilterValuesList(string category, string filterType)
        {
            List<HtmlOption> options = new List<HtmlOption>();
            string dataType = GetAttributeDataType(filterType);
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    List<string> atributes;
                    switch (dataType)
                    {
                        case "string":
                            atributes = context.ProductAttributesViews
                                .Where(x => x.CategoryName.Equals(category) && x.AttributeName.Equals(filterType))
                                .Select(x => x.AttributeString).Distinct().ToList();
                            break;
                        case "bool":
                            atributes = new List<string>();
                            atributes.Add("Есть");
                            atributes.Add("Нет");
                            break;
                        default:
                            atributes = new List<string>();
                            options.Add(new HtmlOption
                            {
                                Text = "",
                                Value = "notStringOrBool"
                            });
                            break;
                    }
                    foreach (var item in atributes)
                    {
                        options.Add(new HtmlOption
                        {
                            Text = item,
                            Value = "value0"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return options ?? new List<HtmlOption>();
        }

        public static EShopUser FindUserByName(string name)
        {
            try
            {
                using (EShopUserContext context = new EShopUserContext(new Microsoft.EntityFrameworkCore.DbContextOptions<EShopUserContext>()))
                {
                    return context.Users.FirstOrDefault(x => x.UserName.Equals(name));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static string GetAttributeDataType(string attrName)
        {
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    return context.Attributes.FirstOrDefault(x => x.Name.Equals(attrName))?.DataType;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static List<HtmlOption> GetCategoryFilterTypesList(string category)
        {
            List<HtmlOption> options = new List<HtmlOption>();
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    var atributes = context.CategoryAttributesViews.Where(x => x.CategoryName.Equals(category)).Select(x => x.AttributeName).ToList();
                    foreach (var item in atributes)
                    {
                        options.Add(new HtmlOption
                        {
                            Text = item,
                            Value = "value0"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return options ?? new List<HtmlOption>();
        }

        public static List<ProductView> FilterByCategoryAttribute(List<ProductView> productViews, string dataType, string category, string attrName, string select, double min, double max)
        {
            List<int> articles = new List<int>();
            List<ProductView> toReturn = new List<ProductView>();
            try
            {
                using (Timirzin_AS51Context context = new Timirzin_AS51Context())
                {
                    switch (dataType)
                    {
                        case "string":
                            articles = context.ProductAttributesViews
                                .Where(x => x.CategoryName.Equals(category) && x.AttributeName.Equals(attrName) && x.AttributeString.Equals(select))
                                .Select(x => x.ProductArticle).ToList();
                        break;
                        case "bool":
                            bool boolValue;
                            if (select.Equals("Нет"))
                            {
                                boolValue = false;
                            }
                            else
                            {
                                boolValue = true;
                            }
                            articles = context.ProductAttributesViews
                                .Where(x => x.CategoryName.Equals(category) && x.AttributeName.Equals(attrName) && x.AttributeBool.Equals(boolValue))
                                .Select(x => x.ProductArticle).ToList();
                            break;
                        case "int":
                            articles = context.ProductAttributesViews
                                .Where(x => x.CategoryName.Equals(category) && x.AttributeName.Equals(attrName) && 
                                x.AttributeInt >= min && x.AttributeInt <= max)
                                .Select(x => x.ProductArticle).ToList();
                            break;
                        case "float":
                            articles = context.ProductAttributesViews
                                .Where(x => x.CategoryName.Equals(category) && x.AttributeName.Equals(attrName) &&
                                x.AttributeFloat >= min && x.AttributeFloat <= max)
                                .Select(x => x.ProductArticle).ToList();
                            break;
                        default:
                            break;
                    }
                }
                foreach (var item in articles)
                {
                    var toAdd = productViews.FirstOrDefault(x => x.Id == item);
                    if (toAdd is not null)
                    {
                        toReturn.Add(toAdd); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return toReturn;
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
                        FilterType.CategoryName => context.Categories.Select(x => x.Name).ToList(),
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
