namespace HotelRealQuito.Factory;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;
using HotelRealQuito.Strategy;

// Fabrica que crea reservas y asigna la estrategia de tarifa correcta
public class ReservationFactory
{
    // Crea una reserva y devuelve la estrategia que le corresponde
    public static (Reservation reservation, IRateStrategy strategy) CreateReservation(
        string id,
        string guestName,
        string roomType,
        int nights,
        string rateType)
    {
        // Crear la reserva con estado inicial Creada
        Reservation reservation = new Reservation
        {
            Id = id,
            GuestName = guestName,
            RoomType = roomType,
            Nights = nights,
            RateType = rateType,
            Status = ReservationStatus.Creada,
            TotalCost = 0.0
        };

        // Asignar la estrategia segun el tipo de tarifa
        IRateStrategy strategy = rateType.ToLower() switch
        {
            "temporadaalta" => new RackRateStrategy(),
            "temporadabaja" => new LowSeasonRateStrategy(),
            "corporativa" => new CorporateRateStrategy(),
            _ => throw new ArgumentException(
                $"Tipo de tarifa no valido: '{rateType}'. " +
                $"Los tipos validos son: temporadaAlta, temporadaBaja, corporativa.")
        };

        Console.WriteLine(
            $"[Fabrica] Reserva {id} creada para {guestName} " +
            $"| Habitacion: {roomType} | Noches: {nights} " +
            $"| Tarifa: {rateType}");

        return (reservation, strategy);
    }
}
