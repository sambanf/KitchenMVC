using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.DataModel
{
    [Table("Tables")]
    public class Tables : BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(10), Required]
        public string initial { get; set; }

        public int Seat { get; set; }

        [Column(TypeName = "varchar"), MaxLength(100), Required]
        public string Desc { get; set; }

        public bool Active { get; set; }

    }
}
