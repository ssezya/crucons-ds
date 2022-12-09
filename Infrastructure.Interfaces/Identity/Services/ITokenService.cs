namespace Infrastructure.Interfaces.Identity.Services
{
    public interface ITokenService<TUser, TResponse> where TUser : class
    {
        TResponse CreateToken(TUser user);
    }
}
