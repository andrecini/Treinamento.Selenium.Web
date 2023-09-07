namespace Treinamento.Selenium.Tests.Integration.Helpers
{
    public static class SettingsHelper
    {
        public static string Url
        {
            get => "https://localhost:7242/";
        }

        public static string Directory
        {
            get => "C:\\temp\\TreinamentoSelenium\\Evidencias" + Folder;
        }

        private static string Folder { get; set; }

        public static void SetFolder(string folderName)
        {
            Folder = $"\\{folderName}";
        }

    }
}
