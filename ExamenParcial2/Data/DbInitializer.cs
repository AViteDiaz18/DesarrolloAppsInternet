using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExamenParcial2.Models;

namespace ExamenParcial2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TBLCostumers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new tblCustomers[]
            {
                new tblCustomers {IngCustomerID = 1010, txtCustomerTitle = "VIP Costumer", txtCustomerForenames = "Paris", txtCustomerSurnames = "Hilton", 
                dteCustomerDOB = DateTime.Parse("1995-03-11"), txtCustomerAddressStreet = "9256 Devon Street", txtCustomerAddressTown = "Brooklyn NY",
                txtCustomerAddressCountry = "USA", txtCustomerAddressPostalCode = "11229", txtCustomerHomePhone = "347-200-4648", txtCustomerMobilePhone = "347-203-3623", 
                txtCustomerWorkPhone = "347-218-8383", hypCustomerEmail = "paris_hilton@aol.com"}
            };

            foreach (tblCustomers c in customers)
            {
                context.TBLCostumers.Add(c);
            }
            context.SaveChanges();

            var booking = new tblBookings[]
            {
                new tblBookings {IngBookingID = 2020, dteDateBookingMade = DateTime.Parse("1996-01-02"), tmeTimeBookingMade = 3, dteBookedStartDate = DateTime.Parse("1996-01-12"), 
                dteBookedEndDate = DateTime.Parse("1996-09-12"), dteTotalPaymentDueDate = DateTime.Parse("1996-07-12"), curTotalPaymentDueAmount = 35000,
                dterTotalPaymentMadeOn = DateTime.Parse("1996-08-12"), memBookingComments = "Preferencial treatment", IngCustomerID = customers.Single( c => c.txtCustomerSurnames == "Hilton").IngCustomerID}
            };

            foreach (tblBookings b in booking)
            {
                context.TBLBookings.Add(b);
            }
            context.SaveChanges();

            var facilities = new tblFacilitiesList[]
            {
                new tblFacilitiesList {IngFacilityID = 4, strFacilityDesc = "Laundry Service"}
            }; 

            foreach (tblFacilitiesList f in facilities)
            {
                context.TBLFacilitiesList.Add(f);
            }
            context.SaveChanges();

            var paymentmethod = new tblPaymentMethods[]
            {
                new tblPaymentMethods {IngPaymentMethodID = 1, txtPaymentMethod = "Credit Card"}
            }; 

            foreach (tblPaymentMethods pm in paymentmethod)
            {
                context.TBLPaymentMethods.Add(pm);
            }
            context.SaveChanges();

            var payment = new tblPayments[]
            {
                new tblPayments {IngPaymentID = 1, IngBookingID = booking.Single(b => b.IngBookingID == 2020).IngBookingID,
                IngCustomerID = customers.Single(c => c.IngCustomerID == 1010).IngCustomerID, IngPaymentMethodID = paymentmethod.Single(pm => pm.IngPaymentMethodID == 1).IngPaymentMethodID,
                curPaymentAmount = 35000, memPaymentAmountComments = "All its fine"}
            }; 

            foreach (tblPayments p in payment)
            {
                context.TBLPayments.Add(p);
            }
            context.SaveChanges();

            var guest = new tblGuests[]
            {
                new tblGuests {IngGuestID = 444, txtGuestTitle = "President of USA", txtGuestForenames = "Donald", txtGuestSurnames = "Trump", dteGuestDOB = DateTime.Parse("1996-08-12"), 
                txtGuestAddressStreet = "674 W Lookout Ridge Dr", txtGuestAddressTown = "Washington", txtGuestAddressCountry = "USA", txtGuestAddressPostalCode = "98671", txtGuestContactPhone = "(360) 210-4088"}
            }; 

            foreach (tblGuests g in guest)
            {
                context.TBLGuests.Add(g);
            }
            context.SaveChanges();
            
            var roomtype = new tblRoomTypes[]
            {
                new tblRoomTypes {IngRoomTypeID = 1, strRoomType = "Presidential Suit"},
                new tblRoomTypes {IngRoomTypeID = 2, strRoomType = "VIP Suit"}
            }; 

            foreach (tblRoomTypes rt in roomtype)
            {
                context.TBLRoomTypes.Add(rt);
            }
            context.SaveChanges();

            var roomband = new tblRoomBands[]
            {
                new tblRoomBands {IngRoomBandID = 1, strBandDesc = "3 Beds"},
                new tblRoomBands {IngRoomBandID = 2, strBandDesc = "2 Beds"}
            }; 

            foreach (tblRoomBands rb in roomband)
            {
                context.TBLRoomBands.Add(rb);
            }
            context.SaveChanges();

            var roomprice = new tblRoomPrices[]
            {
                new tblRoomPrices {IngRoomPriceID = 1, curRoomPrice = 50000 },
                new tblRoomPrices {IngRoomPriceID = 2, curRoomPrice = 35000 }
            }; 

            foreach (tblRoomPrices rp in roomprice)
            {
                context.TBLRoomPrices.Add(rp);
            }
            context.SaveChanges();

            var room = new tblRooms[]
            {
                new tblRooms {IngRoomID = 301, IngRoomTypeID = roomtype.Single(rt => rt.IngRoomTypeID == 1).IngRoomTypeID, 
                IngRoomBandID = roomband.Single(rb => rb.IngRoomBandID == 1).IngRoomBandID, IngRoomPriceID = roomprice.Single(rp => rp.IngRoomPriceID == 1).IngRoomPriceID,
                strFloor = "24th Floor", memAdditionalNotes = "Notes"},
                  new tblRooms {IngRoomID = 356, IngRoomTypeID = roomtype.Single(rt => rt.IngRoomTypeID == 2).IngRoomTypeID, 
                IngRoomBandID = roomband.Single(rb => rb.IngRoomBandID == 2).IngRoomBandID, IngRoomPriceID = roomprice.Single(rp => rp.IngRoomPriceID == 2).IngRoomPriceID,
                strFloor = "31st Floor", memAdditionalNotes = "Notes"}
            }; 

            foreach (tblRooms r in room)
            {
                context.TBLRooms.Add(r);
            }
            context.SaveChanges();

            var linkRoomFacilities = new tblLINK_RoomsFacilities[]
            {
                new tblLINK_RoomsFacilities {IngRoomID = room.Single(r => r.IngRoomID == 301).IngRoomID, IngFacilityID = facilities.Single(f => f.IngFacilityID == 4).IngFacilityID, strFacilityDetails = "Detalles"},
                new tblLINK_RoomsFacilities {IngRoomID = room.Single(r => r.IngRoomID == 356).IngRoomID, IngFacilityID = facilities.Single(f => f.IngFacilityID == 4).IngFacilityID, strFacilityDetails = "detalles"}
            }; 

            foreach (tblLINK_RoomsFacilities rf in linkRoomFacilities)
            {
                context.TBLLINK_RoomsFacilities.Add(rf);
            }
            context.SaveChanges();

            var linkbookingroom = new tblLINK_BookingsRooms[]
            {
                new tblLINK_BookingsRooms {IngBookingID = booking.Single(b => b.IngBookingID == 2020).IngBookingID,
                IngRoomID = room.Single(r => r.IngRoomID == 356).IngRoomID, IngGuestID = guest.Single(g => g.IngGuestID == 444).IngGuestID}
            }; 

            foreach (tblLINK_BookingsRooms br in linkbookingroom)
            {
                context.TBLLINK_BookingsRooms.Add(br);
            }
            context.SaveChanges();

            
        }
    }
}