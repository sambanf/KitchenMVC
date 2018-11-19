using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.DataModel
{
    [Table("Category")]
    public class Categories : BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(10),Required]
        public string initial { get; set; }
        [Column(TypeName = "varchar"), MaxLength(50), Required]
        public string Name { get; set; }

        public bool Active { get; set; }

    }
}
