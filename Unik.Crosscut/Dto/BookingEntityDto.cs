using System.ComponentModel.DataAnnotations;

namespace Unik.Crosscut.Dto;

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

