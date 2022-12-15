﻿using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Medarbejder.Commands;
using Unik.Applicaiton.Medarbejder.Query;
using Unik.Applicaiton.Medarbejder.Repositories;
using Unik.Crosscut.Dto;
using Unik.Domain.Medarbejder.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Medarbejder.Repositories
{
    public class MedarbejderRepository : IMedarbejderRepository
    {
        private readonly UnikContext _db;

        public MedarbejderRepository(UnikContext db)
        {
            _db = db;
        }

        void IMedarbejderRepository.Create(MedarbejderEntity medarbejder)
        {
            _db.Add(medarbejder);
            _db.SaveChanges();
        }

        IEnumerable<MedarbejderGetAllQueryDto> IMedarbejderRepository.GetAll()
        {
            foreach (var entity in _db.MedarbejderEntities.AsNoTracking().ToList())
            {
                yield return new MedarbejderGetAllQueryDto
                {
                    Id = entity.Id,
                    Titel = entity.Titel,
                    Navn = entity.Navn,
                    Email = entity.Email,
                    Tlf = entity.Tlf,
                    RowVersion = entity.RowVersion,
                    UserId = entity.UserId,
                    KompetenceListe = entity.KompetenceListe
                };
            }

        }

        void IMedarbejderRepository.Delete(int id)
        {

            var model = _db.MedarbejderEntities.SingleOrDefault(a => a.Id == id);
            if (model == null) throw new Exception("Medarbejder findes ikke i databasen");

            _db.MedarbejderEntities.Remove(model);
            _db.SaveChanges();

            //_db.Remove(id);
            //_db.SaveChanges();
        }



        MedarbejderEntity IMedarbejderRepository.Load(int id)
        {
            var dbEntity = _db.MedarbejderEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (dbEntity == null) throw new Exception($"Medarbejder med Id:{id} findes ikke");
            return dbEntity;

        }



        void IMedarbejderRepository.Update(MedarbejderEntity model)
        {
            _db.Update(model);
            _db.SaveChanges();
        }

        MedarbejderGetQueryDto IMedarbejderRepository.Get(int id)
        {

            var medarbejder = _db.MedarbejderEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (medarbejder == null) throw new Exception("Medarbejder findes ikke i databasen");

            return new MedarbejderGetQueryDto
            {
                Id = medarbejder.Id,
                Navn = medarbejder.Navn,
                Email = medarbejder.Email,
                Tlf = medarbejder.Tlf,
                Titel = medarbejder.Titel,
                RowVersion = medarbejder.RowVersion,
                UserId = medarbejder.UserId,
            };

        }

        void IMedarbejderRepository.CreateMedarbejderKompetence(MedarbejderKompetenceCreateDto dto)
        {
            var medarbejder = _db.MedarbejderEntities.Include(a => a.KompetenceListe).FirstOrDefault(a => a.UserId == dto.UserId);
            var kompetence = _db.KompetenceEntities.Single(a => a.Id == dto.KompetenceId);

            medarbejder.KompetenceListe.Add(kompetence);

            _db.SaveChanges();
        }

        MedarbejderGetByUserIdDto IMedarbejderRepository.GetByUserId(string userId)
        {
            var medarbejder = _db.MedarbejderEntities.AsNoTracking().FirstOrDefault(a => a.UserId == userId);
            if (medarbejder == null) throw new Exception("Medarbejder findes ikke i databasen");

            var kompetencer = _db.MedarbejderEntities.SelectMany(a => a.KompetenceListe, ((Medarbejder, kompetenceEntity) =>
                new medarbejderkompetenceEntityDto
                {
                    KompetenceId = kompetenceEntity.Id,
                    MedarbejderId = Medarbejder.Id,
                    KompetenceNavn = kompetenceEntity.Navn
                })).ToList();

            var booking = _db.OpgaveEntities.
            Include(b => b.booking)
            .Where(a => a.booking.MedarbejderId == medarbejder.Id).
            ToList();

            //var query = db.Students
            //    .SelectMany(student => student.Enrollments, (student, enrollment) => new { Student = student.Name, Course = enrollment.Course.Name });


            return new MedarbejderGetByUserIdDto
            {
                Id = medarbejder.Id,
                Navn = medarbejder.Navn,
                Email = medarbejder.Email,
                Tlf = medarbejder.Tlf,
                Titel = medarbejder.Titel,
                RowVersion = medarbejder.RowVersion,
                UserId = medarbejder.UserId,
                KompetenceListe = kompetencer,
                OpgaverListe = booking
            };
        }
    }
}