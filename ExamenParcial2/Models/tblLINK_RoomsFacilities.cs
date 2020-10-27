namespace ExamenParcial2.Models
{
    public class tblLINK_RoomsFacilities
    {
        public int IngRoomID {get; set;}
        public int IngFacilityID {get; set;}
        public string strFacilityDetails {get; set;}
        
        public tblFacilitiesList TblFacilitiesList {get; set;}
        public tblRooms TblRooms {get; set;}
    }
}