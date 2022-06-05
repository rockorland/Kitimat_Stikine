using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RDKSDatabase.Models

{
    /// <summary>
    /// The Permit class which has all the attributes of the Permit table.
    /// PermitId is the primary key.
    /// </summary>
    public enum FacilityCode
    {
        
        ML=53600902,
        HWMF=53600901,
        FRWMF=536008

    }
    public enum Units
    {
        Bags,
        Imperial_Gallon,
        Kg,Lbs,Litre,
        Cubic_Meter,Tonnes,US_Gallon,Cubic_Yard
    }

    public enum Frequency
    {
        Bi_Weekly,
        Bi_Monthly,
        Weekly,
        Monthly,
        Daily,
        Once

    }

    public enum PermitSentToOperatorAndWMF
    {
        Yes,
        Pending
    }

    public enum HardCopyPermitSavedInFile
    {
        Y,N
    }

    public enum PermitSavedOnServerAndFiled
    {
        Y, N
    }

    public enum PermitStatus
    {
        Semi_Annual,
        Single_Event,
        Annual,
        Multi_Day

    }

    public enum ApplicationFeeInvoiced
    {
        Y,N
    }

    public enum ContaminatedLoads
    {
        One = 1,
        Two = 2
    }
    public class Permit
    {
        //The PermitNumberPrefix property represents the permit prefix based on facility
        //Used for the Primary Key
        [Required]
        [Display(Name ="Permit Prefix")]
        public int PermitNumberPrefix { get; set; }

        //The PermitNumber property represents the permit number based on permit number prefix
        //Used for the Primary Key
        [Required]
        [Display(Name ="Permit Number")]
        public int PermitNumber { get; set; }

        //The FacilityCode property represents the facility
        [Display(Name ="Facility Code")]
        [Required]
        public string? FacilityCode { get; set; }

        //The PermitApplicationDate property represents the date the permit application is made
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM-dd-yyyy}",ApplyFormatInEditMode =true)]
        [Display(Name ="Permit Application Date")]
        public  DateTime? PermitApplicationDate { get; set; }

        //The EstimatedVolume property represents the estimated waste volume
        [Range(0,float.MaxValue)]
        [Display(Name ="Estimated Volume")]
        public float EstimatedVolume { get; set; }

        //The units property represents the waste unit
        public string? units { get; set; }

        //The EstimatedLoads property represents the estimated waste load

        [Range(0,int.MaxValue)]
        public int? EstimatedLoads { get; set; }

        //The Frequency property represents the period the permit is valid for.
        public string? Frequency { get; set; }

        //The Comments property represents the additional comments about a certain waste
        public string? Comments { get; set; }

        //The ContaminateLoadsDate property represents the date of contaminated waste

        [Display(Name ="Contaminated Loads Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ContaminateLoadsDate { get; set; }

        //The ContaminateLoadsComments property represents the comment about the contaminated waste

        [Display(Name = "Contaminate Loads Comments")]
        public string? ContaminateLoadsComments { get; set; }

        //The ContaminatedLoads property represents the load of the contaminated waste

        [Display(Name = "Contaminated Loads")]
        [Range(0,int.MaxValue)]
        public int? ContaminatedLoads { get; set; }


        //The PermitSentToOperatorAndWMF property represents whether the permit has been sent to the operator and WMF

        [Display(Name = "Permit Sent To Operator And WMF")]
        public string? PermitSentToOperatorAndWMF { get; set; }


        //The PermitSavedOnServerAndFiled property represents whether the permit has been saved on the server and filed

        [Display(Name = "Permit Saved On Server And Filed")]

        public string? PermitSavedOnServerAndFiled { get; set; }

        //The HardCopyPermitSavedInFile property represents whether there is hardcopy of the permit saved in file

        [Display(Name = "Hard Copy Permit Saved In File")]

        public string? HardCopyPermitSavedInFile { get; set; }

        //The ApprovedBy property represents whether the person approve the permit

        [Display(Name = "Approved By")]

        public string? ApprovedBy { get; set; }

        //The PermitClosedCardPermissionsRevolked property represents whether the permit has been revolked

        [Display(Name = "Permit Closed Card Permissions Revolked")]
        public string? PermitClosedCardPermissionsRevolked { get; set; }

        //The PermitStatus property represents the permit status period

        [Required]
        [Display(Name = "Permit Status")]
        public string? PermitStatus{ get; set; }

        //The PermitType property represents the permit type
        [Required]
        [Display(Name = "Permit Type")]
        public string? PermitType { get; set; }

        //The PermitFee property represents the fee associated the permit
        [Required]
        [Display(Name = "Permit Fee")]
        public float PermitFee { get; set; }

        //The ExpirationDate property represents the expiration date
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }


        //The ApplicationFeeInvoiced property represents whether the fee has been invoiced
        [Required]
        [Display(Name = "Application Fee Invoiced")]
        public string? ApplicationFeeInvoiced { get; set; }

        //The ApplicationFeeInvoiced property represents whether the fee has been invoiced
        [Display(Name = "Applicant Name")]
        [Required]
        public string? ApplicantName { get; set; }


        //The ApplicantPhone property represents the phone of the applicant
        [Display(Name = "Applicant Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        
        public string? ApplicantPhone { get; set; }

        //The ApplicantEmail property represents the ApplicantEmail of the applicant
        [Display(Name = "Applicant Email")]
       
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? ApplicantEmail { get; set; }

        //The Hauler property represents the hauler of the waste
        public string? Hauler { get; set; }
        //The Hauler property represents the hauler of the waste
        public string? Hauler2 { get; set; }

        //The CUS_ID property represents FK referencing Customer table
        
        [Column("Customer ID")]
        [Display(Name ="Customer ID")]
        public int CUS_ID { get; set; }
        public Customer? Customer { get; set; }

        //The WasteGenerator property represents FK referencing WasteSource table
        [Required]
        [Column("Waste Generator")]
        public string WasteGenerator { get; set; }
        public WasteSource? WasteSource { get; set; }

        //The MaterialCode property represents FK referencing Material table
        [Required]
        public int MaterialCode { get; set; }
        [ForeignKey("MaterialCode")]
        public Material Material { get; set; }
        public string? MaterialType { get; internal set; }
    }
}
