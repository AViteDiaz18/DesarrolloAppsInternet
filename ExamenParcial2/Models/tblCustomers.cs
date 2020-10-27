using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial2.Models
{
    public class tblCustomers
    {
        [Key]
        [Display(Name="Cliente")]
        public int IngCustomerID{get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Titulo")]
        public string txtCustomerTitle{get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Nombre")]
        public string txtCustomerForenames {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Apellido")]
        public string txtCustomerSurnames {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Fecha de reservacion")]
        public DateTime dteCustomerDOB {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Direccion")]
        public string txtCustomerAddressStreet {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Ciudad")]
        public string txtCustomerAddressTown {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Pais")]
        public string txtCustomerAddressCountry {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Codigo Postal")]
        public string txtCustomerAddressPostalCode {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Numero de casa")]
        public string txtCustomerHomePhone {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Numero de trabajo")]
        public string txtCustomerWorkPhone {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Numero Celular")]
        public string txtCustomerMobilePhone {get; set;}
        [Display(Name="Email")]
        public string hypCustomerEmail {get; set;} 
        public ICollection<tblBookings> TblBookings {get; set;}
        public ICollection<tblPayments> TblPayments {get; set;}
    }
}