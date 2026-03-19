using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
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

        // Crear Email del paciente
        Email patientEmail = new Email("johndoe@email.com");

        // Crear paciente
        Patient patient = new Patient("John Doe", patientEmail);

        // Crear Email del dentista
        Email dentistEmail = new Email("dentist@gmail.com");

        // Crear dentista
        Dentist dentist = new Dentist("Dr. Smith", dentistEmail);

        // Crear consultorio
        DentalOffice dentalOffice = new DentalOffice("Consultorio de limpieza dental");

        // Crear intervalo de tiempo
        TimeInterval timeInterval = new TimeInterval(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        // Crear cita (Appointment)
        Appointment appointment = new Appointment(
            patient.Id,
            dentist.Id,
            dentalOffice.Id,
            timeInterval
        );

        // Crear el repositorio de citas y el servicio de notificaciones
        var repository = new AppointmentRepository();
        //var notification = new EmailNotificationService(); // Modifcado
        //SmtpEmailService smtpEmailService = new SmtpEmailService()
        //var smtpEmailService = new SmtpEmailService();
        //var SendGridEmailServices = new SendGridIEmailService();//Nuevo
       
        //Practica
        var BrevoEmailServices = new BrevoIEmailService();

        //Enviar SMS
        TwilioISmsService twilioISmsService = new TwilioISmsService();



        // Crear el servicio de citas
        //AppointmentService appointmentService = new AppointmentService(repository, notification); //Modificado
        //AppointmentService appointmentService = new AppointmentService(repository, smtpEmailService)
        //AppointmentService appointmentService = new AppointmentService(repository, SendGridEmailServices);

        //Practica 
        AppointmentService appointmentService = new AppointmentService(repository, BrevoEmailServices, twilioISmsService);



        // Agendar la cita
        appointmentService.Schedule(appointment, patientEmail, patient);

        Console.ReadLine();
    }
}