using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.DataModel
{
    public class KitchenContext : DbContext
    {
        public KitchenContext()
        {

        }
        public DbSet<Categories> Mst_Category { get; set; }

        public DbSet<Tables> Mst_Table { get; set; }
    }
}
