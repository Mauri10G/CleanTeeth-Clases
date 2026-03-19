using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications;
using SOLIDPrinciples.Infrastructure.Persistence;
using System.Net.Mail;

namespace SOLIDPrinciples.Application.Services;

public class AppointmentService
{
    private List<Appointment> _appointments = new List<Appointment>();

    private readonly AppointmentRepository _repository;
    //private readonly EmailNotificationService _notification;  //Modificado
    private readonly IEmailService _emailService; //Nuevo
    //Nuevo requerimiento
    private readonly IsmsServices _ismsService;

    //Modificado

    //public AppointmentService(
    //    AppointmentRepository repository,
    //    EmailNotificationService notification
    //)
    //{
    //    _repository = repository;
    //    _notification = notification;
    //}

    //public AppointmentService(
    //    AppointmentRepository repository,
    //    IEmailService emailService
    //)
    //{
    //    _repository = repository;
    //    _emailService = emailService;
    //}

    public AppointmentService(
        AppointmentRepository repository,
        IEmailService emailService,
        IsmsServices ismsServices
    )
    {
        _repository = repository;
        _emailService = emailService;
        _ismsService = ismsServices;
    }


    //Modificado
    //public void Schedule(Appointment appointment, Email patientEmail)
    //{
    //    Console.WriteLine("Programar cita...");

    //    // VALIDACIÓN REGLA DE NEGOCIO: Verificar que el dentista no tenga otra cita en el mismo horario
    //    //Esto esta mal ensañado porque estoy dehando una deuda tecnica
    //    if (
    //        _appointments.Any(a =>
    //            a.DentistId == appointment.DentistId
    //            && a.TimeInterval.Start == appointment.TimeInterval.Start
    //        )
    //    )
    //    {
    //        Console.WriteLine("El dentista está ocupadO en ese momento.");
    //        return;
    //    }

    //    // AGREGAR LA CITA AL LISTADO DE CITAS
    //    _appointments.Add(appointment);

    //    // GUARDAR EN ARCHIVO
    //    _repository.Save(appointment);

    //    // ENVIAR CORREO ELECTRÓNICO AL PACIENTE
    //    //_notification.Send(patientEmail); //Modificado

    //    _emailService.Send(patientEmail);   //Nuevo

    //    // VISUALIZAR MENSAJE DE CONFIRMACIÓN
    //    Console.WriteLine("Cita programada con éxito.");
    //}



    //Nuevo
    public void Schedule(Appointment appointment, Email patientEmail, Patient patient)
    {
        Console.WriteLine("Programar cita...");

        // VALIDACIÓN REGLA DE NEGOCIO: Verificar que el dentista no tenga otra cita en el mismo horario
        //Esto esta mal ensañado porque estoy dehando una deuda tecnica
        if (
            _appointments.Any(a =>
                a.DentistId == appointment.DentistId
                && a.TimeInterval.Start == appointment.TimeInterval.Start
            )
        )
        {
            Console.WriteLine("El dentista está ocupadO en ese momento.");
            return;
        }

        // AGREGAR LA CITA AL LISTADO DE CITAS
        _appointments.Add(appointment);

        // GUARDAR EN ARCHIVO
        _repository.Save(appointment);

        // ENVIAR CORREO ELECTRÓNICO AL PACIENTE
        //_notification.Send(patientEmail); //Modificado

        _emailService.Send(patientEmail);   //Nuevo

        //Nuevo requerimiento 
        //Enviar sms al paciente
        _ismsService.Send(patient);


        // VISUALIZAR MENSAJE DE CONFIRMACIÓN
        Console.WriteLine("Cita programada con éxito.");
    }
}
