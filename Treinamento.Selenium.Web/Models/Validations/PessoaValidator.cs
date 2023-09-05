using FluentValidation;

namespace Treinamento.Selenium.Web.Models.Validations
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(pessoa => pessoa.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(pessoa => pessoa.Sobrenome).NotEmpty().WithMessage("O sobrenome é obrigatório.");
            RuleFor(pessoa => pessoa.Email).NotEmpty().WithMessage("O email é obrigatório.");
            RuleFor(pessoa => pessoa.DataNascimento).NotEmpty().WithMessage("A data de nascimento é obrigatória.");
            RuleFor(pessoa => pessoa.Estado).NotEmpty().WithMessage("O estado é obrigatório.");
            RuleFor(pessoa => pessoa.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.");
            RuleFor(pessoa => pessoa.Senha).NotEmpty().WithMessage("A senha é obrigatória"); ;
            RuleFor(pessoa => pessoa.Senha).MinimumLength(8).WithMessage("A senha deve conter no mínimo 8 caracteres.");
        }
    }
}
