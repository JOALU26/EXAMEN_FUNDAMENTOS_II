namespace HotelRealQuito.Strategy;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;

// Tarifa corporativa: $60 por noche fijo, sin recargos ni descuentos
public class CorporateRateStrategy : IRateStrategy
{
    private const double PricePerNight = 60.0;

    public double CalculateCost(Reservation reservation)
    {
        double cost = PricePerNight * reservation.Nights;
        Console.WriteLine($"[Tarifa Corporativa] ${PricePerNight} x {reservation.Nights} noches = ${cost:F2}");
        return cost;
    }
}
