using System.Linq;
using ITServices.Framework.Data;
using ITServices.Framework.DTO;

namespace ITServices.Framework.Business
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private IUnitOfWork _unitOfWork;

        public AuthenticationManager()
        {
            _unitOfWork = new UnitOfWork();
        }

        public AuthenticationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Authenticate(DTOPartnerCredential dtoPartnerCredential)
        {
            return _unitOfWork.PartnerRepository.Get(q => q.PartnerID == dtoPartnerCredential.PartnerID && q.PartnerPassword == dtoPartnerCredential.PartnerPwd)
                      .Any();
        }
    }
}