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

        public void IsGiveTypeThenReturnSQLBooking(string type)
        {
            //Arrange
            var bookingListe = new List<BookingEntity>(new[]
           {
                new BookingEntity(1,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(2,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(3,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1)),
                new BookingEntity(4,new DateTime(2023, 1, 1), new DateTime(2023, 2, 1))
            });


            var sqlMedarbejderListe = new List<MedarbejderEntity>(new[]
            {
                new MedarbejderEntity(1,"Patrick",bookingListe),
                new MedarbejderEntity(2,"Dissing",bookingListe),
            });
            var azureMedarbejderListe = new List<MedarbejderEntity>(new[]
            {

                new MedarbejderEntity(3,"Olli",bookingListe),
                new MedarbejderEntity(4,"Rallan",bookingListe)
            });

            var kompetenceListe = new List<KompetenceEntity>(new[]
            {
                new KompetenceEntity("Sql","Tekniker", sqlMedarbejderListe),
                new KompetenceEntity("Azure","Tekniker", azureMedarbejderListe)
            });
            BookingRepositoryMock.Setup(a => a.FindMedarbejder("Sql")).Returns(bookingListe);

            //Act
            var typeList = kompetenceListe.Where(a => a.Navn == type).SelectMany(b => b.MedarbejderListe);
            //Assert
        }
    }
}
