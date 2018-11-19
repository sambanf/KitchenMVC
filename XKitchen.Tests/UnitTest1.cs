using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XKitchen.DataModel;

namespace XKitchen.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCategory()
        {
            using (var db = new KitchenContext())
            {
                Trace.WriteLine("--- Starting Category Testing ");
                Categories cat = new Categories()
                {
                    initial = "MC",
                    Name = "Main Course",
                    Active = true,
                    CreateBy = "Bloobloo",
                    CreateDate = DateTime.Now
                };
                db.Mst_Category.Add(cat);
                cat = new Categories()
                {
                    initial = "Dr",
                    Name = "Drink",
                    Active = true,
                    CreateBy = "Bloobloo",
                    CreateDate = DateTime.Now
                };
                db.Mst_Category.Add(cat);
                db.SaveChanges();
                foreach (var category in db.Mst_Category.ToList())
                {
                    Trace.WriteLine(category.Name);
                }
                Trace.WriteLine("--- Ending Category Testing ");
            }

        }
        [TestMethod]
        public void TestTables()
        {
            using (var db = new KitchenContext())
            {
                Trace.WriteLine("--- Starting Table Testing ");
                foreach (var tables in db.Mst_Table.ToList())
                {
                    Trace.WriteLine(tables.initial);
                }
                Trace.WriteLine("--- Ending Table Testing ");
            }

        }
    }
}
