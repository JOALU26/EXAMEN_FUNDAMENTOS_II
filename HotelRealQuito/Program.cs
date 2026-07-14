using HotelRealQuito.Models;
using HotelRealQuito.Observer;
using HotelRealQuito.Patterns;
using HotelRealQuito.Repository;

// Crear el repositorio y el servicio
ReservationRepository repository = new ReservationRepository();
ReservationService service = new ReservationService(repository);

// Crear los dos observadores
EmailReservationNotifier emailNotifier = new EmailReservationNotifier();
SmsReservationNotifier smsNotifier = new SmsReservationNotifier();

// Suscribir los observadores
service.Subscribe(emailNotifier);
service.Subscribe(smsNotifier);

Console.WriteLine("==========================================");
Console.WriteLine("=== Sistema de Reservas - Hotel Real Quito ===");
Console.WriteLine("==========================================\n");

// Crear reservas 

Console.WriteLine(">> Ejercicio 1: Crear reservas con diferentes tarifas\n");

// Reserva 1 temporada alta, 3 noches
Reservation res1 = service.ProcessReservation("RES-001", "Laura Gomez", "simple", 3, "temporadaAlta");
Console.WriteLine();

// Reserva 2 temporada baja, 2 noches
Reservation res2 = service.ProcessReservation("RES-002", "Pedro Salas", "doble", 2, "temporadabaja");
Console.WriteLine();

// Reserva 3 corporativa, 5 noches
Reservation res3 = service.ProcessReservation("RES-003", "Carmen Ruiz", "suite", 5, "corporativa");
Console.WriteLine();

//Notificar 

Console.WriteLine(">> Ejercicio 2: Verificar notificaciones y repositorio\n");

Console.WriteLine($"Reservas guardadas: {repository.GetAll().Count}");
Console.WriteLine();

// Resumen de cada reserva
foreach (Reservation r in repository.GetAll())
{
    Console.WriteLine(
        $"[Resumen] ID: {r.Id} | Huesped: {r.GuestName} " +
        $"| Habitacion: {r.RoomType} | Noches: {r.Nights} " +
        $"| Tarifa: {r.RateType} | Total: ${r.TotalCost:F2} " +
        $"| Estado: {r.Status}");
}

// Crear una excepcion 

Console.WriteLine("\n>> Ejercicio 3: Probar excepcion con tarifa invalida\n");

try
{
    Reservation res4 = service.ProcessReservation("RES-004", "Juan Perez", "simple", 2, "estudiante");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Excepcion controlada] {ex.Message}");
}

Console.WriteLine("\n==========================================");
Console.WriteLine("=== Fin del Sistema de Reservas ===");
Console.WriteLine("==========================================");
