namespace Unik.Applicaiton.Sales.Commands
{
    public interface ICreateSalesCommand
    {
        void Create(SalesCreateRequestDto requestDto);
    }
}
