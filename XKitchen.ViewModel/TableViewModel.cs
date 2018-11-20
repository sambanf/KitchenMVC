using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.ViewModel
{
    public class TableViewModel
    {
        public int id { get; set; }

        [Column(TypeName = "varchar"), Required]
        public string initial { get; set; }

        public int Seat { get; set; }

        [Column(TypeName = "varchar"), Required]
        public string Desc { get; set; }

        public bool Active { get; set; }
    }
}
