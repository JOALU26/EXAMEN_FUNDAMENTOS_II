namespace HotelRealQuito.Models;

// Estados posibles de una reserva
public enum ReservationStatus
{
    Creada,
    Confirmada,
    EnCurso,
    Finalizada,
    Cancelada
}

// Modelo de reserva del Hotel Real Quito
public class Reservation
{
    public string Id { get; set; }
    public string GuestName { get; set; }
    public string RoomType { get; set; }
    public int Nights { get; set; }
    public string RateType { get; set; } 
    public ReservationStatus Status { get; set; }
    public double TotalCost { get; set; }
}
