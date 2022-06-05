using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDKSDatabase.Models
{
    /// <summary>
    /// The model of HWY37N_HAZELTON which has all the attributes of the HWY37N_HAZELTON table.
    /// HWY_HAZ_DATE is the primary key.
    /// </summary>
    public class HWY37N_HAZELTON
    {
        [Key]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date (Week-of)")]
        public DateTime HWY_HAZ_DATE { get; set; }

        [Display(Name = "Estimated OCC Tonnes  (4 x 6-yard bins/week)")]
        public float? HWY_HAZ_EST_OCC_TONNES { get; set; }

        [Display(Name = "OCC Bin Billing")]
        public float? HWY_HAZ_OCC_BIN_BILLING { get; set; }

        [Display(Name = "Scrap Metal Tonnes")]
        public float? HWY_HAZ_SCRAP_METAL_TONNES { get; set; }

        [Display(Name = "Tire Counts (100 tires = 1 tonne")]
        public float? HWY_HAZ_TIRE_COUNTS { get; set; }

        [Display(Name = "Tire Collection Charges")]
        public float? HWY_HAZ_TIRE_COLLECTION_CHARGES { get; set; }

        [Display(Name = "Freon Removal Charges")]
        public float? HWY_HAZ_FREON_REMOVAL_CHARGES { get; set; }

        [Display(Name = "MARR Income (Negative #)")]
        public float? HWY_HAZ_MARR_INCOME { get; set; }

        [Display(Name = "ABC Income (Negative #)")]
        public float? HWY_HAZ_ABC_INCOME { get; set; }

    }
}
