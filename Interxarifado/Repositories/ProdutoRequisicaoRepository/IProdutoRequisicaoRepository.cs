using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public interface IProdutoRequisicaoRepository
    {
        void CreateProdutoRequi(ProdutoRequisicao preq);
        List<ProdutoRequisicao> ReadProdutoRequi();
        ProdutoRequisicao ReadProdutoRequi(int idPreq);
        void UpdateProdutoRequi(int idPreq, ProdutoRequisicao preq);
    }
}