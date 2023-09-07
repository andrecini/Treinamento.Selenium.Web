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
            // Arrange
            SettingsHelper.SetFolder("Listagem");
            var url = new ListagemPage(_webDriver).AbrirTelaListagem();
            Task.Delay(2000).Wait();

            // Act
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "TelaInicial");

            // Assert
            Assert.Equal(url, SettingsHelper.Url);
        }

        [Fact]
        public void CadastrarPessoa()
        {
            // Arrange
            SettingsHelper.SetFolder("Cadastrar");
            var cadastroPage = new CadastroPage(_webDriver);
            cadastroPage.AbrirTelaListagem();
            Task.Delay(5000).Wait();
            var quantidadeInicial = cadastroPage.PegarQuantidadeDeRegistros();

            // Act
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemAntes");
            var urlCadastro = cadastroPage.AbrirTelaCadastro();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "TelaCadastro");
            cadastroPage.CadastrarCliente(urlCadastro);
            cadastroPage.AbrirTelaListagem();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemComCadastrado");

            // Assert
            var quantidadeFinal = cadastroPage.PegarQuantidadeDeRegistros();
            Assert.Equal(quantidadeFinal, quantidadeInicial + 1);
        }

        [Fact]
        public void EditarPessoa()
        {
            // Arrange
            SettingsHelper.SetFolder("Editar");
            var visualizacaoPage = new VisualizacaoPage(_webDriver);
            visualizacaoPage.AbrirTelaListagem();
            var nomeInicial = visualizacaoPage.PegarNomeDoRegistro();
            var id = visualizacaoPage.PegarIdDoRegistro();

            // Act
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemAntes");
            var urlVisualizacao = visualizacaoPage.AbrirTelaVisualizacao();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "TelaCadastro");
            visualizacaoPage.EditarCliente(urlVisualizacao, id);
            visualizacaoPage.AbrirTelaListagem();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemComEditado");

            //Assert
            var nomeFinal = visualizacaoPage.PegarNomeDoRegistro();
            Assert.Equal(nomeFinal, $"{nomeInicial} - Editado");
        }

        [Fact]
        public void DeletarPessoa()
        {
            // Arrange
            SettingsHelper.SetFolder("Deletar");
            var listagemPage = new ListagemPage(_webDriver);
            listagemPage.AbrirTelaListagem();
            var quantidadeInicial = listagemPage.PegarQuantidadeDeRegistros();

            // Act
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemAntes");
            listagemPage.DeletarPessoa();
            ScreenshotHelper.GerarEvidencia(_webDriver, SettingsHelper.Directory, "ListagemSemDeletado");

            // Assert
            var quantidadeFinal = listagemPage.PegarQuantidadeDeRegistros();
            Assert.Equal(quantidadeFinal, quantidadeInicial - 1);
        }

        public void Dispose()
        {
            _webDriver.Dispose();
        }
    }
}
