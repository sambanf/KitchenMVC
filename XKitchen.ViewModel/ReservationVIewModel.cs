using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.ViewModel
{
    public class ReservationVIewModel
    {
        public ReservationVIewModel()
        {
            Active = true;
        }
        public int id { get; set; }

        public int tableid { get; set; }


        [StringLength(20)]
        public string reference { get; set; }

        [Required]
        [StringLength(50)]
        public string guest { get; set; }

        public bool Paid { get; set; }
        public bool Active { get; set; }

    }
}
