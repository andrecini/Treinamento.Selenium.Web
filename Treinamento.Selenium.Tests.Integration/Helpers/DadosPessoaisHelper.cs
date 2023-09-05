using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.Selenium.Tests.Integration.Helpers
{
    public class DadosPessoaisHelper
    {
        private static DadosPessoaisHelper _instance;

        public static DadosPessoaisHelper GetSingleton()
        {
            if (_instance == null)
            {
                _instance = new DadosPessoaisHelper();
            }

            return _instance;
        }

        private DadosPessoaisHelper()
        {
            SetParameters();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        private void SetParameters()
        {
            Id = 1;
            Nome = "André";
            Sobrenome = "Cini";
            Email = "andrevpcini@gmail.com";
            DataNascimento = DateTime.Now;
            Estado = "São Paulo";
            Telefone = "(11) 99999-9999";
            Senha = "12345678";
        }
    }
}
