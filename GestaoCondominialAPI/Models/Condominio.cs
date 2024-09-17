using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models {
    [Table("Condominios")]
    public class Condominio {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }

        // Relacionamentos
        public ICollection<Morador> Moradores { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

        // Construtor para inicializar as coleções
        public Condominio() {
            Moradores = new HashSet<Morador>();
            Pagamentos = new HashSet<Pagamento>();
        }
    }
}
