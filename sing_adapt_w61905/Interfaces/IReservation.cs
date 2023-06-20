namespace sing_adapt_w61905.Interfaces;

public interface IReservation
{
    IRoom Room { get; set; }
    string GuestName { get; set; }
    DateTime ArrivalDate { get; set; }
    DateTime DepartureDate { get; set; }
}