using ITServices.Framework.DTO;

namespace ITServices.Framework.Business
{
    public interface IAuthorizeManager
    {
        bool Authorize(DTOPartnerWSRequest dtoPartnerWsRequest);
    }
}