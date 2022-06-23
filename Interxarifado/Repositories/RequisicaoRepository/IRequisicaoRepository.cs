using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public interface IRequisicaoRepository
    {
        void CreateRequisicao(Requisicao requisicoes);
        List<Requisicao> ReadRequisicao();
        Requisicao ReadRequisicao(int idRequisicao);
        List<Requisicao> ReadBySetores(int IdSetor);
        void UpdateRequisicao(int idRequisicao, Requisicao requisicoes);
        void DeleteRequisicao(int idRequisicao);
    }
}