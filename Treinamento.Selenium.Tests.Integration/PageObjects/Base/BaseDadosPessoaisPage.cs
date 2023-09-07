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

        internal string RetornarPagina() => SettingsHelper.Url;

        internal void ClicarEmSalvar()
        {
            btnSalvar.Click();
        }

        internal void PreencherFormulario(string url, DadosPessoaisHelper helper)
        {
            _webDriver.Url = url;

            PreencherIdComDelay(helper.Id);
            PreencherCampoComDelay(inputNome, By.Id("nome"), helper.Nome);
            PreencherCampoComDelay(inputSobrenome, By.Id("sobrenome"), helper.Sobrenome);
            PreencherCampoComDelay(inputEmail, By.Id("email"), helper.Email);
            PreencherCampoComDelay(inputDataNascimento, By.Id("dataNascimento"), helper.DataNascimento.ToString("MM-dd-yyyy"));
            SelecionarEstadoComDelay(helper.Estado);
            PreencherCampoComDelay(inputTelefone, By.Id("telefone"), helper.Telefone);
            PreencherCampoComDelay(inputSenha, By.Id("senha"), helper.Senha);
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "FomularioCadastroPreenchido");
            Task.Delay(2000).Wait();
            btnSalvar.Submit();
        }

        private void PreencherIdComDelay(int id)
        {
            Task.Delay(2000).Wait();
            string script = $"document.getElementById('id').value = '{id}';";
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(script);
            Task.Delay(2000).Wait();
        }

        private void PreencherCampoComDelay(IWebElement element, By by, string valor)
        {
            WebElementHelper.PosicionarScroll(_webDriver, by);
            Task.Delay(2000).Wait();
            element.Preencher(valor);
            Task.Delay(2000).Wait();
        }

        private void SelecionarEstadoComDelay(string estado)
        {
            Task.Delay(2000).Wait();
            var selectElement = new SelectElement(selectEstado);
            selectElement.SelecionarPorTexto(selectEstado, estado);
            Task.Delay(2000).Wait();
        }
    }
}
