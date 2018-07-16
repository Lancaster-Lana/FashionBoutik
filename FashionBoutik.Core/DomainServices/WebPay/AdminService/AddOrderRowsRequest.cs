using AdminWS;
using System.Linq;
using System.Threading.Tasks;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Handle;
using static AdminWS.AdminServiceClient;

namespace Webpay.Integration.AdminService
{
    public class AddOrderRowsRequest : WebpayAdminRequest
    {
        private readonly AddOrderRowsBuilder _builder;

        public AddOrderRowsRequest(AddOrderRowsBuilder builder)
        {
            _builder = builder;
        }

        public async Task<AddOrderRowsResponse> DoRequest()
        {
            var auth = new AdminWS.Authentication()
            {
                Password = _builder.GetConfig().GetPassword(_builder.OrderType, _builder.GetCountryCode()),
                Username = _builder.GetConfig().GetUsername(_builder.OrderType, _builder.GetCountryCode())
            };

            var request = new AdminWS.AddOrderRowsRequest()
            {
                Authentication = auth,
                SveaOrderId = _builder.Id,
                OrderType = ConvertPaymentTypeToOrderType(_builder.OrderType),    // not required for EU-clients
                ClientId = _builder.GetConfig().GetClientNumber(_builder.OrderType, _builder.GetCountryCode()),
                OrderRows = _builder.OrderRows.Select(x => ConvertOrderRowBuilderToAdminWSOrderRow(x)).ToArray()
            };

            // make request to correct endpoint, return response object
            var endpoint = _builder.GetConfig().GetEndPoint(PaymentType.ADMIN_TYPE);
            var adminWS = new AdminServiceClient(EndpointConfiguration.WcfAdminSoapService);//"WcfAdminSoapService", endpoint);
            var response = await adminWS.AddOrderRowsAsync(request);

            return response;
        }
    }
}