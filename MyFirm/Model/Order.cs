using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirm.ViewModelComponent;
using MyFirm.AddViewModel;
namespace MyFirm.Model
{
    public partial class Orders : IDisposable
    {
        static MyFirmEntiti dbContecst;

        public static void ReturnWithCustomersOrdersID(int id)
        {
            using (dbContecst = new MyFirmEntiti())
            {
                dbContecst.CustomersOrders.Where(cust_order => cust_order.cust_id == id);
            }
        }
        public static List<Orders> ReturnAllOrdersAsList()
        {
            List<Orders> listCustomers = new List<Orders>();
            using (dbContecst = new MyFirmEntiti())
            {
                List<Orders> _customers = dbContecst.Orders.ToList();
                return _customers;
            }
        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
        public IQueryable<Orders> GetByID(int id)
        {
            dbContecst = new MyFirmEntiti();

            var orders = dbContecst.Orders.Where(order => order.order_id == id);
            return orders;
        }
        public void Add(Orders entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    // for edit employee
                    if ((!OrdersViewModel.IsAdd) && OrdersViewModel.SelectedItemOrders != null && AddOrdersViewModel.StaticSelectedElementProducts != null && AddOrdersViewModel.SelectedElementCustomersStatic != null)
                    {
                        var orders = dbContecst.Orders.Where(order => order.order_id == OrdersViewModel.SelectedItemOrders.order_id).FirstOrDefault();
                        orders.order_dateils = entity.order_dateils;
                        orders.order_date = entity.order_date;
                        orders.order_status = entity.order_status;
                        orders.order_prodCount = entity.order_prodCount;
                        var customer = dbContecst.Customers.Where(custId => custId.cust_id == AddOrdersViewModel.SelectedElementCustomersStatic.cust_id).FirstOrDefault();
                        var product = dbContecst.Products.Where(prodId => prodId.prod_id == AddOrdersViewModel.StaticSelectedElementProducts.prod_id).FirstOrDefault();
                        var custOrder = dbContecst.CustomersOrders.Where(custOrd => custOrd.order_id == orders.order_id).FirstOrDefault();
                        var ordersProducts = dbContecst.OrdersProducts.Where(ordersProd => ordersProd.order_id == orders.order_id).FirstOrDefault();
                        custOrder.cust_id = customer.cust_id;
                        ordersProducts.prod_id = product.prod_id;
                        dbContecst.SaveChanges();
                    }
                        //for add employee
                    else
                    {
                        dbContecst.Orders.Add(entity);
                        dbContecst.SaveChanges();
                        var customer = dbContecst.Customers.Where(custId => custId.cust_id == AddOrdersViewModel.SelectedElementCustomersStatic.cust_id).FirstOrDefault();
                        var product = dbContecst.Products.Where(prodId => prodId.prod_id == AddOrdersViewModel.StaticSelectedElementProducts.prod_id).FirstOrDefault();
                        CustomersOrders custOrder = new CustomersOrders();
                        OrdersProducts ordersProducts = new OrdersProducts();
                        custOrder.cust_id = customer.cust_id;
                        ordersProducts.prod_id = product.prod_id;
                        var ord = dbContecst.Orders.ToList().Last();
                        custOrder.order_id = ord.order_id;
                        ordersProducts.order_id = ord.order_id;
                        dbContecst.OrdersProducts.Add(ordersProducts);
                        dbContecst.CustomersOrders.Add(custOrder);
                        dbContecst.SaveChanges();

                        // For catct exception of System.Data.Entity.Validation.DbEntityValidationException
                        //try
                        //{
                        //    dbContecst.Orders.Add(entity);
                        //    dbContecst.SaveChanges();
                        //}
                        //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                        //{
                        //    Exception raise = dbEx;
                        //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                        //    {
                        //        foreach (var validationError in validationErrors.ValidationErrors)
                        //        {
                        //            string message = string.Format("{0}:{1}",
                        //                validationErrors.Entry.Entity.ToString(),
                        //                validationError.ErrorMessage);
                        //            // raise a new exception nesting
                        //            // the current instance as InnerException
                        //            raise = new InvalidOperationException(message, raise);
                        //        }
                        //    }
                        //    throw raise;
                        //}
                    }

                }

            }
        }
        public static void Delete(Orders entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    Orders orders = dbContecst.Orders.Where(order => order.order_id == entity.order_id).FirstOrDefault();
                    dbContecst.Orders.Remove(orders);
                    dbContecst.SaveChanges();
                }
            }
        }
    }
}
