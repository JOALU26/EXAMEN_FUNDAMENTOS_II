namespace HotelRealQuito.Strategy;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;

// Temporada alta: $80 por noche mas 20% de recargo
public class RackRateStrategy : IRateStrategy
{
    private const double PricePerNight = 80.0;
    private const double Surcharge = 1.2; // 20% de recargo

    public double CalculateCost(Reservation reservation)
    {
        double cost = PricePerNight * Surcharge * reservation.Nights;
        Console.WriteLine($"[Tarifa Alta] ${PricePerNight} x {reservation.Nights} noches + 20% recargo = ${cost:F2}");
        return cost;
    }
}
