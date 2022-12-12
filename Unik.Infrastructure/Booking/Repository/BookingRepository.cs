using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Unik.Applicaiton.Booking.Queries;
using Unik.Applicaiton.Booking.Repositories;
using Unik.Domain.Booking.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Booking.Repository;

public class BoookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly UnikContext _db;

        public BookingRepository(UnikContext db)
        {
            _db = db;
        }
        void IBookingRepository.Create(BookingEntity booking)
        {
            _db.BookingEntities.Add(booking);
            _db.SaveChanges();
        }
        void IBookingRepository.Update(BookingEntity model)
        {
            _db.BookingEntities.Update(model);
        }

        void IBookingRepository.Delete(int id)
        {
            var model = _db.BookingEntities.SingleOrDefault(a => a.Id == id);

            _db.BookingEntities.Remove(model);

            if (model == null) throw new Exception("Bookingen findes ikke i databasen");

            _db.SaveChanges();
        }
        BookingEntity IBookingRepository.Load(int bookingId)
        {
            var model = _db.BookingEntities.SingleOrDefault(a => a.Id == bookingId);
            if (model == null) throw new Exception("Bookingen findes ikke i databasen");
            return model;
        }

        BookingResultDto IBookingRepository.Get(int bookingId)
        {
            var dbEntity = _db.BookingEntities.AsNoTracking().FirstOrDefault(a => a.Id == bookingId);
            if (dbEntity == null) throw new Exception("Booking findes ikke i databasen");

            return new BookingResultDto
            {
                Id = dbEntity.Id,
                MedarbejderId = dbEntity.MedarbejderId,
                OpgaveId = dbEntity.OpgaveId,
                SlutDato = dbEntity.SlutDato,
                StartDato = dbEntity.StartDato
            };
        }

        IEnumerable<BookingResultDto> IBookingRepository.GetAll()
        {
            foreach (var dbEntity in _db.BookingEntities.AsNoTracking().ToList())

                yield return new BookingResultDto
                {
                       Id = dbEntity.Id,
                       MedarbejderId = dbEntity.MedarbejderId,
                       OpgaveId = dbEntity.OpgaveId,
                       SlutDato = dbEntity.SlutDato,
                       StartDato = dbEntity.StartDato
                };
        }

        
        IEnumerable<FindMedarbejderDto> IBookingRepository.FindMedarbejder(string type)
        {
           //var test = _db.KompetenceEntities.Where(a => a.Navn == type).SelectMany(a => a.MedarbejderListe)
           //    .SelectMany(a => a.BookingListe).OrderBy(a => a.SlutDato < DateTime.Now || a.SlutDato == null).Select(a => a.MedarbejderId)
           //     .ToList();


           var medarbejdereMedkompetencer =
               _db.KompetenceEntities.Where(a => a.Navn == type).SelectMany(a => a.MedarbejderListe);



           //var c = b.Select(a => a.MedarbejderId).ToList();





           foreach (var item in medarbejdereMedkompetencer)

               yield return new FindMedarbejderDto
               {
                   //Id = item
               };
           
            
        }
    }
}