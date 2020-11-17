using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial3.Models
{
    public class VehicleFuelType
    {
        [Key]
        [Display(Name="ID de combustible")]
        public int FuelTypeID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Nombre de combustible")]
        public string FuelTypeName {get; set;}

        public ICollection<VehicleDetail> VehicleDetails {get; set;}
    }
}