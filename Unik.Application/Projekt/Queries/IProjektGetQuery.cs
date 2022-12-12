namespace Unik.Applicaiton.Projekt.Queries;

public interface IProjektGetQuery
{
    ProjektQueryResultDto Get(int projektId);
}