

using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples.Application.Interfaces;

//nueva interfaz para manejar el nuevo requerimiento 
public interface IEmailService
{
    void Send(Email email);

}
