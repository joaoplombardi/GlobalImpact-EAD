using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalImpact.Models
{
    [Table("tb_produto")]
    public class Produto
    {
        [Column("id")]
        public int ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Column("dt_validade"), Display(Name = "Data de Vencimento"), DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }

        [Required]
        public int Quantidade { get; set; }
        public Parceiro Distribuidor { get; set; }
        public int? DistribuidorId { get; set; }
        public PontoDeDistribuicao PontoDeDistribuicao { get; set; }
        public int PontoDeDistribuicaoId { get; set; }
    }
}
