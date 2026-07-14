namespace HotelRealQuito.Strategy;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;

// Temporada baja: $80 por noche con 15% de descuento
public class LowSeasonRateStrategy : IRateStrategy
{
    private const double PricePerNight = 80.0;
    private const double Discount = 0.85; // 15% de descuento

    public double CalculateCost(Reservation reservation)
    {
        double cost = PricePerNight * Discount * reservation.Nights;
        Console.WriteLine($"[Tarifa Baja] ${PricePerNight} x {reservation.Nights} noches - 15% descuento = ${cost:F2}");
        return cost;
    }
}
