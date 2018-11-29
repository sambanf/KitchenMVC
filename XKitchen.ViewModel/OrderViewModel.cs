using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.ViewModel
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            quantity = 1;
            status = 0; //0 = Reserved
            Active = true;
        }
        public int id { get; set; }

        public int reservid { get; set; }

        public int productid { get; set; }
        [Display(Name ="Product")]
        public string productname { get; set; }
        [Display(Name = "Price")]
        public decimal price { get; set; }
        [Display(Name = "Qty")]
        public int quantity { get; set; }

        public decimal Amount {
            get
            {
                return price * quantity;
            }
            set
            {

            }
        }
        public int status { get; set; }

        

        public bool Active { get; set; }
    }
}
