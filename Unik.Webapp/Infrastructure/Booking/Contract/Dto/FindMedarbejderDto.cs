namespace Unik.Webapp.Infrastructure.Booking.Contract.Dto
{
    public class FindMedarbejderDto
    {
        public int MedarbejderId { get; set; }
        public DateTime startDato { get; set; }
        public DateTime SlutDato { get; set;}
    }
}
