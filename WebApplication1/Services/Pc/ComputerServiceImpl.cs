using WebApplication1.Models;

namespace WebApplication1.Services.Pc
{
    public class ComputerServiceImpl : ComputerService
    {

        private DatabaseContext db;

        public ComputerServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public void Create(Computadores computadores)
        {
            db.Computadores.Add(computadores);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Computadores.Remove(db.Computadores.Find(id));
            db.SaveChanges();
        }

        public Computadores Find(int id)
        {
            return db.Computadores.Find(id);
        }

        public List<Computadores> FindAll()
        {
            return db.Computadores.ToList();
        }

        public void Update(Computadores computadores)
        {
            db.Entry(computadores).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
