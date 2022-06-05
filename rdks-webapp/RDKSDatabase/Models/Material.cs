using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDKSDatabase.Models
{


    /// <summary>
    /// The Material class which has all the attributes of the Material table.
    /// MaterialCode is the primary key.
    /// </summary>
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Material Code")]
        public int MaterialCode { get; set; }

        [Required]
        [Display(Name ="Material Type")]
        public string MaterialType { get; set; }

        public ICollection<Permit> Permits { get; set; }
    }
}
