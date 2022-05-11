using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ProductService
    {
        public List<Product> FindAll();
        public Product Find(int id);
        public void Create(Product product);
        public void Delete(int id);
        public void Update(Product product);

    }
}
