using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Booking.Queries;
using Unik.Applicaiton.Booking.Repositories;
using Unik.Application.Booking.Queries;
using Unik.Domain.Booking.Model;
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

        IEnumerable<BookingGetAllResulstDto> IBookingRepository.GetAll()
        {
            var p = _db.OpgaveEntities.AsNoTracking().ToList();



           var bookingliste = _db.MedarbejderEntities.Include(a => a.BookingListe).ThenInclude(a => a.OpgaveId).SelectMany(
                a => a.BookingListe, (entity, bookingEntity) => new BookingGetAllResulstDto
                {
                    MedarbejderId = entity.Id,
                    MedarbejderNavn = entity.Navn,
                    MedarbejderTitel = entity.Titel,
                    StartDato = bookingEntity.StartDato,
                    SlutDato = bookingEntity.SlutDato,
                    OpgaveId = bookingEntity.OpgaveId
                });

           return bookingliste;



           //    var b = _db.OpgaveEntities.Include(a => a.booking).ThenInclude(a => a.Medarbejder).Select(a => a.booking)
           //    .ToList();
           //var c = _db.OpgaveEntities.Include(a => a.booking).ThenInclude(a => a.Medarbejder).Select(a => a.booking)
           //    .ToList();

           //var a = _db.BookingEntities.Include(a => a.Medarbejder).Select(a => a.Medarbejder)
           //    .Include(a => a.BookingListe);









        }




        IEnumerable<FindMedarbejderDto> IBookingRepository.FindMedarbejder(string type)
        {

            foreach (var entity in _db.KompetenceEntities.Where(a => a.Navn == type).Include(a => a.MedarbejderListe)
                .SelectMany(a => a.MedarbejderListe).Include(a => a.BookingListe)
                .SelectMany(a => a.BookingListe).OrderBy(a => a.SlutDato).ToList())
                     
            yield return new FindMedarbejderDto
            {
                MedarbejderId = entity.MedarbejderId,
                startDato = entity.StartDato,
                SlutDato = entity.SlutDato
            };


            //var a = _db.KompetenceEntities.Where(a => a.Navn == type).Include(a => a.MedarbejderListe).SelectMany(a => a.MedarbejderListe).ToList();
            //var c = _db.BookingEntities.Where(e => a.Contains(e.Medarbejder))
            //    .Where(a => a.SlutDato > DateTime.Today || a.SlutDato == null).OrderBy(a => a.SlutDato).ToList();

        }
    }
}