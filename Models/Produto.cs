using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Marca { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
