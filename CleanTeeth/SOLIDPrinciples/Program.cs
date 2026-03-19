using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Application.Services;
//using SOLIDPrinciples.Infrastructure.Notifications;
using SOLIDPrinciples.Infrastructure.Notifications.Emails;
using SOLIDPrinciples.Infrastructure.Notifications.Sms;
using SOLIDPrinciples.Infrastructure.Persistence;

namespace SOLIDPrinciples;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║  PRINCIPIOS SOLID                                                                           ║");
        Console.WriteLine("║  PASO 2: INGLEINTERFACE SEGREGATION PRINCIPLE ISP - PRINCIPIO DE SEGREGACION DE INTERFACES  ║");
        Console.WriteLine("║  Sistema CleanTeeth - REFACTORIZADO                                                         ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════╝\n");

        // 1. Crear Objetos de Dominio
        Email patientEmail = new Email("johndoe@email.com");
        Patient patient = new Patient("John Doe", patientEmail);
        Email dentistEmail = new Email("dentist@gmail.com");
        Dentist dentist = new Dentist("Dr. Smith", dentistEmail);
        DentalOffice dentalOffice = new DentalOffice("Consultorio de limpieza dental");
        TimeInterval timeInterval = new TimeInterval(DateTime.UtcNow.AddHours(1), DateTime.UtcNow.AddHours(2));

        Appointment appointment = new Appointment(patient.Id, dentist.Id, dentalOffice.Id, timeInterval);

        // 2. Instanciar Dependencias (Infraestructura)
        // Aquí es donde aplicamos lo que pidió tu ingeniero: usamos la interfaz
        IAppointmentRepository repository = new FileAppointmentRepository();

        // Servicios de notificación
        var brevoEmailServices = new BrevoIEmailService();
        var twilioISmsService = new TwilioISmsService();

        // 3. Crear el servicio de citas (Inyectando las dependencias)
        // Ahora sí, las variables ya existen antes de usarlas aquí
        var appointmentService = new AppointmentService(repository, brevoEmailServices, twilioISmsService);

        // 4. Ejecutar la acción
        appointmentService.Schedule(appointment, patientEmail, patient);

        Console.ReadLine();
    }
}