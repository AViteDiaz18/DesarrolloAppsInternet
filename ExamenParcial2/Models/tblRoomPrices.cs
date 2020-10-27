using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblRoomPrices
    {
        [Key]
        public int IngRoomPriceID {get; set;}
        [DataType(DataType.Currency)]
        [Column(TypeName="Money")]
        public double curRoomPrice {get; set;}
        public ICollection<tblRooms> TblRooms {get; set;}
    }
}