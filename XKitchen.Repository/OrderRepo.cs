using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XKitchen.DataModel;
using XKitchen.ViewModel;

namespace XKitchen.Repository
{
    public class OrderRepo
    {
        public static List<OrderViewModel> All()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            using (var db = new KitchenContext())
            {
                result = (from o in db.Orders
                          join p in db.Products on o.productid equals p.id
                          join r in db.Reservations on o.reservid equals r.id
                          select new OrderViewModel
                          {
                              id = o.id,
                              reservid = r.id,
                              productid = p.id,
                              price = p.price,
                              status = o.status,
                              quantity = o.quantity,
                              Active = o.Active

                          }).ToList();
            }
            return result;

        }
    }
}
