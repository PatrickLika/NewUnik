namespace Unik.Applicaiton.Projekt.Queries;

public interface IProjektGetAllQuery
{
    IEnumerable<ProjektQueryResultDto> GetAll();
}