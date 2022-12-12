namespace Infrastructure.Interfaces.Identity.Services
{
    public interface ITokenService<TRequest, TResponse> where TRequest : class
    {
        TResponse CreateToken(TRequest request);
    }
}
