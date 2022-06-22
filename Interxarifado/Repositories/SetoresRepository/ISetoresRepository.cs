using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public interface ISetoresRepository
    {
        void CreateSetores(Setores setor);
        List<Setores> ReadSetores();
        Setores ReadSetores(int IdSetor);
        List<Setores> ReadByResponsavel(int id);
        void UpdateSetores(int IdSetor, Setores setor);
        void DeleteSetores(int IdSetor);
    }
}