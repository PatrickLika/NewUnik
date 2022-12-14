using Moq;
using Unik.Applicaiton.Booking.Repositories;
using Unik.Domain.Booking.Model;
using Unik.Domain.Kompetence.Model;
using Unik.Domain.Medarbejder.Model;

namespace Unik.Domain.Tests.BookingEntityTest
{

    public class FindMedarbejderTest
    {
        public readonly Mock<IBookingRepository> BookingRepositoryMock;
        public FindMedarbejderTest()
        {




        }
        [Theory]
        [InlineData("Sql")]
        public void Is_Give_Type_Then_Return_Medarbejde_Som_Kan_Bookes(string type)
        {
            //Arrange
            var expectedBookingListe = new List<BookingEntity>(new[]
            {
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(2,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(2,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(2,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1))
            });
            var bookingListepatrick = new List<BookingEntity>(new[]
            {
                new BookingEntity(1,new DateTime(2020, 1, 1), new DateTime(2000, 2, 1)),
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1))
            });

            var bookingListeDissing = new List<BookingEntity>(new[]
           {
                new BookingEntity(2,new DateTime(2020, 1, 1), new DateTime(2000, 2, 1)),
                new BookingEntity(2,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(2,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(2,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1))
            });


            var sqlMedarbejderListe = new List<MedarbejderEntity>(new[]
            {
                new MedarbejderEntity(1,"Patrick",bookingListepatrick),
                new MedarbejderEntity(2,"Dissing",bookingListeDissing),
            });
            var azureMedarbejderListe = new List<MedarbejderEntity>(new[]
            {

                new MedarbejderEntity(3,"Olli",bookingListepatrick),
                new MedarbejderEntity(4,"Rallan",bookingListepatrick)
            });

            var kompetenceListe = new List<KompetenceEntity>(new[]
            {
                new KompetenceEntity("Sql","Tekniker", sqlMedarbejderListe),
                new KompetenceEntity("Azure","Tekniker", azureMedarbejderListe)
            });

            //Act
            var medarbejderListe = kompetenceListe.Where(a => a.Navn == type)
                .SelectMany(b => b.MedarbejderListe).ToList();
            var actBookingListe = medarbejderListe.SelectMany(a => a.BookingListe).ToList();
            var specifikBooking = actBookingListe.Where(a => a.SlutDato > DateTime.Now).ToList();
            //Assert
            Assert.Equal(expectedBookingListe, specifikBooking);
        }
    }
}
