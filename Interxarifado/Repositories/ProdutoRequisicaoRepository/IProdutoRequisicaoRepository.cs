using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public interface IProdutoRequisicaoRepository
    {
        void CreateProdutoRequi(ProdutoRequisicao preq);
        List<ProdutoRequisicao> ReadByRequisicao(int idRequisicao);
        ProdutoRequisicao ReadProdutoRequi();
        void UpdateProdutoRequi(int idPreq, ProdutoRequisicao preq);
    }
}