using System.ComponentModel.DataAnnotations;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Medarbejder.Model;

namespace Unik.Domain.Booking.Model;

public class BookingEntity
{
    public BookingEntity()
    {

    }
    private readonly IBookingDomainService _domainService;
    public int Id { get; set; }
    public int OpgaveId { get; set; }
    public int MedarbejderId { get; set; }
    public DateTime StartDato { get; set; }
    public DateTime SlutDato { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; private set; }
    public MedarbejderEntity Medarbejder { get; set; }


    public BookingEntity(IBookingDomainService domainService, int opgaveId, int medarbejderId, DateTime startDato, DateTime slutDato)
    {
        _domainService = domainService;
        OpgaveId = opgaveId;
        MedarbejderId = medarbejderId;
        StartDato = startDato;
        SlutDato = slutDato;

        if (IsDoubleBooking()) throw new ArgumentException("Fejl dobbelt booking!");
    }
    //Kun til Test!!
    public BookingEntity(int medarbejderId, DateTime startDato, DateTime slutDato)
    {
        MedarbejderId = medarbejderId;
        StartDato = startDato;
        SlutDato = slutDato;
    }
    public void Edit(int opgaveId, int medarbejderNr, DateTime startDato, DateTime slutDato, byte[] rowVersion)
    {
        RowVersion = rowVersion;
        OpgaveId = opgaveId;
        MedarbejderId = medarbejderNr;
        StartDato = startDato;
        SlutDato = slutDato;
    }

    private bool IsDoubleBooking()
    {
        return _domainService.GetBookings(MedarbejderId).Any(a => a.StartDato < SlutDato && a.SlutDato > StartDato);

    }
}

