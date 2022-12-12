using Moq;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Booking.Model;

namespace Unik.Domain.Tests.BookingEntityTest
{
    public class BookingEntityCreateTest
    {
        private readonly IBookingDomainService _domainService;

        Mock<IBookingDomainService> test = new Mock<IBookingDomainService>();
        public BookingEntityCreateTest(IBookingDomainService domainService)
        {

            var eksiterendeBookiongs = new List<BookingEntity>(new[]
            {
                new BookingEntity(_domainService,1,new DateTime(2023, 1, 1, 1, 0, 0), new DateTime(2022, 1, 1, 3, 0, 0)),
                new BookingEntity(_domainService,1, new DateTime(2023, 1, 1, 5, 0, 0), new DateTime(2022, 1, 1, 6, 0, 0))
            });


           test.Setup(foo => foo.GetBookings(1)).Returns(eksiterendeBookiongs);


        }

        [Fact]
        public void Given_StartDato_is_valid_Then_BookingEntity_is_Created()
        {
            //Arrange
            var startDato = DateTime.Parse("2023-1-1 04:00");
            var slutdato = DateTime.Parse("2023-1-1 04:59");

            //Act
           // var sut = new BookingEntity(test,1, startDato, slutdato);
            //Assert
            
            
        }
    }
}
