using sing_adapt_w61905.Interfaces;

namespace sing_adapt_w61905.Models;

public class VipRoom : IRoom
{
    public string RoomNumber { get; set; }
    public string ExtraServices { get; set; }
}