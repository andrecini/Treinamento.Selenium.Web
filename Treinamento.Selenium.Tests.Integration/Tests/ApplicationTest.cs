using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Xunit;
using Treinamento.Selenium.Tests.Integration.Helpers;
using Treinamento.Selenium.Tests.Integration.PageObjects.Listagem;
using TreinamentoSellenium.Test.Integration.PageObjects.Cadastro;
using TreinamentoSellenium.Test.Integration.PageObjects.Visualizacao;

namespace TreinamentoSellenium.Test.Integration.Tests
{
    public class ApplicationTest : IDisposable
    {
        private IWebDriver _webDriver;

        public ApplicationTest()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        [Fact]
        public void AbrirTelaDeListagem()
        {
            new ListagemPage(_webDriver).AbrirTelaListagem();
            Task.Delay(3000).Wait();

            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "RealizarLoginAmericas");

            Assert.Equal("Home", _webDriver.Title);
        }

        [Fact]
        public void CadastrarPessoa()
        {
            var cadastroPage = new CadastroPage(_webDriver);

            cadastroPage.AbrirTelaListagem();
            Task.Delay(3000).Wait();
            cadastroPage.AbrirTelaCadastro();
            Task.Delay(3000).Wait();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "TelaCadastro");
            Task.Delay(3000).Wait();
            cadastroPage.PreencherFormulario();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemComCadastrado");


            Assert.Equal("Cadastro", _webDriver.Title);
        }

        [Fact]
        public void EditarPessoa()
        {
            var visualizacaoPage = new VisualizacaoPage(_webDriver);

            visualizacaoPage.AbrirTelaListagem();
            Task.Delay(3000).Wait();
            visualizacaoPage.AbrirTelaVisualizacao();
            Task.Delay(3000).Wait();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "TelaCadastro");
            Task.Delay(3000).Wait();
            visualizacaoPage.PreencherFormulario();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemComCadastrado");


            Assert.Equal("Visualizacao", _webDriver.Title);
        }

        [Fact]
        public void DeletarPessoa()
        {
            var listagemPage = new ListagemPage(_webDriver);

            listagemPage.AbrirTelaListagem();
            Task.Delay(3000).Wait();
            listagemPage.DeletarPessoa();
            Task.Delay(3000).Wait();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemDeletado");
            Task.Delay(3000).Wait();

            Assert.Equal("Home", _webDriver.Title);
        }

        public void Dispose()
        {
            _webDriver.Dispose();
        }
    }
}
