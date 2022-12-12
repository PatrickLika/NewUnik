using Unik.Applicaiton.Opgave.Queries;
using Unik.Domain.Opgave.Model;

namespace Unik.Applicaiton.Opgave.Repositories
{
    public interface IOpgaveRepository
    {
        void Create(OpgaveEntity model);
        IEnumerable<OpgaveQueryResultDto> GetAll();
        void Update(OpgaveEntity model);
        void Delete(int id);
        OpgaveEntity Load(int KompetenceId);
        OpgaveQueryResultDto Get(int id);


    }
}
