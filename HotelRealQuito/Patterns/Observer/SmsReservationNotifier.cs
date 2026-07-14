namespace HotelRealQuito.Observer;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;

// Notificador que envia un SMS al huesped cuando cambia el estado
public class SmsReservationNotifier : IReservationObserver
{
    public void OnStatusChanged(Reservation reservation, ReservationStatus newStatus)
    {
        Console.WriteLine(
            $"[SMS] Mensaje enviado a {reservation.GuestName}: " +
            $"su reserva {reservation.Id} ahora esta en estado {newStatus}.");
    }
}
