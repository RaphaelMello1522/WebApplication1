using WebApplication1.Models;

namespace WebApplication1.Services.Recrutamento
{
    public interface VagaService
    {
        public List<Vaga> FindAll();
        public Vaga Find(int id);
        public void Create(Vaga vaga);
        public void Delete(int id);
        public void Update(Vaga vaga);
    }
}
