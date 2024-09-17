using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models {
    [Table("Moradores")]
    public class Morador {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string DocumentoIdentidade { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public int CondominioId { get; set; }
        public Condominio? Condominio { get; set; }
    }
}
