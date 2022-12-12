using Microsoft.EntityFrameworkCore;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Booking.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Booking.DomainServices
{
    public class BookingDomainService : IBookingDomainService
    {
        private readonly UnikContext _db;


        public BookingDomainService(UnikContext context)
        {
            _db = context;
        }

        IEnumerable<BookingEntity> IBookingDomainService.GetBookings(int medarbejderId)
        {
            return _db.BookingEntities.AsNoTracking().Where(a => a.MedarbejderId == medarbejderId);
        }

    }
}
