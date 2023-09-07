using OpenQA.Selenium;
using Treinamento.Selenium.Tests.Integration.Helpers;
using TreinamentoSellenium.Test.Integration.PageObjects.Base;

namespace TreinamentoSellenium.Test.Integration.PageObjects.Cadastro
{
    public class CadastroPage : BaseDadosPessoaisPage
    {

        private readonly IWebDriver _webDriver;
        internal IWebElement btnCadastrar => _webDriver.FindElement(By.CssSelector("a#btnCadastro"));

        public CadastroPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string AbrirTelaListagem()
        {
            _webDriver.Url = RetornarPagina();
            Task.Delay(3000).Wait();

            return _webDriver.Url;
        }

        public int PegarQuantidadeDeRegistros()
        {
            return _webDriver.FindElements(By.ClassName("pessoa-registrada")).Count();
        }

        public string AbrirTelaCadastro()
        {
            Task.Delay(3000).Wait();
            ClicarNoBotaoCadastrar();
            Task.Delay(3000).Wait();

            return _webDriver.Url;
        }

        public string CadastrarCliente(string url)
        {
            var helper = new DadosPessoaisHelper();
            helper.Id = 0;
            PreencherFormulario(url, helper);
            Task.Delay(3000).Wait();

            return _webDriver.Url;
        }

        internal void ClicarNoBotaoCadastrar() => btnCadastrar.ClicarNoElemento();

    }
}
