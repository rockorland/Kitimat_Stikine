using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDKSDatabase.Models
{
    /// <summary>
    /// The model of HWY37N_STEWART which has all the attributes of the HWY37N_STEWART table.
    /// HWY_STE_DATE is the primary key.
    /// </summary>
    public class HWY37N_STEWART
    {
        [Key]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date (Week of)")]
        public DateTime HWY_STE_DATE { get; set; }

        [Display(Name = "OCC Tonnes")]
        public float? HWY_STE_OCC_TONNES { get; set; }

        [Display(Name = "Bandstra OCC Hauling Costs")]
        public float? HWY_STE_BANDSTRA_OCC_HAULING { get; set; }

        [Display(Name = "OCC Total Cost")]
        public float? HWY_STE_OCC_TOTAL { get; set; }

        [Display(Name = "Recycle BC Tonnage")]
        public float? HWY_STE_RECYCLE_BC_TONNAGE { get; set; }

        [Display(Name = "CESA Tonnes")]
        public float? HWY_STE_CESA_TONNES { get; set; }

        [Display(Name = "EPRA Tonnes")]
        public float? HWY_STE_EPRA_TONNES { get; set; }

        [Display(Name = "Light Recycle Counts")]
        public float? HWY_STE_LIGHT_RECYCLE_COUNTS { get; set; }

        [Display(Name = "Paint Recycle Counts  1tub = 0.5tonne")]
        public float? HWY_STE_PAINT_RECYCLE_COUNTS { get; set; }

        [Display(Name = "Scrap Metal - MARR Tonne Estimate")]
        public float? HWY_STE_SCRAP_METAL_MARR_TONNE_EST { get; set; }

        [Display(Name = "LAB Tonnes")]
        public float? HWY_STE_LAB_TONNES { get; set; }

        [Display(Name = "Tire Counts (100 tires = 1 tonne)")]
        public float? HWY_STE_TIRE_COUNTS { get; set; }

        [Display(Name = "Tire Charges")]
        public float? HWY_STE_TIRE_CHARGES { get; set; }

        [Display(Name = "Freon Removal Charges")]
        public float? HWY_STE_FREON_REMOVAL_CHARGES { get; set; }

        [Display(Name = "Recycle BC Income (Negative #)")]
        public float? HWY_STE_RECYCLE_BC_INCOME { get; set; }

        [Display(Name = "CESA Income (Negative #)")]
        public float? HWY_STE_CESA_INCOME { get; set; }

        [Display(Name = "EPRA Income (Negative #)")]
        public float? HWY_STE_EPRA_INCOME { get; set; }

        [Display(Name = "Light Recycle Income (Negative #)")]
        public float? HWY_STE_LIGHT_RECYCLE_INCOME { get; set; }

        [Display(Name = "Paint Recycle Income (Negative #)")]
        public float? HWY_STE_RECYCLE_INCOME { get; set; }

        [Display(Name = "MARR Income (Negative #)")]
        public float? HWY_STE_MARR_INCOME { get; set; }

        [Display(Name = "LAB Income (Negative #)")]
        public float? HWY_STE_LAB_INCOME { get; set; }

        [Display(Name = "Total Tonnes EPR")]
        public float? HWY_STE_TOTAL_TONNES_EPR { get; set; }

        [Display(Name = "Net Income/ Cost of EPR")]
        public float? HWY_STE_NET_INCOME { get; set; }

    }
}
