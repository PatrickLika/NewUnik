namespace Unik.Applicaiton.Opgave.Queries
{
    public interface IOpgaveGetAllQuery
    {
       IEnumerable<OpgaveQueryResultDto> GetAll();
    }
}
