using System.ComponentModel.DataAnnotations;

namespace RDKSDatabase.Models
{
    /// <summary>
    /// This class represent a Waste Source model
    /// </summary>
    public class WasteSource
    {
        [Key]
        public string? WasteGenerator { get; set; }

        [Required]
        public string? WasteSourceSiteAddress { get; set; }

        public ICollection<Permit>? Permits { get; set; }

    }
}
