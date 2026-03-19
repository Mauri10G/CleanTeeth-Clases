
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

internal class SmtpEmailService : IEmailService
{
    public void Send(Email email)
    {
        //Logica de envio...
        Console.WriteLine($"Email enviado para: {email.Value}");
    }
}
