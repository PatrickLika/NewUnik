﻿using Unik.Applicaiton.Booking.Queries;
using Unik.Application.Booking.Queries;
using Unik.Domain.Booking.Model;

namespace Unik.Applicaiton.Booking.Repositories
{
    public interface IBookingRepository
    {
        void Create(BookingEntity booking);
        void Update(BookingEntity model);
        void Delete(int id);
        BookingEntity Load(int bookingId);
        BookingResultDto Get(int bookingId);
        IEnumerable<BookingGetAllResulstDto> GetAll();
        List<FindMedarbejderDto> FindMedarbejder(string type);
    }
}