
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

public class BrevoIEmailService : IEmailService
{
    public void Send(Email email)
    {
        //Logica de envio...
        Console.WriteLine($"Brevo Email enviado para: {email.Value}");
    }
}
