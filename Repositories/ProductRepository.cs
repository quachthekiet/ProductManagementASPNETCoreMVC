using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product)
        {
            ProductDAO.DeleteProduct(product);
        }

        public Product GetProductById(int id)
        {
            return ProductDAO.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return ProductDAO.GetProducts();
        }

        public void SaveProduct(Product product)
        {
            ProductDAO.SaveProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            ProductDAO.UpdateProduct(product);
        }
    }
}
