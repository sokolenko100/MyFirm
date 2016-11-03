using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirm.Model;
using System.Windows.Data;

namespace MyFirm.Model
{
    public partial class CustomersOrders
    {// Return Object for show it on orderDateGrid by orderObject
        public static object ReturnCustomersOrdersCollection(object orderObj)
        {
            MyFirmEntiti dbContecst;
            object collection;
            var order = (Orders)orderObj;
            using (dbContecst = new MyFirmEntiti())
            { 
                collection = dbContecst.CustomersOrders.Where(ordProd => ordProd.order_id == order.order_id).FirstOrDefault(x => x.order_id == order.order_id).Customers.cust_name;
                collection+=" ";
                collection += dbContecst.CustomersOrders.Where(ordProd => ordProd.order_id == order.order_id).FirstOrDefault(x => x.order_id == order.order_id).Customers.cust_surName;
            }
            return collection;
        }
        //Return CustomersObject by OrdersObject  
        public static Customers ReturnCustomers(object orderObj)
        {
            MyFirmEntiti dbContecst;
            Customers collection;
            var order = (Orders)orderObj;
            using (dbContecst = new MyFirmEntiti())
            {
                collection = dbContecst.CustomersOrders.Where(ordProd => ordProd.order_id == order.order_id).FirstOrDefault(x => x.order_id == order.order_id).Customers;
            }
            return collection;
        }
        public static int ReturnPositionCustomers(List<Customers> listCustomer,Orders orders)
        {
           Customers cust= ReturnCustomers(orders);
           int indexer;
           for (indexer = 0; indexer < listCustomer.Count; indexer++)
           {
               if (cust.cust_id==listCustomer[indexer].cust_id)
               {
                   return indexer;  
               }
           }
            return 0;
        }
    }
}
