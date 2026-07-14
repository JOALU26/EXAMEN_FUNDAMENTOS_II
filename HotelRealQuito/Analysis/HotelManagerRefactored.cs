namespace HotelRealQuito.Analysis;

using HotelRealQuito.Interfaces;
using HotelRealQuito.Models;
using HotelRealQuito.Patterns;

public class HotelManager
{
    private readonly ReservationService _service;

    public HotelManager(IReservationRepository repository)
    {
        _service = new ReservationService(repository);
    }

    // Ahora el metodo solo orquesta, delegando cada responsabilidad
    public Reservation HandleReservation(string id, string guest, string rateType, int nights)
    {

        return _service.ProcessReservation(id, guest, "doble", nights, rateType);
    }
}
