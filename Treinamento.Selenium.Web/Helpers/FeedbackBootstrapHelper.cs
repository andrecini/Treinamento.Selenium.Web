using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Treinamento.Selenium.Web.Helpers
{
    public class FeedbackBootstrapHelper
    {
        private readonly Dictionary<string, string> _validacoes;
        public FeedbackBootstrapHelper(Dictionary<string, string> validacoes) 
        { 
            _validacoes = validacoes;
        }

        public string RetornaClasse(string campo)
        {
            if (_validacoes == null) return string.Empty;
            if (_validacoes.ContainsKey(campo)) return "invalid-feedback d-block";
            else return "valid-feedback d-block";
        }

        public string RetornaMensagem(string campo)
        {
            if (_validacoes == null) return string.Empty;
            if (_validacoes.ContainsKey(campo)) return _validacoes[campo];
            else return "Campo preenchido corretamente.";
        }
    }

}
