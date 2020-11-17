using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial3.Models
{
    public class VehicleModel
    {
        [Key]
        [Display(Name="No de Modelo")]
        public int ModelID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Nombre de Modelo")]
        public string ModelName {get; set;}
        [Display(Name="Nombre de Fabricante")]
        public int ManufacterID {get; set;}
        [ForeignKey("ManufacterID")]
        public VehicleManufacter VehicleManufacter {get; set;}
        public ICollection<VehicleDetail> VehicleDetails {get; set;}
        
    }
}