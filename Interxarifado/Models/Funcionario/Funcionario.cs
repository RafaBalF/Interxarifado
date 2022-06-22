namespace Interxarifado.Models
{
    public class Funcionario : Pessoa
    {
        public string dataInicioContr {get; set;}
        public string dataFimContr {get; set;} 
        public int idSetor {get;set;}
        //#region Foreign Key
            //public Pessoa pessoa { get; set; }
        //#endregion
    }
}