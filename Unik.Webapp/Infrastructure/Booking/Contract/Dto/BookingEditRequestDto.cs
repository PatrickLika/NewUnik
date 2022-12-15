using System.ComponentModel.DataAnnotations;

namespace Unik.WebApp.Infrastructure.Booking.Contract.Dto;

public class BookingEditRequestDto
{
    public int Id { get; set; }
    public int ProjektNr { get; set; }
    public int Opgaver { get; set; }
    public int MedarbejderId { get; set; }
    public DateTime Dato { get; set; }
    public int Varighed { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}