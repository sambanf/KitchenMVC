using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XKitchen.Repository;
using XKitchen.ViewModel;

namespace XKitchen.MVC.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View(TableRepo.All());
        }

        public ActionResult GetByTable(int id)
        {
            return PartialView("_GetByTable", ReservationRepo.GetByTable(id));
        }

        public ActionResult ProductList()
        {
            return PartialView("_ProductList", ProductRepo.All());
        }
        public ActionResult GetSelectedTable(int id)
        {
            ReservationVIewModel model = ReservationRepo.GetByTable(id);
            return Json(new
            {
                success = model.id == 0 ? false : true,
                entity = model
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create(int id)
        {
            //id = table id
            ReservationVIewModel model = new ReservationVIewModel()
            {
                tableid = id
            };
            return PartialView("_Create", model);
        }

        [HttpPost]
        public ActionResult Create(ReservationVIewModel model)
        {
            ResponResultViewModel respon = ReservationRepo.Update(model);
            return Json(new
            {
                success = respon.Success,
                message = respon.Message,
                entity = respon.Entity
            }, JsonRequestBehavior.AllowGet);
        }

    }
}