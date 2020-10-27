using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblBookings
    {
        [Key]
        [Display(Name="ID")]
        public int IngBookingID {get; set;}
        [Display(Name="ID Cliente")]
        public int IngCustomerID {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Fecha de reservacion")]
        public DateTime dteDateBookingMade {get; set;}
        [Display(Name="Dias de reservacion")]
        public int tmeTimeBookingMade {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Inicio de reservacion")]
        public DateTime dteBookedStartDate {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Fin de la reservacion")]
        public DateTime dteBookedEndDate {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Fecha de deuda")]
        public DateTime dteTotalPaymentDueDate {get; set;}
        [DataType(DataType.Currency)]
        [Column(TypeName="Money")]
        [Display(Name="Total de deuda")]
        public decimal curTotalPaymentDueAmount {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Fecha de Pago")]
        public DateTime dterTotalPaymentMadeOn {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Comentarios")]
        public string memBookingComments {get; set;}
        
        public tblCustomers TblCustomers {get; set;}
        public ICollection<tblPayments> TblPayments {get; set;}
        public ICollection<tblLINK_BookingsRooms> TblLINK_BookingsRooms {get; set;}
    }
}