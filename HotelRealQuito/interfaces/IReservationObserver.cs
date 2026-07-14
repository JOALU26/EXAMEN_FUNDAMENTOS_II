namespace HotelRealQuito.Interfaces;

using HotelRealQuito.Models;

// Interfaz para los observadores de cambios de estado
public interface IReservationObserver
{
    void OnStatusChanged(Reservation reservation, ReservationStatus newStatus);
}
