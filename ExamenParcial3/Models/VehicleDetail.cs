using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial3.Models
{
    public class VehicleDetail
    {
        [Key]
        [Display(Name="ID de Registro")]
        public string CarRegistration {get; set;}
        [Display(Name="ID de Modelo")]
        public int ModelID {get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy}", ApplyFormatInEditMode=true)]
        [Display(Name="Año")]
        public DateTime ManufactureYear {get; set;}
        [Display(Name="ID de Color")]

        public int ColourID {get; set;}
        [Display(Name="ID de Combustible")]

        public int FuelTypeID {get; set;}

        [Required]
        [Display(Name="Kilometraje")]
        public double CurrentMilage {get; set;}
        [DataType(DataType.Currency)]
        [Column(TypeName="Money")]
        [Display(Name="Precio")]
        public decimal VehiclePrice {get; set;}

        [ForeignKey("ModelID")]
        
        public VehicleModel VehicleModel {get; set;}
        [ForeignKey("ColourID")]
        public VehicleColour VehicleColour {get; set;}

        [ForeignKey("FuelTypeID")]
        public VehicleFuelType VehicleFuelType {get; set;}
        
        public ICollection<LinkFeatureToVehicle> LinkFeatureToVehicles {get; set;}        
    }
}