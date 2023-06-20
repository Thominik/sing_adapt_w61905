using sing_adapt_w61905.Adapters;
using sing_adapt_w61905.Interfaces;

namespace sing_adapt_w61905.Services;

public class ReservationManager
{
    private static ReservationManager _instance;
    private List<IReservation> reservations;
    private IReservationAdapter _adapter;

    private ReservationManager(IReservationAdapter reservationAdapter)
    {
        reservations = new List<IReservation>();
    }
    
    public void SetAdapter(IReservationAdapter adapter)
    {
        _adapter = adapter;
    }
    
    public static ReservationManager GetInstance(IReservationAdapter adapter)
    {
        if (_instance == null || _instance._adapter == null)
        {
            _instance = new ReservationManager(adapter);
        }

        return _instance;
    }
    
    public void MakeReservation(IReservation reservation)
    {
        //reservations.Add(reservation);
        
        var adaptedReservation = _adapter.AdaptReservation(reservation);
        reservations.Add(adaptedReservation);
    }
    
    
    
    public void DisplayReservations()
    {
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"Rezerwacja: Pokój {reservation.Room.RoomNumber}, Gość: {reservation.GuestName}, Przyjazd: {reservation.ArrivalDate.ToShortDateString()}, Wyjazd: {reservation.DepartureDate.ToShortDateString()}");
        }
    }
}