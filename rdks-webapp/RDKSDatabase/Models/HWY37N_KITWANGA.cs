using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDKSDatabase.Models
{
    /// <summary>
    /// The model of HWY37N_KITWANGA which has all the attributes of the HWY37N_KITWANGA table.
    /// HWY_KIT_DATE is the primary key.
    /// </summary>
    public class HWY37N_KITWANGA
    {
        [Key]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date (Week of)")]
        public DateTime HWY_KIT_DATE { get; set; }

        [Display(Name = "OCC Tonnage Estimate")]
        public float? HWY_KIT_OCC_TONNAGE_EST { get; set; }

        [Display(Name = "PPP Tonnage (DYP Scale)")]
        public float? HWY_KIT_PPP_TONNAGE { get; set; }

        [Display(Name = "OCC Hauling & Bin Rental costs ($)")]
        public float? HWY_KIT_OCC_HAULING_BIN_RENTAL { get; set; }

        [Display(Name = "PPP Hauling costs ($)")]
        public float? HWY_KIT_PPP_HAULING { get; set; }

        [Display(Name = "Recycle BC Tonnage")]
        public float? HWY_KIT_RECYCLE_BC_TONNAGE { get; set; }

        [Display(Name = "CESA Tonnes")]
        public float? HWY_KIT_CESA_TONNES { get; set; }

        [Display(Name = "EPRA Tonnes")]
        public float? HWY_KIT_EPRA_TONNES { get; set; }

        [Display(Name = "Light Recycle Counts")]
        public float? HWY_KIT_LIGHT_RECYCLE_COUNTS { get; set; }

        [Display(Name = "Paint Recycle Counts 1 tub = 0.5tonne")]
        public float? HWY_KIT_PAINT_RECYCLE_COUNTS { get; set; }

        [Display(Name = "Scrap Metal - MARR Included")]
        public float? HWY_KIT_SCRAP_METAL_MARR_INCLUDED { get; set; }

        [Display(Name = "LAB Tonnes")]
        public float? HWY_KIT_LAB_TONNES { get; set; }

        [Display(Name = "Tire Counts (100 tires = 1 tonne)")]
        public float? HWY_KIT_TIRE_COUNTS { get; set; }

        [Display(Name = "Tire Charges")]
        public float? HWY_KIT_TIRE_CHARGES { get; set; }

        [Display(Name = "Freon Removal Charges")]
        public float? HWY_KIT_FREON_REMOVAL_CHARGES { get; set; }

        [Display(Name = "Recycle BC Income")]
        public float? HWY_KIT_RECYCLE_BC_INCOME { get; set; }

        [Display(Name = "CESA Income (Negative #)")]
        public float? HWY_KIT_CESA_INCOME { get; set; }

        [Display(Name = "EPRA Income (Negative #)")]
        public float? HWY_KIT_EPRA_INCOME { get; set; }

        [Display(Name = "Light Recycle Income (Negative #)")]
        public float? HWY_KIT_LIGHT_RECYCLE_INCOME { get; set; }

        [Display(Name = "Paint Recycle Income (Negative #)")]
        public float? HWY_KIT_PAINT_RECYCLE_INCOME { get; set; }

        [Display(Name = "MARR Income (Negative #)")]
        public float? HWY_KIT_MARR_INCOME { get; set; }

        [Display(Name = "LAB Income (Negative #)")]
        public float? HWY_KIT_LAB_INCOME { get; set; }

        [Display(Name = "Total tonnes EPR")]
        public float? HWY_KIT_TOTAL_TONNES_EPR { get; set; }

        [Display(Name = "Net Income/ Cost of EPR")]
        public float? HWY_KIT_NET_INCOME { get; set; }

    }
}
