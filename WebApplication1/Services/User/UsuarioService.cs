using WebApplication1.Models;

namespace WebApplication1.Services.User
{
    public interface UsuarioService
    {
        public List<Usuario> FindAll();
        public Usuario Find(int id);
        public void Create(Usuario usuario);
        public void Delete(int id);
        public void Update(Usuario usuario);
    }
}
