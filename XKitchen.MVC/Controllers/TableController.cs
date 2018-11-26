using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XKitchen.ViewModel;
using XKitchen.Repository;

namespace XKitchen.MVC.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult Index()
        {
            return View(TableRepo.All());
        }
        public ActionResult List()
        {
            return PartialView("_List",TableRepo.All());
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(TableViewModel model)
        {
            ResponResultViewModel result = TableRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", TableRepo.GetTable(id));
        }

        [HttpPost]
        public ActionResult Edit(TableViewModel model)
        {
            ResponResultViewModel result = TableRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", TableRepo.GetTable(id));
        }

        [HttpPost]
        public ActionResult Delete(TableViewModel model)
        {
            ResponResultViewModel result = TableRepo.Delete(model.id);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}