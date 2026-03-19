
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Sms;

public class TwilioISmsService : IsmsServices
{
    public void Send(Patient patient)
    {
        //Logica de envio...
        Console.WriteLine($"SMS enviado por Twilio para: {patient.Name}");
    }
}
