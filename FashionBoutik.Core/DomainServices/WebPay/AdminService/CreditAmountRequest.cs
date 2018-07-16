using AdminWS;
using System.Threading.Tasks;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Handle;

namespace Webpay.Integration.AdminService
{
    public class CreditAmountRequest
    {
        private readonly CreditAmountBuilder _builder;

        public CreditAmountRequest(CreditAmountBuilder builder)
        {
            _builder = builder;
        }

        public async Task<CancelPaymentPlanAmountResponse> DoRequest()
        {
            var auth = new Authentication()
            {
                Password = _builder.GetConfig().GetPassword(_builder.OrderType, _builder.GetCountryCode()),
                Username = _builder.GetConfig().GetUsername(_builder.OrderType, _builder.GetCountryCode())
            };

            var request = new CancelPaymentPlanAmountRequest()
            {
                Authentication = auth,
                AmountInclVat = _builder.AmountIncVat,
                ContractNumber = _builder.Id,
                ClientId = _builder.GetConfig().GetClientNumber(_builder.OrderType, _builder.GetCountryCode()),
                Description = _builder.Description
            };

            // make request to correct endpoint, return response object
            var endpoint = _builder.GetConfig().GetEndPoint(PaymentType.ADMIN_TYPE);
            var adminWS = new AdminServiceClient(AdminServiceClient.EndpointConfiguration.AdminSoapService);// "WcfAdminSoapService", endpoint);
            var response = await adminWS.CancelPaymentPlanAmountAsync(request);

            return response;
        }
    }
}