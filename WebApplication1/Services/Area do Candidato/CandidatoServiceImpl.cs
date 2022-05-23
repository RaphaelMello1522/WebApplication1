using WebApplication1.Models;

namespace WebApplication1.Services.Area_do_Candidato
{
    public class CandidatoServiceImpl : CandidatoService
    {

        private DatabaseContext db;

        public CandidatoServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public void Create(AreaDoCandidato candidato)
        {
            db.AreaDoCandidatos.Add(candidato);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.AreaDoCandidatos.Remove(db.AreaDoCandidatos.Find(id));
            db.SaveChanges();
        }

        public AreaDoCandidato Find(int id)
        {
            return db.AreaDoCandidatos.Find(id);
        }

        public List<AreaDoCandidato> FindAll()
        {
            return db.AreaDoCandidatos.ToList();
        }

        public void Update(AreaDoCandidato candidato)
        {
            db.Entry(candidato).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
