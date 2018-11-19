using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.ViewModel
{
    public class CategoryViewModel
    {
        public int id { get; set; }

        [MaxLength(10), Required]
        public string initial { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
