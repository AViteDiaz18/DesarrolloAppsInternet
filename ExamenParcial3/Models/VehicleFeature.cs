using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial3.Models
{
    public class VehicleFeature
    {
        [Key]
        [Display(Name="ID")]
        public int FeatureID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Caracteristicas")]
        public string FeatureDescription {get; set;}

        public ICollection<LinkFeatureToVehicle> LinkFeatureToVehicles {get; set;}
    }
}