using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XKitchen.Repository;
using XKitchen.ViewModel;

namespace XKitchen.MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryRepo.All());
        }

        public ActionResult List()
        {
            return PartialView("_List", CategoryRepo.All());
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            ResponResultViewModel result = CategoryRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", CategoryRepo.GetCategory(id));
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            ResponResultViewModel result = CategoryRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}