using ExamenParcial2.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamenParcial2.Data
{
    public class HotelContext : DbContext
    {
         public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
        {

        }
        public DbSet<tblCustomers> TBLCostumers {get; set;} 
        public DbSet<tblBookings> TBLBookings {get; set;}
        public DbSet<tblFacilitiesList> TBLFacilitiesList {get; set;}
        public DbSet<tblGuests> TBLGuests {get; set;}
        public DbSet<tblLINK_BookingsRooms> TBLLINK_BookingsRooms {get; set;}
        public DbSet<tblLINK_RoomsFacilities> TBLLINK_RoomsFacilities {get; set;}
        public DbSet<tblPaymentMethods> TBLPaymentMethods {get; set;}
        public DbSet<tblPayments> TBLPayments {get; set;}
        public DbSet<tblRoomBands> TBLRoomBands {get; set;}
        public DbSet<tblRoomTypes> TBLRoomTypes {get; set;}
        public DbSet<tblRoomPrices> TBLRoomPrices {get; set;}
        public DbSet<tblRooms> TBLRooms {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<tblCustomers>().ToTable("Customer");
            modelBuilder.Entity<tblBookings>().ToTable("Booking");
            modelBuilder.Entity<tblFacilitiesList>().ToTable("Facility");
            modelBuilder.Entity<tblGuests>().ToTable("Guest");
            modelBuilder.Entity<tblLINK_BookingsRooms>().ToTable("Link_BookingsRooms");
            modelBuilder.Entity<tblLINK_RoomsFacilities>().ToTable("Link_RoomsFacilities");
            modelBuilder.Entity<tblPaymentMethods>().ToTable("PaymentMethod");
            modelBuilder.Entity<tblPayments>().ToTable("Payment");
            modelBuilder.Entity<tblRoomBands>().ToTable("RoomBand");
            modelBuilder.Entity<tblRoomPrices>().ToTable("RoomPrice");
            modelBuilder.Entity<tblRooms>().ToTable("Room");
            modelBuilder.Entity<tblRoomTypes>().ToTable("RoomType");

            modelBuilder.Entity<tblLINK_BookingsRooms>().HasKey(c => new {c.IngBookingID, c.IngRoomID, c.IngGuestID});
            modelBuilder.Entity<tblLINK_RoomsFacilities>().HasKey(c => new {c.IngRoomID, c.IngFacilityID});

        }
    }
}