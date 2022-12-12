namespace Unik.Applicaiton.Kompetence.Commands
{
    public interface ICreateKompetenceCommand
    {
        void Create(KompetenceCreateRequestDto requestDto);
    }
}
