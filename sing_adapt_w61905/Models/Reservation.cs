namespace sing_adapt_w61905.Models;

public class Reservation
{
    public string RoomNumber { get; private set; }
    public string GuestName { get; private set; }
    public DateTime ArrivalDate { get; private set; }
    public DateTime DepartureDate { get; private set; }

    public Reservation(string roomNumber, string guestName, DateTime arrivalDate, DateTime departureDate) 
    {
        RoomNumber = roomNumber;
        GuestName = guestName;
        ArrivalDate = arrivalDate;
        DepartureDate = departureDate;
    }
}