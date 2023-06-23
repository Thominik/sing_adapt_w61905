using System.Globalization;
using sing_adapt_w61905.Adapters;
using sing_adapt_w61905.Interfaces;
using sing_adapt_w61905.Models;
using sing_adapt_w61905.Services;

IReservationAdapter adapter = new ReservationAdapter();
ReservationManager manager = ReservationManager.GetInstance(null);
manager.SetAdapter(adapter);

Console.WriteLine("Witaj w Hotelu Turion, potrzebujemy kilka informacji, aby dokonać rezerwacji.");
Console.Write("Podaj numer pokoju: ");
string roomNumber = Console.ReadLine();

Console.Write("Podaj imię i nazwisko gościa: ");
string guestName = Console.ReadLine();

Console.Write("Podaj datę przyjazdu (dd.MM.yyyy): ");
DateTime arrivalDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

if (arrivalDate < DateTime.Today)
{
    Console.WriteLine("Nie można dokonać rezerwacji na datę z przeszłości.");
    Console.WriteLine("Spróbuj ponownie.");
    arrivalDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
}

Console.Write("Podaj datę wyjazdu (dd.MM.yyyy): ");
DateTime departureDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

if (departureDate > DateTime.Today.AddMonths(12))
{
    Console.WriteLine("Nie można dokonać rezerwacji na termin późniejszy niż rok od dzisiaj.");
    Console.WriteLine("Spróbuj ponownie.");
    departureDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
}

Console.Write("Wybierz typ pokoju (1 - standard, 2 - VIP): ");
int roomType = int.Parse(Console.ReadLine());

IReservation reservation;
if (roomType == 1)
{
    var room = new StandardRoom { RoomNumber = roomNumber };
    reservation = new StandardReservation(room)
    {
        GuestName = guestName,
        ArrivalDate = arrivalDate,
        DepartureDate = departureDate
    };
}
else
{
    var room = new VipRoom { RoomNumber = roomNumber };
    reservation = new VipReservation(room)
    {
        GuestName = guestName,
        ArrivalDate = arrivalDate,
        DepartureDate = departureDate
    };

    Console.Write("Podaj dodatkowe usługi dla pokoju VIP: ");
    ((VipRoom)reservation.Room).ExtraServices = Console.ReadLine();
}


manager.MakeReservation(reservation);
manager.DisplayReservations();

Console.WriteLine("Dodatkowe usługi: ");

if (roomType != 1)
{
    Console.Write( ((VipRoom)reservation.Room).ExtraServices);
}
else
{
    Console.Write("Brak dodatkowych usług.");
}

Console.WriteLine("\nDziękujemy za dokonanie rezerwacji.");
