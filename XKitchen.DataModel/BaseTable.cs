using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.DataModel
{
    public class BaseTable
    {
        [Column(TypeName ="varchar"), MaxLength(50), Required]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
