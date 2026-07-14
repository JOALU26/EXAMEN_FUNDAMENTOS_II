namespace HotelRealQuito.Patterns;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;
using HotelRealQuito.Factory;

// Servicios crear reserva, calcular costo, guardar y notificar
public class ReservationService
{
    private readonly IReservationRepository _repository;
    private readonly List<IReservationObserver> _observers = new List<IReservationObserver>();

    // Recibe el repositorio por inyeccion de dependencias
    public ReservationService(IReservationRepository repository)
    {
        _repository = repository;
    }

    // Agrega un observador para recibir notificaciones
    public void Subscribe(IReservationObserver observer)
    {
        _observers.Add(observer);
    }

    // Quita un observador para que deje de recibir notificaciones
    public void Unsubscribe(IReservationObserver observer)
    {
        _observers.Remove(observer);
    }

    // Avisa a todos los observadores que cambio el estado
    private void NotifyObservers(Reservation reservation, ReservationStatus newStatus)
    {
        foreach (var observer in _observers)
        {
            observer.OnStatusChanged(reservation, newStatus);
        }
    }

    // Metodo principal que orquesta todo el proceso de una reserva
    public Reservation ProcessReservation(
        string id,
        string guestName,
        string roomType,
        int nights,
        string rateType)
    {
        //Crear la reserva usando la Fabrica
        var (reservation, strategy) = ReservationFactory.CreateReservation(
            id, guestName, roomType, nights, rateType);

        //Calcular el costo total con la estrategia correspondiente
        reservation.TotalCost = strategy.CalculateCost(reservation);

        //Guardar la reserva en el repositorio
        _repository.Save(reservation);

        //Cambiar el estado a Confirmada
        reservation.Status = ReservationStatus.Confirmada;

        //Notificar a los observadores del cambio de estado
        NotifyObservers(reservation, ReservationStatus.Confirmada);

        return reservation;
    }
}
