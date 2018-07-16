using System.Linq;
using System.Threading.Tasks;
using AdminWS;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Handle;

namespace Webpay.Integration.AdminService
{
    public class UpdateOrderRowsRequest : WebpayAdminRequest
    {
        private readonly UpdateOrderRowsBuilder _builder;

        public UpdateOrderRowsRequest(UpdateOrderRowsBuilder builder)
        {
            _builder = builder;
        }

        public async Task<AdminWS.UpdateOrderRowsResponse> DoRequest()
        {
            var auth = new AdminWS.Authentication()
            {
                Password = _builder.GetConfig().GetPassword(_builder.OrderType,_builder.GetCountryCode()),
                Username = _builder.GetConfig().GetUsername(_builder.OrderType,_builder.GetCountryCode())                
            };

            var request = new AdminWS.UpdateOrderRowsRequest()
            {
                Authentication = auth,
                SveaOrderId = _builder.Id,
                OrderType = ConvertPaymentTypeToOrderType(_builder.OrderType),
                ClientId = _builder.GetConfig().GetClientNumber(_builder.OrderType, _builder.GetCountryCode()),
                UpdatedOrderRows = _builder.NumberedOrderRows.Select(ConvertNumberedOrderRowBuilderToAdminWSNumberedOrderRow).ToArray()
            };

            // make request to correct endpoint, return response object
            var endpoint = _builder.GetConfig().GetEndPoint(PaymentType.ADMIN_TYPE);
            var adminWS = new AdminServiceClient(AdminServiceClient.EndpointConfiguration.WcfAdminSoapService, endpoint);
            var response = await adminWS.UpdateOrderRowsAsync(request);

            return response;
        }
    }
}