namespace HotelRealQuito.Interfaces;

using HotelRealQuito.Models;

// Interfaz para el repositorio de reservas
public interface IReservationRepository
{
    void Save(Reservation reservation);
    Reservation? GetById(string id);
    List<Reservation> GetAll();
    void UpdateStatus(string id, ReservationStatus newStatus);
}
