using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Treinamento.Selenium.Tests.Integration.Helpers
{
    public static class WebElementHelper
    {
        public static void Preencher(this IWebElement webElement, string valor)
        {
            IdentificarSeElementoFoiCarregado(webElement);
            webElement.SendKeys(valor);
        }

        public static void SelecionarPorTexto(this SelectElement selectElement, IWebElement webElement, string valor)
        {
            IdentificarSeElementoFoiCarregado(webElement);
            selectElement.SelectByText(valor);
        }

        public static bool IdentificarSeElementoFoiCarregado(IWebElement element)
        {
            for (int i = 0; i < 30; i++)
            {
                if (element.Displayed && element.Enabled)
                    return true;

                Task.Delay(2000).Wait();
            }

            return false;
        }

        public static IWebElement ObterElementoVisivel(ReadOnlyCollection<IWebElement> elements)
        {
            foreach (var element in elements)
            {
                if (element.Displayed && element.Enabled)
                    return element;
            }

            return elements.FirstOrDefault();
        }

        public static void PosicionarScroll(IWebDriver driver, By by)
        {
            var elementos = driver.FindElements(by);
            var elementoVisivel = ObterElementoVisivel(elementos);

            Actions actions = new Actions(driver);
            actions.MoveToElement(elementoVisivel);
            actions.Perform();
        }

        public static void ClicarNoElemento(this IWebElement webElement)
        {
            IdentificarSeElementoFoiCarregado(webElement);
            webElement.Click();
        }
    }
}
