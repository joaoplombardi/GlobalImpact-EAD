using ConnectAll.Context;
using GlobalImpact.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectAll.Repositories
{
    public class ParceiroRepository : IParceiroRepository
    {
        private GlobalImpactContext _context;

        public ParceiroRepository(GlobalImpactContext context)
        {
            _context = context;

        }

        public void Cadastrar(Parceiro parceiro)
        {
            var aux = _context.Distribuidores.Count();
            parceiro.ParceiroId = aux+1;
            _context.Distribuidores.Add(parceiro);
        }

        public IList<Parceiro> Listar()
        {
            Console.WriteLine(_context.Database.ExecuteSqlCommand("SELECT * FROM tb_parceiro;"));
            return _context.Distribuidores.ToList();
        }

        public void Salvar()
        {
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT GlobalImpactDB.tb_parceiro ON;");
            _context.SaveChanges();
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT tb_ponto_distribuicao OFF;");
        }
    }
}
