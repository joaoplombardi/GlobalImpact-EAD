using GlobalImpact.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectAll.Context
{
    public class GlobalImpactContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Parceiro> Distribuidores { get; set; }
        public DbSet<PontoDeDistribuicao> PontosDeDistribuicao { get; set; }


        public GlobalImpactContext(DbContextOptions options)
            : base(options) { }
    }
}
