using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XKitchen.Repository;
using XKitchen.ViewModel;

namespace XKitchen.MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(StudentRepo.All());
        }
        public ActionResult List()
        {
            return PartialView("_List", StudentRepo.All());
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            ResponResultViewModel result = StudentRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", StudentRepo.GetStudent(id));
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            ResponResultViewModel result = StudentRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", StudentRepo.GetStudent(id));
        }

        [HttpPost]
        public ActionResult Delete(StudentViewModel model)
        {
            ResponResultViewModel result = StudentRepo.Delete(model.id);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}