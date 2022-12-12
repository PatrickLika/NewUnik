namespace Unik.Applicaiton.Medarbejder.Query
{
    public interface IMedarbejderGetAllQuery
    {
        IEnumerable<MedarbejderGetAllQueryDto> GetAll();
    }
}
