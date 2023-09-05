using OpenQA.Selenium;
using Treinamento.Selenium.Tests.Integration.Helpers;
using TreinamentoSellenium.Test.Integration.PageObjects.Base;

namespace TreinamentoSellenium.Test.Integration.PageObjects.Visualizacao
{
    public class VisualizacaoPage : BaseDadosPessoaisPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement btnEditar => _webDriver.FindElement(By.Id("btnEditar-1"));

        public VisualizacaoPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string AbrirTelaListagem()
        {
            IrParaPagina();
            Task.Delay(2000).Wait();

            return _webDriver.Url;
        }

        public string AbrirTelaVisualizacao()
        {
            WebElementHelper.PosicionarScroll(_webDriver, By.Id("btnDeletar-1"));
            Task.Delay(2000);
            ClicarNoBotaoEditar();
            Task.Delay(2000);

            return _webDriver.Url;
        }

        public string EditarCliente()
        {
            PreencherFormulario();
            WebElementHelper.PosicionarScroll(_webDriver, By.Id("btnSalvar"));
            Task.Delay(1000);
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "EdicaoPreenchido");
            ClicarEmSalvar();
            Task.Delay(2000);

            return _webDriver.Url;
        }

        internal void ClicarNoBotaoEditar() => btnEditar.ClicarNoElemento();
    }
}
