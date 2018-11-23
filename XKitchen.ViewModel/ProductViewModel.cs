using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.ViewModel
{
    public class ProductViewModel
    {
        public int id { get; set; }

        public int categoryid { get; set; }

        [MaxLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(10)]
        public string initial { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }

        public int price { get; set; }

        public bool Active { get; set; }
    }
}
