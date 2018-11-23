using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.ViewModel
{
    public class OrderViewModel
    {
        public int id { get; set; }

        public int reservid { get; set; }

        public int productid { get; set; }

        public string productname { get; set; }

        public decimal price { get; set; }

        public int status { get; set; }

        public int quantity { get; set; }

        public bool Active { get; set; }
    }
}
