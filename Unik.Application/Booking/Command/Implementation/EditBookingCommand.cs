using Unik.Applicaiton.Booking.Repositories;

namespace Unik.Applicaiton.Booking.Command.Implementation;

public class EditBookingCommand : IEditBookingCommand
{
    private readonly IBookingRepository _db;

    public EditBookingCommand(IBookingRepository db)
    {
        _db = db;
    }
    void IEditBookingCommand.Edit(BookingEditRequestDto dto)
    {
        var model = _db.Load(dto.Id);

        model.Edit(dto.OpgaveId, dto.MedarbejderId,dto.StartDato,dto.SlutDato,dto.RowVersion);

        _db.Update(model);
    }
}
