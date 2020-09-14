using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReturneeManagement.Models
{
    public class TravelListsMetadata
    {
        //[Required] //dont need it null
        [StringLength(100)]
        [Display(Name = "Flight/Vessel")]
        public string FlightVessel { get; set; }
        [StringLength(10, ErrorMessage = "Flight code cannot be longer than 10 characters.")]
        [Display(Name = "Flight Code")]
        public string FlightCode { get; set; }
        [Column("Arrival Date")]
        [Display(Name = "Arrival Date")]
        public System.DateTime ArrivalDate { get; set; }
    }

    [MetadataType(typeof(TravelListsMetadata))]
    public partial class TravelList
    {

    }
}