using Moq;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Booking.Model;

namespace Unik.Domain.Tests.BookingEntityTest
{
    public class BookingEntityCreateTest
    {
        private readonly Mock<IBookingDomainService> domainServiceMock;

        public BookingEntityCreateTest()
        {
            domainServiceMock = new Mock<IBookingDomainService>();//opsætning af domain service
            var eksiterendeBookiongs = new List<BookingEntity>(new[]
            {
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)) // 1. jan 2023 til 1. feb 2023
            });
            domainServiceMock.Setup(a => a.GetBookings(It.IsAny<int>()))
                .Returns(eksiterendeBookiongs);
        }

        [Theory]
        [InlineData("2023-01-10", "2023-04-20")]// hvis stardato lige indenfor booking
        [InlineData("2022-01-10", "2023-01-20")]// hvis slut dato ligger indenfor booking
        [InlineData("2023-01-10", "2023-01-20")]// hvis begge datoer ligger indenfor booking
        [InlineData("2022-01-10", "2024-01-20")]// hvis begge datoer ligger udenfor booking
        public void Given_DoubleBooking_Then_Throw_Exception(string startDatotext, string slutDatotext)
        {
            //Arrange
            var startDato = DateTime.Parse(startDatotext);
            var slutDato = DateTime.Parse(slutDatotext);
            //Act
            var action = () => new BookingEntity(domainServiceMock.Object, 1, 1, startDato, slutDato);//Det er meget vigtigt at man skriver .object, ellers tager den ikke mock objektet
            //Assert
            Assert.Throws<ArgumentException>(action);//Tjekker for den exception som bliver smidt i booking entity når vi kalder IsDoubleBooking() i booking entity
        }


        [Theory]
        [InlineData("2022-01-10", "2022-04-20")]// hvis datoerne var før booking
        [InlineData("2024-01-10", "2024-01-20")]// hvis Datoerne var efter booking
        [InlineData("2023-02-01", "2023-04-01")]// hvis start dato start på slut dato
        [InlineData("2022-01-10", "2023-01-1")]//  Hvis Slutdato slutter på startdato
        public void Given_No_DoubleBooking_Then_Dont_Throw_Exception(string startDatotext, string slutDatotext)
        {
            //Arrange

            var startDato = DateTime.Parse(startDatotext);
            var slutDato = DateTime.Parse(slutDatotext);
            //Act
            var exception = Record.Exception(() => new BookingEntity(domainServiceMock.Object, 1, 1, startDato, slutDato));//Den "optager/records" om der er en exception, men vi ved den er null, så vi tjekker for null i assert
            //Assert
            Assert.Null(exception);
        }
    }
}
