using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblLINK_BookingsRooms
    {
        public int IngBookingID {get; set;}
        public int IngRoomID {get; set;}
        public int IngGuestID {get; set;}
        public tblLINK_BookingsRooms TblLINK_BookingsRooms {get; set;}
        public tblRooms TblRooms {get; set;}
        public tblGuests TblGuests {get; set;}
    }
}