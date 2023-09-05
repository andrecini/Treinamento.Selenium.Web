using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Treinamento.Selenium.Web.Models;

namespace Treinamento.Selenium.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PessoaContext _context;

        public HomeController(ILogger<HomeController> logger, PessoaContext contexto)
        {
            _logger = logger;
            _context = contexto;
        }

        public IActionResult Index()
        {
            var pessoas = _context.Pessoas.ToList();

            return View(pessoas);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Cadastrar(Pessoa pessoa)
        {
            var validacao = pessoa.Validar();

            if (validacao.EhValido)
            {
                var resultado = _context.Add(pessoa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Validacoes = validacao.Erros;
                return View("Cadastro", pessoa);
            }
        }

        public IActionResult Visualizacao(int id)
        {
            var pessoaBanco = _context.Pessoas.Where(x => x.Id == id).FirstOrDefault();
            return View(pessoaBanco);
        }

        public IActionResult Editar(Pessoa pessoaEditada)
        {
            var validacao = pessoaEditada.Validar();

            if (validacao.EhValido)
            {
                AlterarPessoa(pessoaEditada);

                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest("Erro ao Editar");
            }
        }

        public IActionResult Deletar(int id)
        {
            DeletarPessoa(id);

            return RedirectToAction("Index");
        }

        private void AlterarPessoa(Pessoa pessoa)
        {
            var pessoaBanco = _context.Pessoas.Find(pessoa.Id);

            if (pessoaBanco != null)
                pessoaBanco.Map(pessoa);

            _context.SaveChanges();
        }

        private void DeletarPessoa(int id)
        {
            var pessoaBanco = _context.Pessoas.Find(id);

            if (pessoaBanco != null)
                _context.Pessoas.Remove(pessoaBanco);

            _context.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}