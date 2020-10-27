using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblRooms
    {
        [Key]
        [Display(Name="ID")]
        public int IngRoomID {get; set;}
        [Display(Name="ID Tipo")]
        public int IngRoomTypeID {get; set;}
        [Display(Name="ID Muebles")]
        public int IngRoomBandID {get; set;}
        [Display(Name="ID Precio")]
        public int IngRoomPriceID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Piso")]
        public string strFloor {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Notas")]
        public string memAdditionalNotes {get; set;}

        public tblRoomTypes TblRoomTypes {get; set;}
        public tblRoomBands TblRoomBands {get; set;}
        public tblRoomPrices TblRoomPrices {get; set;}
        public ICollection<tblLINK_BookingsRooms> TblLINK_BookingsRooms {get; set;}
        public ICollection<tblLINK_RoomsFacilities> TblLINK_RoomsFacilities {get; set;}

    }
}

//dotnet aspnet-codegenerator controller -name tblCustomerController -m ExamenParcial2.Models.tblCustomers -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblBookingController -m ExamenParcial2.Models.tblBookings -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblFacilitiesListController -m ExamenParcial2.Models.tblFacilitiesList -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblGuestController -m ExamenParcial2.Models.tblGuests -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblRoomController -m ExamenParcial2.Models.tblRooms -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblPaymentController -m ExamenParcial2.Models.tblPayments -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblCustomerController -m ExamenParcial2.Models.tblCustomers -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblCustomerController -m ExamenParcial2.Models.tblCustomers -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblCustomerController -m ExamenParcial2.Models.tblCustomers -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
//dotnet aspnet-codegenerator controller -name tblCustomerController -m ExamenParcial2.Models.tblCustomers -dc ExamenParcial2.Data.HotelContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f