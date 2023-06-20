using sing_adapt_w61905.Interfaces;
using sing_adapt_w61905.Models;

namespace sing_adapt_w61905.Adapters;

public class ReservationAdapter : IReservationAdapter
{
    public IReservation AdaptReservation(IReservation reservation)
    {
        if (reservation is StandardReservation)
        {
            var room = new VipRoom { RoomNumber = reservation.Room.RoomNumber };
            return new VipReservation(room)
            {
                GuestName = reservation.GuestName,
                ArrivalDate = reservation.ArrivalDate,
                DepartureDate = reservation.DepartureDate
            };
        }
        else
        {
            var room = new StandardRoom { RoomNumber = reservation.Room.RoomNumber };
            return new StandardReservation(room)
            {
                GuestName = reservation.GuestName,
                ArrivalDate = reservation.ArrivalDate,
                DepartureDate = reservation.DepartureDate
            };
        }
    }
}