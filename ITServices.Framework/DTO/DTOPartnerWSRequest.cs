namespace ITServices.Framework.DTO
{
    public class DTOPartnerWSRequest
    {
        public string ClientIPAddress { get; set; }

        public string SystemName { get; set; }

        public string WebServiceName { get; set; }

        public string WebMethodName { get; set; }

        public DTOPartnerCredential PartnerCredential { get; set; }
    }
}