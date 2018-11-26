using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XKitchen.Repository;
using XKitchen.ViewModel;

namespace XKitchen.MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(ProductRepo.All());
        }

        public ActionResult List()
        {
            return PartialView("_List", ProductRepo.All());
        }
        public ActionResult Create()
        {
            ViewBag.Categorylist = new SelectList(CategoryRepo.All(),"id","name");
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            ResponResultViewModel result = ProductRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categorylist = new SelectList(CategoryRepo.All(), "id", "name");
            return PartialView("_Edit", ProductRepo.GetProduct(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            ResponResultViewModel result = ProductRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", ProductRepo.GetProduct(id));
        }
        [HttpPost]
        public ActionResult Delete(ProductViewModel model)
        {
            ResponResultViewModel result = ProductRepo.Delete(model.id);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}