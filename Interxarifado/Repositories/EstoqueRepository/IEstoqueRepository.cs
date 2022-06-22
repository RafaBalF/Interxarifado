using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public interface IEstoqueRepository
    {
        void CreateEstoque(Estoque produto);
        List<Estoque> ReadEstoque();
        Estoque ReadEstoque(int idProduto);
        void UpdateEstoque(int idProduto, Estoque produto);
        void DeleteEstoque(int idProduto);
    }
}