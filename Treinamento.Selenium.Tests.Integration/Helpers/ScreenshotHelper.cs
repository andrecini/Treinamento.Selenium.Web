using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.Selenium.Tests.Integration.Helpers
{
    public static class ScreenshotHelper
    {
        public static void GerarEvidencia(IWebDriver driver, string diretorio, string arquivo)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            CriarDiretorioSeNaoExistir(diretorio);
            foto.SaveAsFile($"{diretorio}\\{arquivo}.png", ScreenshotImageFormat.Png);
        }

        private static void CriarDiretorioSeNaoExistir(string diretorio)
        {
            if (!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);
        }
    }
}
