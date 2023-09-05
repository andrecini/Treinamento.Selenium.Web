using OpenQA.Selenium;
using Treinamento.Selenium.Tests.Integration.Helpers;

namespace Treinamento.Selenium.Tests.Integration.PageObjects.Listagem
{
    public class ListagemPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement btnDeletar => _webDriver.FindElement(By.Id("btnDeletar-1"));
        private IWebElement btnConfirmar => _webDriver.FindElement(By.Id("btnConfirmar"));


        public ListagemPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string AbrirTelaListagem()
        {
            IrParaPagina();
            Task.Delay(2000).Wait();

            return _webDriver.Url;
        }

        public string DeletarPessoa()
        {
            WebElementHelper.PosicionarScroll(_webDriver, By.Id("btnDeletar-1"));
            Task.Delay(2000);
            ClicarNoBotaoDeletar();
            Task.Delay(2000);
            ClicarEmConfirmarDelecao();
            Task.Delay(2000);

            return _webDriver.Url;
        }

        private void IrParaPagina() => _webDriver.Url = SettingsHelper.Url;
        private void ClicarNoBotaoDeletar() => btnDeletar.ClicarNoElemento();
        private void ClicarEmConfirmarDelecao() => btnConfirmar.ClicarNoElemento();
    }
}
