namespace HotelRealQuito.Interfaces;

using HotelRealQuito.Models;

// Interfaz para las estrategias de tarifa
public interface IRateStrategy
{
    double CalculateCost(Reservation reservation);
}
