namespace HotelRealQuito.Observer;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;

// Notificador que envia un email al huesped cuando cambia el estado
public class EmailReservationNotifier : IReservationObserver
{
    public void OnStatusChanged(Reservation reservation, ReservationStatus newStatus)
    {
        Console.WriteLine(
            $"[Email] Notificacion enviada a {reservation.GuestName}: " +
            $"su reserva {reservation.Id} ha cambiado a estado {newStatus}.");
    }
}
