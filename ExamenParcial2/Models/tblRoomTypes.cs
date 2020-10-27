using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblRoomTypes
    {
        [Key]
        public int IngRoomTypeID {get; set;}
        [StringLength(50, MinimumLength=3)]
        public string strRoomType {get; set;}
        public ICollection<tblRooms> TblRooms {get; set;}
    }
}