using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDKSDatabase.Models
{
    /// <summary>
    /// ABCRecycling class tracks ABC recycling tonnaged by year.
    /// </summary>
    public class ABCRecycling
    {
        //The ABCDateID property which is the PK represents the recoded date.
        [Key]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime? ABCDateID { get; set; }

        //ABC_LOCATION property represents the facility location.
        [Display(Name = "Facility location")]
        [Required]
        [StringLength(20)]
        public string? ABC_LOCATION { get; set; }

        //ABC_MATERIAL property represents the recyclable material name.
        [Display(Name = "Recyclable material")]
        [Required]
        [StringLength(10)]
        public string? ABC_MATERIAL { get; set; }

        //TOTAL_POUND_NETWEIGHT property represents the Material weight in pound.
        [Display(Name = "Material weight in pound")]
        [Required]
        [Range(0.0, float.MaxValue)]
        [Column("ABC_NET_WEIGHT_IN_POUND")]
        public float? TOTAL_POUND_NETWEIGHT { get; set; }

        //TOTAL_TONNAGE_NETWEIGHT property represents the Material weight in tonnage.
        [Display(Name = "Material weight in tonnage")]
        [Required]
        [Range(0.0, float.MaxValue)]
        [Column("ABC_TOTAL_NET_WEIGHT_IN_TONNAGE")]
        public float? TOTAL_TONNAGE_NETWEIGHT { get; set; }

        //TOTAL_TONNAGE_MATERIAL property represents the total material weight in tonnage.
        [Display(Name = "Total Material weight in tonnage")]
        [Required]
        [Range(0.0, float.MaxValue)]
        [Column("ABC_TOTAL_METRIC_TON")]
        public float? TOTAL_TONNAGE_MATERIAL { get; set; }

        //ABC_COMPLETED property represents whether the transaction is completed or not by boolean.
        [Display(Name = "Is completed")]
        public bool? ABC_COMPLETED { get; set; }

    }
}
