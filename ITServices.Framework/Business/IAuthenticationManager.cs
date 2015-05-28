using ITServices.Framework.DTO;

namespace ITServices.Framework.Business
{
    public interface IAuthenticationManager
    {
        bool Authenticate(DTOPartnerCredential dtoPartnerCredential);
    }
}