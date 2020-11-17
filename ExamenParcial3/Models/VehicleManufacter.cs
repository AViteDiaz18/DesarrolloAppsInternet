using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial3.Models
{
    public class VehicleManufacter
    {
        [Key]
        [Display(Name="No de Fabricante")]
        public int ManufacterID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Nombre de Fabricante")]
        public string ManufacterName {get; set;}

        public ICollection<VehicleModel> VehicleModels {get; set;}
    }
}