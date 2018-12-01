using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XKitchen.ViewModel;
using XKitchen.DataModel;

namespace XKitchen.Repository
{
    public class ReservationRepo
    {
        public static ResponResultViewModel Update(ReservationVIewModel entity)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            entity.reference = GerReff();
            try
            {
                using (var db = new KitchenContext())
                {
                    if (entity.id == 0)
                    {
                        Reservation reserv = new Reservation();
                        reserv.guest = entity.guest;
                        reserv.reference = entity.reference;
                        reserv.tableid = entity.tableid;
                        reserv.Paid = false;
                        reserv.CreateBy = "Floofloo";
                        reserv.CreateDate = DateTime.Now;
                        reserv.Active = true;
                        db.Reservations.Add(reserv);
                        db.SaveChanges();
                        result.Entity = entity;
                    }
                    else
                    {
                        Reservation reserv = db.Reservations.Where(r => r.id == entity.id).FirstOrDefault();
                        reserv.guest = entity.guest;

                        reserv.ModifyBy = "BlubluRese";
                        reserv.ModifyDate = DateTime.Now;

                        db.SaveChanges();

                        result.Entity = entity;
                    }
                }
            }
            catch (Exception ee)
            {
                result.Success = false;
                result.Message = ee.Message;
            }
            return result;
        }

        public static string GerReff()
        {
            string yearmonth = DateTime.Now.ToString("yy") + DateTime.Now.Month.ToString("D2");
            string newref = String.Format("RSV-{0}-", yearmonth);
            using (var db = new KitchenContext())
            {
                var result = (from r in db.Reservations
                              where r.reference.Contains(newref)
                              select new { reference = r.reference })
                              .OrderByDescending(o => o.reference).FirstOrDefault();
                if (result != null)
                {
                    string[] lastreff = result.reference.Split('-');
                    newref += ((int.Parse(lastreff[2])) + 1).ToString("D4");

                }
                else
                {
                    newref += "0001";
                }
            }
            return newref;
        }

        public static ReservationVIewModel GetByTable(int tableid)
        {
            ReservationVIewModel result = new ReservationVIewModel();
            using (var db = new KitchenContext())
            {
                result = (from r in db.Reservations
                          join t in db.Tables on
                          r.tableid equals t.id
                          where r.tableid == tableid
                          select new ReservationVIewModel
                          {
                              id = r.id,
                              tableid = r.tableid,
                              tableinit = t.initial,
                              tabledesc = t.Desc,
                              reference = r.reference,
                              Paid = r.Paid,
                              guest = r.guest,
                              Active = r.Active
                          }).FirstOrDefault();

                return result == null ? result = new ReservationVIewModel() : result;
            }
        }
        public static List<OrderViewModel> GetByReserv(int id)
        {
            //id=>reseid
            List<OrderViewModel> result = new List<OrderViewModel>();
            using (var db = new KitchenContext())
            {
                result = (from r in db.Reservations
                          join o in db.Orders on
                          r.id equals o.reservid
                          join p in db.Products on
                          o.productid equals p.id
                          where r.id == id
                          select new OrderViewModel
                          {
                              id = o.id,
                              reservid = r.id,
                              productid = o.productid,
                              productname = p.name,
                              price = o.price,
                              quantity = o.quantity,
                              status = o.status,
                              Active = o.Active
                          }).ToList();
            }
            return result.Count == 0 ? new List<OrderViewModel>() : result;
        }

        public static OrderViewModel GetByProduct(int id)
        {
            //id = prodid
            OrderViewModel result = new OrderViewModel();
            using (var db = new KitchenContext())
            {
                result = (from p in db.Products
                          where p.id == id
                          select new OrderViewModel
                          {
                              productid = p.id,
                              productname = p.name,
                              price = p.price
                          }).FirstOrDefault();
            }
            return result == null ? new OrderViewModel() : result;
        }

        public static ResponResultViewModel WorkFlow(OrderViewModel entity)
        {
            ResponResultViewModel res = new ResponResultViewModel();
            try
            {
                using (var db = new KitchenContext())
                {
                    if (entity.id == 0)
                    {
                        Order ord = new Order();
                        ord.reservid = entity.reservid;
                        ord.productid = entity.productid;
                        ord.quantity = entity.quantity;
                        ord.price = entity.price;
                        ord.status = entity.status +1;

                        ord.Active = true;
                        ord.CreateBy = "OrderBlu";
                        ord.CreateDate = DateTime.Now;

                        db.Orders.Add(ord);
                        db.SaveChanges();

                        res.Entity = ord;
                    }
                    else
                    {
                        Order order = db.Orders.Where(o => o.id == entity.id).FirstOrDefault();
                        if (order == null)
                        {
                            res.Success = false;
                            res.Message = "Ord Not FOund";
                        }
                        else
                        {
                            order.status = order.status + 1;
                            db.SaveChanges();
                            res.Entity = entity;
                        }


                    }
                }
            }
            catch (Exception e)
            {
                res.Success = false;
                res.Message = e.Message;
            }
            return res;
        }
    }
}
