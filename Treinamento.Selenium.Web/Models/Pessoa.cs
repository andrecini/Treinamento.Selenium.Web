using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Treinamento.Selenium.Web.Models.Validations;

namespace Treinamento.Selenium.Web.Models
{
    [DisplayName("Pessoas")]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Senha { get; set; }

        public Validacao Validar()
        {
            var validator = new PessoaValidator().Validate(this);
            return new Validacao()
            {
                EhValido = validator.IsValid,
                Erros = validator.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage)
            };
        }

        public void Map(Pessoa pessoa)
        {
            this.Nome = pessoa.Nome;
            this.Sobrenome = pessoa.Sobrenome;
            this.Email = pessoa.Email;
            this.DataNascimento = pessoa.DataNascimento;
            this.Estado = pessoa.Estado;
            this.Telefone = pessoa.Telefone;
            this.Senha = pessoa.Senha;
        }
    }
}
