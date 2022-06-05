using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDKSDatabase.Models
{
    /// <summary>
    /// The Vehicle class represents the information of the vehicle.
    /// </summary>
    public class Vehicle
    {
        //The LICENSE_PLATE property which is the PK represents the license plate of vehicle.
        [Key]
        [Display(Name = "License Plate")]
        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string? LICENSE_PLATE { get; set; }

        //The CUS_ID property is a foreign key,
        //and the corresponding corresponding navigation property is Customer.
        [Required]
        [Display(Name = "Customer ID")]
        public int CUS_ID { get; set; }
        [ForeignKey("CUS_ID")]
        public Customer? Customer { get; set; }

        //The DESCRIPTION property represents the desription of vehicle.
        [Display(Name = "Description")]
        public string? DESCRIPTION { get; set; }

        //The BADGE property represents the vehicle badge.
        [Display(Name = "Badge")]
        public string? BADGE { get; set; }

        //The NOTES property represents notes.
        [Display(Name = "Notes")]
        public string? NOTES { get; set; }

        //The NOTES_2 property represents notes.
        [Display(Name = "Notes2")]
        public string? NOTES_2 { get; set; }

        //The Transactions property is a navigation property.
        //The validation entity can be related to any number of Transactions entities.
        public ICollection<Transaction>? Transactions { get; set; }


    }
}
