using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlassLewis.Core.GlassLewis.Models
{
    [Table("Company")]
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Exchange { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        public string ISIN { get; set; }
        public string Website { get; set; }
    }
}
