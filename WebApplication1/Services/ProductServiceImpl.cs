using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductServiceImpl : ProductService
    {

        private ApplicationDbContext db;

        public ProductServiceImpl(ApplicationDbContext _db)
        {
            db = _db;
        }

        public List<aluno> FindAll()
        {
            return db.alunos.ToList();
        }
    }
}
