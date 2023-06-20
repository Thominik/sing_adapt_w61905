using sing_adapt_w61905.Interfaces;

namespace sing_adapt_w61905.Adapters;

public interface IReservationAdapter
{
    IReservation AdaptReservation(IReservation reservation);
}