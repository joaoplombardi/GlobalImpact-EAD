using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalImpact.Models
{
    [Table("tb_parceiro")]
    public class Parceiro
    {
        [Column("id")]
        public int ParceiroId { get; set; }

        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string cpf_cnpj { get; set; }

        public virtual ICollection<Produto> ProdutosDistribuidos { get; set; }
    }
}
