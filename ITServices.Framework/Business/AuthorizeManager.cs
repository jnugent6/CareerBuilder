using System.Linq;
using System.Text.RegularExpressions;
using ITServices.Framework.Data;
using ITServices.Framework.Data.Models;
using ITServices.Framework.DTO;

namespace ITServices.Framework.Business
{
    public class AuthorizeManager : IAuthorizeManager
    {
        private IUnitOfWork _unitOfWork;

        public AuthorizeManager()
        {
            _unitOfWork = new UnitOfWork();
        }

        public AuthorizeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Authorize(DTOPartnerWSRequest dtoPartnerWsRequest)
        {
            bool isValid = false;

            using (_unitOfWork)
            {
                //Validate PartnerIPAddress
                if (ValidatePartnerIPAddress(dtoPartnerWsRequest.PartnerCredential.PartnerID, dtoPartnerWsRequest.ClientIPAddress))
                {
                    //Validate WebService
                    var webService = ValidateWebService(dtoPartnerWsRequest);

                    isValid = webService != null && ValidatePartnerPermission(dtoPartnerWsRequest, webService);
                }
            }

            return isValid;
        }

        private bool ValidatePartnerIPAddress(string partnerId, string clientIpAddress)
        {
            bool isValid = false;
            var partner = Partner(partnerId);

            if (partner != null && clientIpAddress != null)
            {
                bool ipFound = partner.PartnerIPAddresses.Any(q => IsIPAddressMatch(clientIpAddress, q.IPAddress));
                isValid = partner.EnforceIPRestriction && ipFound;
            }
            return isValid;
        }

        private Partner Partner(string partnerId)
        {
            var partner = new Partner();
            partner =
                _unitOfWork.PartnerRepository.Get(q => q.PartnerID == partnerId)
                    .FirstOrDefault();
            return partner;
        }

        private bool ValidatePartnerPermission(DTOPartnerWSRequest dtoPartnerWsRequest, WebService webService)
        {
            var partner = Partner(dtoPartnerWsRequest.PartnerCredential.PartnerID);

            var webMethod = new WebMethod();
            webMethod =
                _unitOfWork.WebMethodRepository.Get(
                    q =>
                        q.WebServiceDID == webService.DID &&
                        q.WebMethodName == dtoPartnerWsRequest.WebMethodName).FirstOrDefault();

            return partner.PartnerPermissions.Any(q => webMethod != null && q.WebMethodDID.Contains(webMethod.DID));
        }

        private WebService ValidateWebService(DTOPartnerWSRequest dtoPartnerWsRequest)
        {
            var webService = new WebService();
            webService =
                _unitOfWork.WebServiceRepository.Get(
                    q =>
                        q.SystemName == dtoPartnerWsRequest.SystemName && q.WebServiceName ==
                        dtoPartnerWsRequest.WebServiceName).FirstOrDefault();
            return webService;
        }

        private bool IsIPAddressMatch(string IPAddress, string CompareToIPAddress)
        {
            string IPRegex = null;
            IPRegex = ConvertIPToRegex(CompareToIPAddress);
            return Regex.IsMatch(IPAddress, IPRegex);
        }

        private string ConvertIPToRegex(string IPAddress)
        {
            string IPRegex = IPAddress;
            IPRegex = IPRegex.Replace(".", "\\.");
            IPRegex = IPRegex.Replace("*", "\\d{1,3}");
            IPRegex = "^" + IPRegex + "$";
            return IPRegex;
        }
    }
}