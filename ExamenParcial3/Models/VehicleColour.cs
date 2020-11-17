using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial3.Models
{
    public class VehicleColour
    {
        [Key]
        [Display(Name="ID")]
        public int ColourID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Color")]
        public string ColourName {get; set;}

        public ICollection<VehicleDetail> VehicleDetails {get; set;}
    }
}