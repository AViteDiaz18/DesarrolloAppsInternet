using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial3.Models
{
    public class LinkFeatureToVehicle
    {
        [Display(Name="Clave")]
        public string CarRegistration {get; set;}
        [Display(Name="Caracteristica")]
        public int FeatureID {get; set;}
        [ForeignKey("CarRegistration")]
        
        public VehicleDetail VehicleDetail {get; set;}
        [ForeignKey("FeatureID")]
        public VehicleFeature VehicleFeature {get; set;}
    }
}