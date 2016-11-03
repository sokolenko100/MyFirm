using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirm.ViewModelComponent;

namespace MyFirm.Model
{
    public partial class Products : IDisposable
    {
        static MyFirmEntiti dbContecst;
        public static List<Products> ReturnAllProductsAsList()
        {
            using (dbContecst = new MyFirmEntiti())
            {
                return  dbContecst.Products.ToList();
            }
        }
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Products> GetByID(int id)
        {
            dbContecst = new MyFirmEntiti();
            return dbContecst.Products.Where(prod => prod.prod_id == id);
        }
        public void Add(Products entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    if (ProductsViewModel.SelectedItemProducts != null && !(ProductsViewModel.IsAdd))
                    {
                        var products = dbContecst.Products.Where(prod => prod.prod_id == ProductsViewModel.SelectedItemProducts.prod_id).FirstOrDefault();
                        products.prod_name = entity.prod_name;
                        products.prod_bit = entity.prod_bit;
                        products.prod_density = entity.prod_density;
                        products.prod_dump = entity.prod_dump;
                        products.prod_kernelImpurety = entity.prod_kernelImpurety;
                        products.prod_litter = entity.prod_litter;
                        products.prod_oilness = entity.prod_oilness;
                        products.prod_Price = entity.prod_Price;
                        products.prod_protein = entity.prod_protein;
                        products.prod_Qty = entity.prod_Qty;
                        dbContecst.SaveChanges();
                    }
                    else
                    {
                        dbContecst.Products.Add(entity);
                        dbContecst.SaveChanges();
                    }
                }
            }
        }
        public static void Delete(Products entity)
        {
            if (entity != null)
            {
                using (dbContecst = new MyFirmEntiti())
                {
                    Products custom = dbContecst.Products.Where(prod => prod.prod_id == entity.prod_id).FirstOrDefault();
                    dbContecst.Products.Remove(custom);
                    dbContecst.SaveChanges();
                }
            }
        }
    }
}
