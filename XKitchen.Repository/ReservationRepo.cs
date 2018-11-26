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
                          where r.tableid == tableid
                          select new ReservationVIewModel
                          {
                              id = r.id,
                              tableid = r.tableid,
                              reference = r.reference,
                              guest = r.guest,
                              Active = r.Active
                          }).FirstOrDefault();

                return result == null ? result = new ReservationVIewModel() : result;
            }
        }
    }
}
