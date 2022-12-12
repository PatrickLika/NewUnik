namespace Unik.Applicaiton.Opgave.Command
{
    public interface ICreateOpgaveCommand
    {
        void Create(OpgaveCreateRequestDto dto);
    }
}
