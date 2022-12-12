namespace Unik.Applicaiton.Kunde.Query
{
    public interface IKundeGetAllQuery
    {
        IEnumerable<KundeResultDto> GetAll();
    }
}
