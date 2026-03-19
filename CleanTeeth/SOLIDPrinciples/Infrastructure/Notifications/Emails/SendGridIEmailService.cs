
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

public class SendGridIEmailService : IEmailService
{
    public void Send(Email email)
    {
        //Logica de envio...
        Console.WriteLine($"SendGrid Email enviado para: {email.Value}");
    }
}
