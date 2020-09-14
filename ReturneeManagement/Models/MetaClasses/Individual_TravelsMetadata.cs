using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReturneeManagement.Models
{
    public class Individual_TravelsMetadata
    {
        [StringLength(50)]
        [Column("Travel Type")]
        [Display(Name = "Travel Type")]
        public string TravelType { get; set; }
    }

    [MetadataType(typeof(Individual_TravelsMetadata))]
    public partial class Individual_Travel
    {

    }
}