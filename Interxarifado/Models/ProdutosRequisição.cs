namespace Interxarifado.Models
{
    public class ProdutoRequisicao
    {
        public int idPreq {get; set;}
        public int idRequisicao {get;set;}
        public int idProduto {get;set;}
        public string produtoRequisitado {get;set;}
        public int qtdRequisitada {get; set;}
        public int qtdEntregue {get; set;}
    }
}