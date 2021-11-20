using ConnectAll.Repositories;
using GlobalImpact.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectAll.Controllers
{
    public class PontoDeDistribuicaoController : Controller
    {
        private IPontoDeDistribuicaoRepository _pontoDeDistribuicaoRepository;

        public PontoDeDistribuicaoController(IPontoDeDistribuicaoRepository pontoDeDistribuicaoRepository)
        {
            _pontoDeDistribuicaoRepository = pontoDeDistribuicaoRepository; 

        }

        public IActionResult Index()
        {
            return View(_pontoDeDistribuicaoRepository.Listar());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(PontoDeDistribuicao pontoDeDistribuicao)
        {
            _pontoDeDistribuicaoRepository.Cadastrar(pontoDeDistribuicao);
            _pontoDeDistribuicaoRepository.Salvar();
            return RedirectToAction("Index");

        }

    }
}
