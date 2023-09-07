using AngleSharp.Dom;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OpenQA.Selenium;
using System.Drawing;
using Treinamento.Selenium.Tests.Integration.Helpers;
using TreinamentoSellenium.Test.Integration.PageObjects.Base;

namespace TreinamentoSellenium.Test.Integration.PageObjects.Visualizacao
{
    public class VisualizacaoPage : BaseDadosPessoaisPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement btnEditar => _webDriver.FindElement(By.Id("btnEditar-1"));
        private IWebElement inputNameForTest => _webDriver.FindElement(By.Id("nameForTest-1"));
        private IWebElement inputIdForTest => _webDriver.FindElement(By.Id("idForTest-1"));

        public VisualizacaoPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string AbrirTelaListagem()
        {
            _webDriver.Url = RetornarPagina();
            Task.Delay(3000).Wait();

            return _webDriver.Url;
        }
       
        public string PegarNomeDoRegistro()
        {
            return inputNameForTest.GetAttribute("value");
        }

        public int PegarIdDoRegistro()
        {
            return Convert.ToInt16(inputIdForTest.GetAttribute("value"));
        }

        public string AbrirTelaVisualizacao()
        {
            ClicarNoBotaoEditar();
            Task.Delay(3000);

            return _webDriver.Url;
        }

        public void EditarCliente(string url, int id)
        {
            var helper = new DadosPessoaisHelper();
            helper.Sobrenome = $"{helper.Sobrenome} - Editado";
            helper.Id = id;

            PreencherFormulario(url, helper);
            Task.Delay(3000).Wait();
        }

        internal void ClicarNoBotaoEditar() => btnEditar.ClicarNoElemento();
    }
}
