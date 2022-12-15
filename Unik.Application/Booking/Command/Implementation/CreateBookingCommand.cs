using Unik.Applicaiton.Booking.Repositories;
using Unik.Crosscut.TransactionHandling;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Booking.Model;

namespace Unik.Applicaiton.Booking.Command.Implementation
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IBookingRepository _repository;
        private readonly IBookingDomainService _domainService;
        private readonly IUnitOfWork _unitOfWork;


        public CreateBookingCommand(IBookingRepository repository, IBookingDomainService domainService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _domainService = domainService;
            _unitOfWork = unitOfWork;
        }


        void ICreateBookingCommand.Create(BookingCreateRequestDto requestDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var model = new BookingEntity(_domainService, requestDto.OpgaveId, requestDto.MedarbejderId, requestDto.StartDato, requestDto.SlutDato);
                _repository.Create(model);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
