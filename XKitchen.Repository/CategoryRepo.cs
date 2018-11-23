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
                result = (from c in db.Categories
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

        public static ResponResultViewModel Delete(int id)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new KitchenContext())
                {
                    Category category = db.Categories.Where(x => x.id == id).FirstOrDefault();

                    if (category != null)
                    {
                        result.Entity = category;
                        db.Categories.Remove(category);
                        db.SaveChanges();
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Category not found";
                    }
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Category memiliki Product, tidak dapat dihapus";
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
                        Category category = new Category();
                        category.initial = entity.initial;
                        category.Name = entity.Name;
                        category.Active = entity.Active;

                        category.CreateBy = "Bloblo";
                        category.CreateDate = DateTime.Now;
                        db.Categories.Add(category);
                        db.SaveChanges();

                        result.Entity = category;
                    }
                    //Edit
                    else
                    {
                        Category category = db.Categories.Where(o => o.id == entity.id).FirstOrDefault();
                        if (category !=null)
                        {
                            category.initial = entity.initial;
                            category.Name = entity.Name;
                            category.Active = entity.Active;

                            category.ModifyBy = "Booboo";
                            category.ModifyDate = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = entity;
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
                result = (from c in db.Categories
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
