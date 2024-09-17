using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace APICatalogo.Models {
    [Table("Pagamentos")]
    public class Pagamento {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataPagamento { get; set; }

        public int CondominioId { get; set; }
        public Condominio? Condominio { get; set; }
    }
}
