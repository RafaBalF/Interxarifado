namespace Interxarifado.Models
{
    public abstract class Pessoa
    {
        public string nome {get; set;}
        public string cpf {get;set;}
        public string email {get;set;}
        public string senha {get;set;}
        public decimal salario {get;set;}
        public int id {get; set;}
    }
}