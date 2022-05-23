using WebApplication1.Models;

namespace WebApplication1.Services.Recrutamento
{
    public class VagaServiceImpl : VagaService
    {
        private DatabaseContext db;

        public VagaServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public void Create(Vaga vaga)
        {
            db.Vagas.Add(vaga);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Vagas.Remove(db.Vagas.Find(id));
            db.SaveChanges();
        }

        public Vaga Find(int id)
        {
            return db.Vagas.Find(id);
        }

        public List<Vaga> FindAll()
        {
            return db.Vagas.ToList();
        }

        public void Update(Vaga vaga)
        {
            db.Entry(vaga).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
