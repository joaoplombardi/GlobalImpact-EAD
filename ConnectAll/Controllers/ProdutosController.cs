using ConnectAll.Repositories;
using GlobalImpact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConnectAll.Controllers
{
    public class ProdutosController : Controller
    {

        private IProdutoRepository _produtoRepository;
        private IParceiroRepository _parceiroRepository;
        private IPontoDeDistribuicaoRepository _pontoDeDistribuicaoRepository;

        public ProdutosController(IProdutoRepository produtoRepository, IParceiroRepository parceiroRepository, IPontoDeDistribuicaoRepository pontoDeDistribuicaoRepository)
        {
            _produtoRepository = produtoRepository;
            _parceiroRepository = parceiroRepository;
            _pontoDeDistribuicaoRepository = pontoDeDistribuicaoRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        private void CarregarParceiros()
        {
            var list = _parceiroRepository.Listar();

            ViewBag.parceiros = new SelectList(list, "DistribuidorId", "Nome");
        }

        private void CarregarPonto()
        {
            var list = _pontoDeDistribuicaoRepository.Listar();
            ViewBag.pontos = new SelectList(list, "PontoDeDistribuicaoId", "Nome");
        }



        [HttpGet]
        public IActionResult Cadastrar()
        {
            //CarregarParceiros();
            CarregarPonto();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            _produtoRepository.Cadastrar(produto);
            _produtoRepository.Salvar();
            TempData["msg"] = "Produto Adicionado";
            return RedirectToAction("Index", "PontoDeDistribuicao", new {area = ""});
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            //CarregarParceiros();
            CarregarPonto();
            var produto = _produtoRepository.BuscarPorId(id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            _produtoRepository.Atualizar(produto);
            _produtoRepository.Salvar();
            return RedirectToAction("Index", "PontoDeDistribuicao", new { area = "" });
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _produtoRepository.Remover(id);
            _produtoRepository.Salvar();
            return RedirectToAction("Index", "PontoDeDistribuicao", new { area = "" });
        }
    }
}
