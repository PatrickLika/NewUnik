namespace Unik.Webapp.Infrastructure.Booking.Contract.Dto
{
    public class BookingIndexDto
    {
        public int Id { get; set; }
        public string MedarbejderNavn { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public string MedarbejderTitel { get; set; }
    }
}
