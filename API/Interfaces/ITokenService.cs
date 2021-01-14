using API.Entities;

namespace API.Interfaces
{
    public interface ITokenService
    {
        //Method Signature
        string CreateToken(AppUser user);
    }
}