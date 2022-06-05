using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDKSDatabase.Models
{
    /// <summary>
    /// TThe Customer class represents the information of the vehicle.
    /// </summary>
    public class Customer
    {
        //The CUS_ID property which is the PK represents the customer ID.
        [Key]
        [Display(Name ="Customer ID")]
        public int CUS_ID { get; set; }

        //The CUS_ACCNUM property represents the customer's account number.
        [Required]
        [StringLength(12)]
        [Display(Name ="Customer Account Number")]
        public string? CUS_ACCNUM { get; set; }

        //The CUS_COMPNAME property represents the customer's company name.
        [Required]
        [StringLength(30)]
        [Display(Name = "Company Name")]
        public string? CUS_COMPNAME { get; set; }

        //The CUS_FNAME property represents the customer's first name.
        [Required]
        [StringLength(20)]
        [Display(Name = "Contact First Name")]
        public string? CUS_FNAME { get; set; }

        //The CUS_LNAME property represents the customer's last name.
        [Required]
        [StringLength(20)]
        [Display(Name = "Contact Last Name")]
        public string? CUS_LNAME { get; set; }

        //The CUS_PHONE property represents the customer's phone number.
        [Required]
        [StringLength(15)]
        [Display(Name = "Contact Phone Number")]
        public string? CUS_PHONE { get; set; }

        //The CUS_ALT_PHONE property represents the customer's alternative phone number.
        [StringLength(15)]
        [Display(Name = "Alternative Phone Number")]
        public string? CUS_ALT_PHONE { get; set; }

        //The CUS_EMAIL property represents the customer's email address.
        [StringLength(30)]
        [Display(Name = "Contact Email")]
        public string? CUS_EMAIL { get; set; }

        //The CUS_ALT_EMAIL property represents the customer's alternative email address.
        [StringLength(30)]
        [Display(Name = "Alt. Email")]
        public string? CUS_ALT_EMAIL { get; set; }

        //The CUS_FR property represents the access to FR facility.
        [Required]
        [Display(Name = "Access to FR")]
        public bool CUS_FR { get; set; }

        //The CUS_TTS property represents the access to TTS facility.
        [Required]
        [Display(Name = "Access to TTS")]
        public bool CUS_TTS { get; set; }

        //The CUS_MEZ property represents the access to Meziadin facility.
        [Required]
        [Display(Name = "Access to MEZ")]
        public bool CUS_MEZ { get; set; }

        //The CUS_DEACTIVATED_COUNT property represents the number of times account deactivated.
        [Required]
        [Display(Name = "Deactivated Count")]
        public int CUS_DEACTIVATED_COUNT { get; set; }

        //The CUS_NOTE property represents the comments, important notes.
        [StringLength(100)]
        [Display(Name = "Notes")]
        public string? CUS_NOTE { get; set; }

        //The Addresses property is a navigation property.
        //The customer entity can be related to any number of Addresses entities.

        //The Permit property is a navigation property.
        //The customer entity can be related to any number of Permit entities.
        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Permit>? Permits { get; set; }

    }
}
