namespace Unik.Applicaiton.Medarbejder.Commands
{
    public interface ICreateMedarbejderCommand
    {
        void Create(MedarbejderCreateRequestDto requestDto);
    }
}
