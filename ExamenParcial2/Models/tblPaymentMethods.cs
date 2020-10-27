using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblPaymentMethods
    {
        [Key]
        public int IngPaymentMethodID {get; set;}
        [StringLength(50, MinimumLength=3)]
        public string txtPaymentMethod {get; set;}

        public ICollection<tblPayments> TblPayments {get; set;}
        
    }
}