using WebApplication1.Models;

namespace WebApplication1.Services.User
{
    public class UsuarioServiceImpl : UsuarioService
    {

        private DatabaseContext db;

        public UsuarioServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public void Create(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Usuarios.Remove(db.Usuarios.Find(id));
            db.SaveChanges();
        }

        public Usuario Find(int id)
        {
            return db.Usuarios.Find(id);
        }

        public List<Usuario> FindAll()
        {
            return db.Usuarios.ToList();
        }

        public void Update(Usuario usuario)
        {
            db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
