namespace Unik.Application.Kunde.Query
{
    public interface IKundeGetByUser
    {
        KundeUserResultDto GetUser(string userId);
    }
}
