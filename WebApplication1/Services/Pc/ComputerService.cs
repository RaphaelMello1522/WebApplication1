using WebApplication1.Models;

namespace WebApplication1.Services.Pc
{
    public interface ComputerService
    {
        public List<Computadores> FindAll();
        public Computadores Find(int id);
        public void Create(Computadores computadores);
        public void Delete(int id);
        public void Update(Computadores computadores);
    }
}
