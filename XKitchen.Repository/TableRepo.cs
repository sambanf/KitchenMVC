﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XKitchen.DataModel;
using XKitchen.ViewModel;

namespace XKitchen.Repository
{
    public class TableRepo
    {
        public static List<TableViewModel> All()
        {
            List<TableViewModel> result = new List<TableViewModel>();
            using (var db = new KitchenContext())
            {
                result = (from d in db.Mst_Table
                          select new TableViewModel
                          {
                              id = d.id,
                              initial = d.initial,
                              Seat = d.Seat,
                              Desc = d.Desc,
                              Active = d.Active

                          }).ToList();
            }
            return result;
        }
        public static ResponResultViewModel Update(TableViewModel entity)
        {
            //Untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new KitchenContext())
                {
                    //Create
                    if (entity.id == 0)
                    {
                        Tables table = new Tables();
                        table.initial = entity.initial;
                        table.Seat = entity.Seat;
                        table.Desc = entity.Desc;
                        table.Active = entity.Active;

                        table.CreateBy = "Bloblo";
                        table.CreateDate = DateTime.Now;
                        db.Mst_Table.Add(table);
                        db.SaveChanges();

                        result.Entity = table;
                    }
                    //Edit
                    else
                    {
                        Tables table = db.Mst_Table.Where(o => o.id == entity.id).FirstOrDefault();
                        if (table != null)
                        {
                            table.initial = entity.initial;
                            table.Seat = entity.Seat;
                            table.Desc = entity.Desc;
                            table.Active = entity.Active;

                            table.ModifyBy = "Booboo";
                            table.ModifyDate = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = table;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "table not Found!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = ex.Message;
            }
            return result;

        }
        public static TableViewModel GetTable(int id)
        {
            TableViewModel result = new TableViewModel();
            using (var db = new KitchenContext())
            {
                result = (from d in db.Mst_Table
                          where d.id == id
                          select new TableViewModel
                          {
                              id = d.id,
                              initial = d.initial,
                              Seat = d.Seat,
                              Desc = d.Desc,
                              Active = d.Active
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new TableViewModel();
                }
            }
            return result;
        }


    }
}
