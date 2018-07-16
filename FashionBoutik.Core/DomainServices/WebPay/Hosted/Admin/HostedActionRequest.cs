using Webpay.Integration.CONST;
using Webpay.Integration.Exception;
using Webpay.Integration.Hosted.Admin.Actions;
using Webpay.Integration.Hosted.Admin.Response;

namespace Webpay.Integration.Hosted.Admin
{
    public class HostedActionRequest
    {
        public readonly IConfigurationProvider ConfigurationProvider;
        public readonly CountryCode CountryCode;
        public readonly string MerchantId;
        public readonly string ServicePath;
        public readonly string Xml;

        public HostedActionRequest(string xml, CountryCode countryCode, string merchantId,
            IConfigurationProvider configurationProvider, string servicePath)
        {
            Xml = xml;
            CountryCode = countryCode;
            MerchantId = merchantId;
            ConfigurationProvider = configurationProvider;
            ServicePath = servicePath;
        }

        public T DoRequest<T>()
        {
            //Annul
            if (typeof(T) == typeof(AnnulResponse))
            {
                var hostedAdminResponse = HostedAdminRequest.HostedAdminCall(GetEndPointBase(), PrepareRequest());
                return (T)(object)hostedAdminResponse.To(Annul.Response);
            }
            //CancelRecurSubscription
            //Confirm
            if (typeof(T) == typeof(ConfirmResponse))
            {
                var hostedAdminResponse = HostedAdminRequest.HostedAdminCall(GetEndPointBase(), PrepareRequest());
                return (T)(object)hostedAdminResponse.To(Confirm.Response);
            }
            //Credit
            if (typeof(T) == typeof(CreditResponse))
            {
                var hostedAdminResponse = HostedAdminRequest.HostedAdminCall(GetEndPointBase(), PrepareRequest());
                return (T)(object)hostedAdminResponse.To(Credit.Response);
            }
            //GetPaymentMethods
            //GetReconciliationReport
            //LowerAmount
            if (typeof(T) == typeof(LowerAmountResponse))
            {
                var hostedAdminResponse = HostedAdminRequest.HostedAdminCall(GetEndPointBase(), PrepareRequest());
                return (T)(object)hostedAdminResponse.To(LowerAmount.Response);
            }
            //Query
            if ( typeof(T) == typeof(QueryResponse) )
            {
                var hostedAdminResponse = HostedAdminRequest.HostedAdminCall(GetEndPointBase(), PrepareRequest());
                return (T) (object) hostedAdminResponse.To(Query.Response);
            }
            //Recur
            if (typeof(T) == typeof(RecurResponse))
            {
                var hostedAdminResponse = HostedAdminRequest.HostedAdminCall(GetEndPointBase(), PrepareRequest());
                return (T)(object)hostedAdminResponse.To(Recur.Response);
            }
            //Raw HostedAdminResponse
            if (typeof(T) == typeof(HostedAdminResponse))
            {
                var hostedAdminResponse = HostedAdminRequest.HostedAdminCall(GetEndPointBase(), PrepareRequest());
                return (T)(object)hostedAdminResponse;
            }
            //default catch-all
            throw new SveaWebPayException("unknown request type");
        }

        private string GetEndPointBase()
        {
            var endPoint = ConfigurationProvider.GetEndPoint(PaymentType.HOSTED);
            var baseUrl = endPoint.Replace("/payment", "");

            var targetAddress = baseUrl + "/rest" + ServicePath;
            return targetAddress;
        }

        public HostedAdminRequest PrepareRequest()
        {
            return new HostedAdminRequest(Xml, ConfigurationProvider.GetSecretWord(PaymentType.HOSTED, CountryCode),
                MerchantId, GetEndPointBase());
        }
    }
}