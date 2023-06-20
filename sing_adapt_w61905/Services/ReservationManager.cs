using sing_adapt_w61905.Interfaces;

namespace sing_adapt_w61905.Services;

public class ReservationManager
{
    private static ReservationManager _instance;
    private List<IReservation> reservations;

    private ReservationManager()
    {
        reservations = new List<IReservation>();
    }
    
    public static ReservationManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ReservationManager();
        }

        return _instance;
    }
    
    public void MakeReservation(IReservation reservation)
    {
        reservations.Add(reservation);
    }
    
    public void DisplayReservations()
    {
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"Rezerwacja: Pokój {reservation.Room.RoomNumber}, Gość: {reservation.GuestName}, Przyjazd: {reservation.ArrivalDate.ToShortDateString()}, Wyjazd: {reservation.DepartureDate.ToShortDateString()}");
        }
    }
}