using OpenQA.Selenium;
using Treinamento.Selenium.Tests.Integration.Helpers;
using TreinamentoSellenium.Test.Integration.PageObjects.Base;

namespace TreinamentoSellenium.Test.Integration.PageObjects.Cadastro
{
    public class CadastroPage : BaseDadosPessoaisPage
    {

        private readonly IWebDriver _webDriver;
        internal IWebElement btnCadastrar => _webDriver.FindElement(By.Id("btnCadastro"));

        public CadastroPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string AbrirTelaListagem()
        {
            IrParaPagina();
            Task.Delay(2000).Wait();

            return _webDriver.Url;
        }

        public string AbrirTelaCadastro()
        {
            Task.Delay(2000);
            ClicarNoBotaoCadastrar();
            Task.Delay(2000);

            return _webDriver.Url;
        }

        public string CadastrarCliente()
        {
            PreencherFormulario();
            WebElementHelper.PosicionarScroll(_webDriver, By.Id("btnSalvar"));
            Task.Delay(1000);
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "CadastroPreenchido");
            ClicarEmSalvar();
            Task.Delay(2000);

            return _webDriver.Url;
        }

        internal void ClicarNoBotaoCadastrar() => btnCadastrar.ClicarNoElemento();

    }
}
