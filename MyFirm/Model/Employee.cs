using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using MyFirm.ViewModelComponent;

namespace MyFirm.Model
{
    public partial class Employees : IDisposable
    {

        static MyFirmEntiti dbContecst;
        public static List<Employees> ReturnAllEmployeeAsList()
        {
            using (dbContecst = new MyFirmEntiti())
            {
                return dbContecst.Employees.ToList();
            }
        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        public static Employees ReturnByEmp(string name)
        {
            using (dbContecst = new MyFirmEntiti())
            {
                return dbContecst.Employees.Where(empl => empl.emp_name == name).FirstOrDefault();
            }
        }
        public IQueryable<Employees> GetByID(int id)
        {
            dbContecst = new MyFirmEntiti();
            return dbContecst.Employees.Where(emp => emp.emp_id == id);
        }
        public void Add(Employees entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    if (EmployeeViewModel.IsChanged && EmployeeViewModel.SelectedItemEmployees!=null)
                    {
                        var emp = dbContecst.Employees.Where(empl => empl.emp_id == EmployeeViewModel.SelectedItemEmployees.emp_id).FirstOrDefault();
                        emp.emp_name = entity.emp_name;
                        emp.emp_surName = entity.emp_surName;
                        emp.emp_email = entity.emp_email;
                        emp.emp_dateBirth = entity.emp_dateBirth;
                        emp.emp_phone = entity.emp_phone;
                        emp.emp_login = entity.emp_login;
                        emp.emp_password = entity.emp_password;
                        dbContecst.SaveChanges();
                    }
                    else
                    {
                        dbContecst.Employees.Add(entity);
                        dbContecst.SaveChanges();
                    }
                  
                }

            }
        }
        public static void Delete(Employees entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    Employees custom = dbContecst.Employees.Where(emp => emp.emp_id == entity.emp_id).FirstOrDefault();
                    dbContecst.Employees.Remove(custom);
                    dbContecst.SaveChanges();
                }
            }
        }
    }
}
