using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using var context = new MyStoreContext();
                products = context.Products.Include(p => p.Category).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public static void SaveProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Product GetProductById(int id)
        {
            try
            {
                using var context = new MyStoreContext();
                return context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
