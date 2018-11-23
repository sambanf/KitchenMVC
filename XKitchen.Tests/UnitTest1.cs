using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XKitchen.DataModel;
using XKitchen.Repository;
using XKitchen.ViewModel;

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
                Category cat = new Category()
                {
                    initial = "MC",
                    Name = "Main Course",
                    Active = true,
                    CreateBy = "Bloobloo",
                    CreateDate = DateTime.Now
                };
                db.Categories.Add(cat);
                cat = new Category()
                {
                    initial = "Dr",
                    Name = "Drink",
                    Active = true,
                    CreateBy = "Bloobloo",
                    CreateDate = DateTime.Now
                };
                db.Categories.Add(cat);
                db.SaveChanges();
                foreach (var category in db.Categories.ToList())
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
                foreach (var tables in db.Tables.ToList())
                {
                    Trace.WriteLine(tables.initial);
                }
                Trace.WriteLine("--- Ending Table Testing ");
            }

        }
        [TestMethod]
        public void TestGetCategory()
        {
            Trace.WriteLine("--- Start Get All Category Testing ---");
            List<CategoryViewModel> categories = CategoryRepo.All();
            foreach (var category in categories)
            {
                Trace.WriteLine(category.Name);
            }
            Trace.WriteLine("--- End Get All Category Testing ---");
        }

        [TestMethod]
        public void TestGetRef()
        {

            Trace.WriteLine("--- Start Get All Category Testing ---");
            string newref = ReservationRepo.GerReff();
            Trace.WriteLine(newref);

            string newref2 = ReservationRepo.GerReff();
            Trace.WriteLine(newref2);
            Trace.WriteLine("--- End Get All Category Testing ---");
        }
    }
}
