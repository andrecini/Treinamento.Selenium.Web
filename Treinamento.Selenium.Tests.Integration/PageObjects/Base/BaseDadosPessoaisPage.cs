using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Treinamento.Selenium.Tests.Integration.Helpers;

namespace TreinamentoSellenium.Test.Integration.PageObjects.Base
{
    public class BaseDadosPessoaisPage
    {
        readonly IWebDriver _webDriver;

        internal IWebElement inputNome => _webDriver.FindElement(By.Id("nome"));
        internal IWebElement inputSobrenome => _webDriver.FindElement(By.Id("sobrenome"));
        internal IWebElement inputEmail => _webDriver.FindElement(By.Id("email"));
        internal IWebElement inputDataNascimento => _webDriver.FindElement(By.Id("dataNascimento"));
        internal IWebElement selectEstado => _webDriver.FindElement(By.Id("estado"));
        internal IWebElement inputTelefone => _webDriver.FindElement(By.Id("telefone"));
        internal IWebElement inputSenha => _webDriver.FindElement(By.Id("senha"));
        internal IWebElement btnSalvar => _webDriver.FindElement(By.Id("nome"));

        public BaseDadosPessoaisPage()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        internal void IrParaPagina() => _webDriver.Url = SettingsHelper.Url;
        internal void ClicarEmSalvar() => btnSalvar.ClicarNoElemento();
        internal void PreencherFormulario()
        {
            var helper = DadosPessoaisHelper.GetSingleton();

            PreencherCampoComDelay(inputNome, By.Id("nome"), helper.Nome);
            PreencherCampoComDelay(inputSobrenome, By.Id("sobrenome"), helper.Sobrenome);
            PreencherCampoComDelay(inputEmail, By.Id("email"), helper.Email);
            PreencherCampoComDelay(inputDataNascimento, By.Id("dataNascimento"), helper.DataNascimento.ToString("yyyy-MM-dd"));
            SelecionarEstado(helper.Estado);
            PreencherCampoComDelay(inputTelefone, By.Id("telefone"), helper.Telefone);
            PreencherCampoComDelay(inputSenha, By.Id("senha"), helper.Senha);
        }
        private void PreencherCampoComDelay(IWebElement element, By by, string valor)
        {
            WebElementHelper.PosicionarScroll(_webDriver, by);
            Task.Delay(1000);
            element.Preencher(valor);
            Task.Delay(500);
        }
        private void SelecionarEstado(string estado)
        {
            var selectElement = new SelectElement(selectEstado);
            selectElement.SelecionarPorTexto(selectEstado, estado);
        }
    }
}
