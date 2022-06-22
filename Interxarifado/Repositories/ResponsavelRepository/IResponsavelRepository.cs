using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public interface IResponsavelRepository
    {
        void CreateResponsavel(ResponsavelSetor responsavel);
        List<ResponsavelSetor> ReadResponsavel();
        ResponsavelSetor ReadResponsavel(int id);
        ResponsavelSetor ReadResponsavel(string email, string senha);
        void UpdateResponsavel(int id, ResponsavelSetor responsavel);
        void DeleteResponsavel(int id);
    }
}