using Unik.Webapp.Infrastructure.Booking.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Booking.Contract.Dto
{
    public interface IBookingService
    {
        Task Create(BookingCreateRequestDto dto);
        Task Edit (BookingEditRequestDto dto);
        Task Delete(int id);
        Task <BookingResultDto> Get(int bookingId);
        Task <IEnumerable<BookingResultDto>?> GetAll();
        Task <IEnumerable<FindMedarbejderDto>?> FindMedarbejder(string type);

    }
}
