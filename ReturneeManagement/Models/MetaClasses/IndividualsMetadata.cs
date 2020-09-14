using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReturneeManagement.Models
{
    public class IndividualsMetadata
    {
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        [Column("Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        [Column("First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Column("Middle Name")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public System.DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        [Column("Civil Status")]
        [Display(Name = "Civil Status")]
        public string CivilStatus { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        [Column("Telephone No")]
        [Display(Name = "Telephone No")]
        public string TelepnoeNo { get; set; }
        [Required]
        [Column("Moble No")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        public Nullable<Guid> AddressID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName + " " + MiddleName; }
        }
    }

    [MetadataType(typeof(IndividualsMetadata))]
    public partial class Individual
    {

    }
}