namespace CryptocurrencyBank.Application.Abstractions.Request
{
    internal interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken token);
    }
}
