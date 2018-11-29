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

        public string tableinit { get; set; }
        public string tabledesc { get; set; }
        [Display(Name = "Table Info")]
        public string tblinitdesc
        {
            get
            {
                return tableinit + " - " + tabledesc; 
            }
        }
        [Display(Name = "Reference")]
        [StringLength(20)]
        public string reference { get; set; }

        [Display(Name = "Guest")]
        [Required]
        [StringLength(50)]
        public string guest { get; set; }

        public bool Paid { get; set; }
        public bool Active { get; set; }

    }
}
