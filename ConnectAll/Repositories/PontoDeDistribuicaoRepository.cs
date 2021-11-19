using ConnectAll.Context;
using GlobalImpact.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ConnectAll.Repositories
{
    public class PontoDeDistribuicaoRepository : IPontoDeDistribuicaoRepository
    {
        private GlobalImpactContext _context;

        public PontoDeDistribuicaoRepository(GlobalImpactContext context)
        {
            _context = context;
        }

        public void Cadastrar(PontoDeDistribuicao pdd)
        {
            var aux = _context.PontosDeDistribuicao.Count();
            pdd.PontoDeDistribuicaoId = aux+1;
            _context.PontosDeDistribuicao.Add(pdd);
        }

        public IList<PontoDeDistribuicao> Listar()
        {
            return _context.PontosDeDistribuicao.Include(p => p.Estoque).ToList();
        }

        public void Salvar()
        {
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT GlobalImpactDB.tb_ponto_distribuicao ON;");
            _context.SaveChanges();
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT tb_ponto_distribuicao OFF;");
        }
    }
}
