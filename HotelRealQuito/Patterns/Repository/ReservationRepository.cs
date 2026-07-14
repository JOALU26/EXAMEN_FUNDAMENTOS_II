namespace HotelRealQuito.Repository;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;

// Repositorio que guarda las reservas en memoria usando una lista
public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new List<Reservation>();

    // Guarda una nueva reserva en la lista
    public void Save(Reservation reservation)
    {
        _reservations.Add(reservation);
        Console.WriteLine($"[Repositorio] Reserva {reservation.Id} guardada correctamente.");
    }

    // Busca una reserva por su ID devuelve null si no existe
    public Reservation? GetById(string id)
    {
        return _reservations.FirstOrDefault(r => r.Id == id);
    }

    // Devuelve todas las reservas guardadas
    public List<Reservation> GetAll()
    {
        return _reservations;
    }

    // Actualiza el estado de una reserva existente
    public void UpdateStatus(string id, ReservationStatus newStatus)
    {
        Reservation? reservation = _reservations.FirstOrDefault(r => r.Id == id);
        if (reservation != null)
        {
            reservation.Status = newStatus;
            Console.WriteLine($"[Repositorio] Reserva {id} actualizada a estado: {newStatus}");
        }
    }
}
