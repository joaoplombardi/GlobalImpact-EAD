using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalImpact.Models
{
    [Table("tb_ponto_distribuicao")]
    public class PontoDeDistribuicao
    {
        [Column("id")]
        public int PontoDeDistribuicaoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Endereco { get; set; }

        public virtual ICollection<Produto> Estoque { get; set; }

    }
}
