using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using MyFirm.ViewModelComponent;
namespace MyFirm.Model
{
    public partial class Customers : IDisposable
    {
        static MyFirmEntiti dbContecst;
        //Return all Customers
        public static List<Customers> GetAll()
        {
            using (dbContecst = new MyFirmEntiti())
            {
                return dbContecst.Customers.ToList();
            }
        }
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
        //Return all Customers by Id
        public IQueryable<Customers> GetByID(int id)
        {
            dbContecst = new MyFirmEntiti();
            return dbContecst.Customers.Where(cust => cust.cust_id == id);
        }
        //Add Customers at dateBase
        public void Add(Customers entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    if (!(CustomersViewModel.IsAdd) && (CustomersViewModel.SelectedItemCustomers!=null))
                    {
                        var customer = dbContecst.Customers.Where(custom => custom.cust_id == CustomersViewModel.SelectedItemCustomers.cust_id).FirstOrDefault();
                        customer.cust_name = entity.cust_name;
                        customer.cust_surName = entity.cust_surName;
                        customer.cust_dateBirth = entity.cust_dateBirth;
                        customer.cust_address = entity.cust_address;
                        customer.cust_email = entity.cust_email;
                        customer.cust_phone = entity.cust_phone;
                        dbContecst.SaveChanges();
                    }
                    else
                    {
                        dbContecst.Customers.Add(entity);
                        dbContecst.SaveChanges();
                    }
           
                }
            }
        }
        public static void Delete(Customers entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    Customers custom = dbContecst.Customers.Where(cust => cust.cust_id == entity.cust_id).FirstOrDefault();
                    dbContecst.Customers.Remove(custom);
                    dbContecst.SaveChanges();

                }
            }
        }
    }
}
