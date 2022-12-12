using System.ComponentModel.DataAnnotations;

namespace Unik.WebApp.Infrastructure.Booking.Contract.Dto
{
    public class BookingCreateRequestDto
    {
        public int Id { get; set; }

        public int ProjektNr { get; set; }
        public int Opgaver { get; set; }
        public int MedarbejderNr { get; set; }
        public DateTime Dato { get; set; }
        public int Varighed { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
    }
}
