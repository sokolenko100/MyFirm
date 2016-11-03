using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirm.Model;
using System.Windows.Data;
using System.Collections;
using MyFirm.ViewModelComponent;

public partial class OrdersProducts
{
    // Return Object for show it on OrderDateGrid by orderObject
    public static object ReturnOrdersProductsCollection(object orderObj)
    {
        MyFirmEntiti dbContecst;
        object collection;
        var order = (Orders)orderObj;
        using (dbContecst = new MyFirmEntiti())
        {
            collection = dbContecst.OrdersProducts.Where(ordProd => ordProd.order_id == order.order_id).FirstOrDefault(x => x.order_id == order.order_id).Products.prod_name; ;
        }
        return collection;
    }
    //Return OrderObject by OrdersObject  
    public static Products ReturnOrdersProducts(object orderObj)
    {
        MyFirmEntiti dbContecst;
        Products collection;
        var order = (Orders)orderObj;
        using (dbContecst = new MyFirmEntiti())
        {
            collection = dbContecst.OrdersProducts.Where(ordProd => ordProd.order_id == order.order_id).FirstOrDefault(x => x.order_id == order.order_id).Products;
        }
        return collection;
    }
    public static int ReturnPositionProducts(List<Products> listProducts, Orders orders)
    {
        Products prod = ReturnOrdersProducts(orders);
        int indexer;
        for (indexer = 0; indexer < listProducts.Count; indexer++)
        {
            if (prod.prod_id == listProducts[indexer].prod_id)
            {
                return indexer;
            }
        }
        return 0;
    }
}
