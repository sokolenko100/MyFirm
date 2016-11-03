using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirm.ViewModelComponent;

namespace MyFirm.Model
{
    public partial class Tasks : IDisposable
    {
        static MyFirmEntiti dbContecst;
        public static List<Tasks> ReturnAllTasksAsList()
        {
            using (dbContecst = new MyFirmEntiti())
            {
                return dbContecst.Tasks.ToList();
            }
        }
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
        public static object ReturnEmployeeNameAndSurName(object orderObj)
        {
            MyFirmEntiti dbContecst;
            object collection;
            var tasks = (Tasks)orderObj;
            using (dbContecst = new MyFirmEntiti())
            {
                collection = dbContecst.Tasks.Where(task => task.task_id == tasks.task_id).FirstOrDefault(x => x.task_id == tasks.task_id).Employees.emp_name;
                collection += " ";
                collection+=dbContecst.Tasks.Where(task => task.task_id == tasks.task_id).FirstOrDefault(x => x.task_id == tasks.task_id).Employees.emp_surName; 
            }
            return collection;
        }
        public static Employees ReturnByEmp(string name)
        {
            using (dbContecst = new MyFirmEntiti())
            {
                return dbContecst.Tasks.Where(empl => empl.task_name == name).FirstOrDefault().Employees;
            }

            return null;
        }
        public static int ReturnPositionEmployee(List<Employees> employeeList, Tasks tasks)
        {
            Employees _employee;
            int position;
            using (dbContecst = new MyFirmEntiti())
            {
                _employee = dbContecst.Employees.Where(emp => emp.emp_id == tasks.emp_id).FirstOrDefault();
            }
            for (position = 0; position < employeeList.Count; position++)
            {
                if (_employee.emp_id==employeeList[position].emp_id)
                {
                    return position;
                }
            }
            return 0;
        }
        public IQueryable<Tasks> GetByID(int id)
        {
            dbContecst = new MyFirmEntiti();
            var customer = dbContecst.Tasks.Where(cust => cust.task_id == id);
            return customer;
        }
        public void Add(Tasks entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    if (( TasksViewModel.SelectedItemTasks != null)&&(!TasksViewModel.IsAdd))
                    {
                        var task = dbContecst.Tasks.Where(tasks => tasks.task_id == TasksViewModel.SelectedItemTasks.task_id).FirstOrDefault();
                        task.task_name = entity.task_name;
                        task.task_status = entity.task_status;
                        task.task_dateils = entity.task_dateils;
                        task.task_date = entity.task_date;
                        task.emp_id = entity.Employees.emp_id;

                        dbContecst.SaveChanges();
                    }
                    else
                    {
                        dbContecst.Tasks.Add(entity);
                        dbContecst.SaveChanges(); 
                    }
                }

            }
        }
        public static void Delete(Tasks entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    Tasks custom = dbContecst.Tasks.Where(cust => cust.task_id == entity.task_id).FirstOrDefault();
                    dbContecst.Tasks.Remove(custom);
                    dbContecst.SaveChanges();
                }
            }
        }
    }
}
