using Unik.Applicaiton.Booking.Repositories;

namespace Unik.Applicaiton.Booking.Command.Implementation;

public class DeleteBookingCommand : IDeleteBookingCommand
{
    private readonly IBookingRepository _db;

    public DeleteBookingCommand(IBookingRepository db)
    {
        _db = db;
    }
    void IDeleteBookingCommand.Delete(int id)
    {
        _db.Delete(id);
    }
}