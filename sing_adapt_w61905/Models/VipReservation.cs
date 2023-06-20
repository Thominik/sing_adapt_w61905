using sing_adapt_w61905.Interfaces;

namespace sing_adapt_w61905.Models;

public class VipReservation : IReservation
{
    public IRoom Room { get; set; }
    public string GuestName { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    
    public VipReservation(VipRoom room)
    {
        Room = room;
    }
}