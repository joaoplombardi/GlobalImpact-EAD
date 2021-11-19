using ConnectAll.Repositories;
using GlobalImpact.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectAll.Controllers
{
    public class ParceiroController : Controller
    {
        private IParceiroRepository _parceiroRepository;

        public ParceiroController(IParceiroRepository parceiroRepository)
        {
            _parceiroRepository=parceiroRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Parceiro parceiro)
        {
            _parceiroRepository.Cadastrar(parceiro);
            _parceiroRepository.Salvar();
            TempData["msg"] = "Parceiro cadastrado com sucesso!";
            return RedirectToAction("Index", "Home");
        }
    }
}
