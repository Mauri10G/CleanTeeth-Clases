using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Persistence;

public class FileAppointmentRepository : IAppointmentRepository // Nombre más descriptivo
{
    public void Save(Appointment appointment)
    {
        File.AppendAllText("appointments.txt", appointment.Id + Environment.NewLine);
    }
}