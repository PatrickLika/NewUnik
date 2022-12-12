using System.ComponentModel.DataAnnotations;
using Unik.Domain.Booking.DomainServices;

namespace Unik.Domain.Booking.Model;

public class BookingEntityDto
{
    public int Id { get; set; }
    public int OpgaveId { get; set; }
    public int MedarbejderId { get; set; }
    public DateTime StartDato { get; set; }
    public DateTime SlutDato { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; private set; }
}

