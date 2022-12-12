namespace CryptocurrencyBank.Application.Abstractions.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken token);
    }
}
