namespace Unik.Applicaiton.Kunde.Commands
{
    public interface ICreateKundeCommand
    {
        void Create(KundeCreateRequestDto requestDto);
    }
}
