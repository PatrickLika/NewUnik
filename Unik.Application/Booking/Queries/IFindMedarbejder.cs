namespace Unik.Applicaiton.Booking.Queries
{
    public interface IFindMedarbejder
    {
        IEnumerable<FindMedarbejderDto> FindMedarbejder(string type);
    }
}
