using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XKitchen.DataModel;
using XKitchen.ViewModel;

namespace XKitchen.Repository
{
    public class StudentRepo
    {
        public static List<StudentViewModel> All()
        {
            List<StudentViewModel> result = new List<StudentViewModel>();
            using (var db = new KitchenContext())
            {
                result = (from c in db.Students
                          orderby c.firstname
                          select new StudentViewModel
                          {
                              id = c.id,
                              firstname = c.firstname,
                              lastname = c.lastname,
                              fullname = c.firstname + " " + c.lastname,
                              gender = c.gender,
                              gendername = c.gender.ToUpper() == "M" ? "Male" : "Female",
                              dob = c.dob,
                              pob =c.pob,
                              Active = c.Active
                          }).ToList();
            }
            return result;
        }

        public static ResponResultViewModel Update(StudentViewModel entity)
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
                        Student st = new Student();
                        st.firstname = entity.firstname;
                        st.lastname = entity.lastname;
                        st.gender = entity.gender;
                        st.dob = entity.dob;
                        st.pob = entity.pob;
                        st.Active = entity.Active;

                        st.CreateBy = "Blobloblo";
                        st.CreateDate = DateTime.Now;

                        db.Students.Add(st);
                        db.SaveChanges();

                        result.Entity = st;
                    }
                    //Edit
                    else
                    {
                        Student st = db.Students.Where(o => o.id == entity.id).FirstOrDefault();
                        if (st != null)
                        {
                            st.firstname = entity.firstname;
                            st.lastname = entity.lastname;
                            st.gender = entity.gender;
                            st.dob = entity.dob;
                            st.pob = entity.pob;
                            st.Active = entity.Active;


                            st.ModifyBy = "Booboo";
                            st.ModifyDate = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Student not Found!";
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
        public static StudentViewModel GetStudent(int id)
        {
            StudentViewModel result = new StudentViewModel();
            using (var db = new KitchenContext())
            {
                result = (from c in db.Students
                          where c.id == id
                          select new StudentViewModel
                          {
                              id = c.id,
                              firstname = c.firstname,
                              lastname = c.lastname,
                              gender = c.gender,
                              dob = c.dob,
                              pob = c.pob,
                              Active = c.Active
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new StudentViewModel();
                }
            }
            return result;
        }

        public static ResponResultViewModel Delete(int id)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new KitchenContext())
                {
                    Student st = db.Students.Where(x => x.id == id).FirstOrDefault();

                    if (st != null)
                    {
                        result.Entity = st;
                        db.Students.Remove(st);
                        db.SaveChanges();
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Students not found";
                    }
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
