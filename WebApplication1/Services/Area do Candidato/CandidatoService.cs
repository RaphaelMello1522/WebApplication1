using WebApplication1.Models;

namespace WebApplication1.Services.Area_do_Candidato
{
    public interface CandidatoService
    {
        public List<AreaDoCandidato> FindAll();
        public AreaDoCandidato Find(int id);
        public void Create(AreaDoCandidato candidato);
        public void Delete(int id);
        public void Update(AreaDoCandidato candidato);
    }
}
