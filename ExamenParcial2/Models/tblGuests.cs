using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblGuests
    {
        [Key]
        [Display(Name="ID")]
        public int IngGuestID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Titulo")]
        public string txtGuestTitle {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Nombre")]
        public string txtGuestForenames {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Apellido")]
        public string txtGuestSurnames {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Fecha de reservacion")]
        public DateTime dteGuestDOB {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Direccion")]
        public string txtGuestAddressStreet {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Ciudad")]
        public string txtGuestAddressTown {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Pais")]
        public string txtGuestAddressCountry {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Codigo Postal")]
        public string txtGuestAddressPostalCode {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Telefono")]
        public string txtGuestContactPhone {get; set;}

        public ICollection<tblLINK_BookingsRooms> TblLINK_BookingsRooms {get; set;}
    }
}