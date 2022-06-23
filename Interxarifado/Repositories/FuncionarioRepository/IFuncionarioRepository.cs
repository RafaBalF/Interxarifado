using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public interface IFuncionarioRepository
    {
        void CreateFuncionario(Funcionario funcionario);
        List<Funcionario> ReadFuncionario();
        List<Funcionario> ReadBySetores(int IdSetor);
        Funcionario ReadFuncionario(int id);
        void UpdateFuncionario(int id, Funcionario funcionario);
        void DeleteFuncionario(int id);
    }
}