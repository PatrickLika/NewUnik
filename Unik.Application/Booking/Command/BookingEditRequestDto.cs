using System.ComponentModel.DataAnnotations;

namespace Unik.Applicaiton.Booking.Command;

public class BookingEditRequestDto
{
    public int Id { get; set; }

    public int ProjektNr { get; set; }
    public int OpgaveId { get; set; }
    public int MedarbejderId { get; set; }
    public DateTime StartDato { get; set; }
    public DateTime SlutDato { get; set; }
    public int Varighed { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}