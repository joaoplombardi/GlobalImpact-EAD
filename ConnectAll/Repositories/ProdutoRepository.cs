using ConnectAll.Context;
using GlobalImpact.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectAll.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private GlobalImpactContext _context;
        public ProdutoRepository(GlobalImpactContext context)
        {
            _context = context;
        }
        public void Atualizar(Produto produto) 
        { 
        
            _context.Produtos.Update(produto);
        }

        public void Cadastrar(Produto produto)
        {
            //var aux = _context.Produtos.Count();
            //produto.ProdutoId = aux + 1;
            _context.Produtos.Add(produto);
        }

        public IList<Produto> Listar()
        {
            return _context.Produtos.Include(p => p.PontoDeDistribuicao).Include(p => p.Distribuidor).ToList();
        }

        public void Remover(int id)
        {
            var produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
        }

        public void Salvar()
        {
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.tb_produto ON;");
            _context.SaveChanges();
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.tb_produto OFF;");
        }

        public Produto BuscarPorId(int id)
        {
            return _context.Produtos.Where(p => p.ProdutoId == id)
             .Include(p => p.Distribuidor).FirstOrDefault();
        }
    }
}
