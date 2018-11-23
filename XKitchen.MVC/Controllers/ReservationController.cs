using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XKitchen.Repository;

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
            return PartialView("_GetByTable",ReservationRepo.GetByTable(id));
        }

        public ActionResult ProductList()
        {
            return PartialView("_ProductList", ProductRepo.All());
        }
    }
}