using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblPayments
    {
        [Key]
        [Display(Name="ID de pago")]
        public int IngPaymentID {get; set;}
        [Display(Name="ID de reservacion")]
        public int IngBookingID {get; set;}
        [Display(Name="ID de cliente")]
        public int IngCustomerID {get; set;}
        [Display(Name="ID metodo de pago")]
        public int IngPaymentMethodID {get; set;}
        [DataType(DataType.Currency)]
        [Column(TypeName="Money")]
        [Display(Name="Pago")]
        public decimal curPaymentAmount {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Comentarios")]
        public string memPaymentAmountComments {get; set;}
        public tblCustomers TblCustumers {get; set;}
        public tblPaymentMethods TblPaymentMethods {get; set;}
        public tblBookings TblBookings {get; set;}
    }
}