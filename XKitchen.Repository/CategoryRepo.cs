using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XKitchen.DataModel;
using XKitchen.ViewModel;

namespace XKitchen.Repository
{
    public class CategoryRepo
    {
        public static List<CategoryViewModel> All()
        {
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            using (var db = new KitchenContext())
            {
                result = (from c in db.Mst_Category
                          select new CategoryViewModel
                          {
                              id = c.id,
                              initial = c.initial,
                              Name = c.Name,
                              Active = c.Active
                          }).ToList();
            }
            return result;
        }

        public static ResponResultViewModel Update(CategoryViewModel entity)
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
                        Categories category = new Categories();
                        category.initial = entity.initial;
                        category.Name = entity.Name;
                        category.Active = entity.Active;

                        category.CreateBy = "Bloblo";
                        category.CreateDate = DateTime.Now;
                        db.Mst_Category.Add(category);
                        db.SaveChanges();

                        result.Entity = category;
                    }
                    //Edit
                    else
                    {
                        Categories category = db.Mst_Category.Where(o => o.id == entity.id).FirstOrDefault();
                        if (category !=null)
                        {
                            category.initial = entity.initial;
                            category.Name = entity.Name;
                            category.Active = entity.Active;

                            category.ModifyBy = "Booboo";
                            category.ModifyDate = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = category;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Category not Found!";
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
        public static CategoryViewModel GetCategory(int id)
        {
            CategoryViewModel result = new CategoryViewModel();
            using (var db = new KitchenContext())
            {
                result = (from c in db.Mst_Category
                          where c.id == id
                          select new CategoryViewModel
                          {
                              id = c.id,
                              initial = c.initial,
                              Name = c.Name,
                              Active = c.Active
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new CategoryViewModel();
                }
            }
            return result;
        }

    }
}
