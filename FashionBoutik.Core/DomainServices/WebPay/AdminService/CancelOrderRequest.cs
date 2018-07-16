using AdminWS;
using System.Threading.Tasks;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Handle;

namespace Webpay.Integration.AdminService
{
    public class CancelOrderRequest : WebpayAdminRequest
    {
        private readonly CancelOrderBuilder _builder;

        public CancelOrderRequest(CancelOrderBuilder builder)
        {
            _builder = builder;
        }

        public async  Task<CancelOrderResponse> DoRequest()
        {
            var auth = new AdminWS.Authentication()
            {
                Password = _builder.GetConfig().GetPassword(_builder.OrderType, _builder.GetCountryCode()),
                Username = _builder.GetConfig().GetUsername(_builder.OrderType, _builder.GetCountryCode())
            };

            var request = new AdminWS.CancelOrderRequest()
            {
                Authentication = auth,
                SveaOrderId = _builder.Id,
                OrderType = ConvertPaymentTypeToOrderType(_builder.OrderType),
                ClientId = _builder.GetConfig().GetClientNumber(_builder.OrderType, _builder.GetCountryCode())               
            };

            // make request to correct endpoint, return response object
            var endpoint = _builder.GetConfig().GetEndPoint(PaymentType.ADMIN_TYPE);
            var adminWS = new AdminServiceClient(AdminServiceClient.EndpointConfiguration.WcfAdminSoapService, endpoint);
            var response = await adminWS.CancelOrderAsync(request);

            return response;
        }

    }
}