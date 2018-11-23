using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XKitchen.DataModel;
using XKitchen.ViewModel;

namespace XKitchen.Repository
{
    public class ProductRepo
    {
        public static List<ProductViewModel> All()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            using (var db = new KitchenContext())
            {
                result = (from d in db.Products
                          join c in db.Categories
                          on d.categoryid equals c.id
                          select new ProductViewModel
                          {
                              id = d.id,
                              initial = d.initial,
                              name = d.name,
                              description = d.description,
                              categoryid = d.categoryid,
                              CategoryName = c.Name,
                              price = d.price,
                              Active = d.Active

                          }).ToList();
            }
            return result;
        }
        public static ResponResultViewModel Update(ProductViewModel entity)
        {
            //Untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new KitchenContext())
                {
                    //Create
                    if (entity.id == 0)
                    {
                        Product product = new Product();
                        product.initial = entity.initial;
                        product.name = entity.name;
                        product.description = entity.description;
                        product.categoryid = entity.categoryid;
                        product.price = entity.price;
                        product.Active = entity.Active;
                        

                        product.CreateBy = "Bloblo";
                        product.CreateDate = DateTime.Now;
                        db.Products.Add(product);
                        db.SaveChanges();

                        result.Entity = product;
                    }
                    //Edit
                    else
                    {
                        Product product = db.Products.Where(o => o.id == entity.id).FirstOrDefault();
                        if (product != null)
                        {
                            product.initial = entity.initial;
                            product.name = entity.name;
                            product.description = entity.description;
                            product.categoryid = entity.categoryid;
                            product.price = entity.price;
                            product.Active = entity.Active;

                            product.CreateBy = "Bloblo";
                            product.CreateDate = DateTime.Now;
                            db.Products.Add(product);
                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "table not Found!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = ex.Message;
            }
            return result;

        }
        public static ProductViewModel GetProduct(int id)
        {
            ProductViewModel result = new ProductViewModel();
            using (var db = new KitchenContext())
            {
                result = (from d in db.Products
                          join c in db.Categories on d.categoryid equals c.id
                          where d.id == id
                          select new ProductViewModel
                          {
                              id = d.id,
                              initial = d.initial,
                              name = d.name,
                              categoryid = d.categoryid,
                              CategoryName = c.Name,
                              Active = d.Active
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new ProductViewModel();
                }
            }
            return result;
        }

    }
}
