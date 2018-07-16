using AdminWS;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Handle;

namespace Webpay.Integration.AdminService
{
    public class DeliverOrdersRequest : WebpayAdminRequest
    {
        private DeliverOrdersBuilder _builder;

        public DeliverOrdersRequest(DeliverOrdersBuilder builder)
        {
            _builder = builder;
        }

        public async Task<DeliveryResponse> DoRequest()
        {
            var auth = new AdminWS.Authentication()
            {
                Password = _builder.GetConfig().GetPassword(_builder.OrderType, _builder.GetCountryCode()),
                Username = _builder.GetConfig().GetUsername(_builder.OrderType, _builder.GetCountryCode())
            };

            var ordersToDeliver = new List<AdminWS.DeliverOrderInformation>();
            var clientId = _builder.GetConfig().GetClientNumber(_builder.OrderType, _builder.GetCountryCode());
            var orderType = ConvertPaymentTypeToOrderType(_builder.OrderType);
            foreach (var orderId in _builder.OrderIds)
            {
                var orderToDeliver = new AdminWS.DeliverOrderInformation()
                {
                    ClientId = clientId,
                    SveaOrderId = orderId,
                    OrderType = orderType
                    //PrintType // optional for EU-clients
                };
                ordersToDeliver.Add(orderToDeliver);
            }

            var request = new AdminWS.DeliveryRequest()
            {
                Authentication = auth,
                OrdersToDeliver = ordersToDeliver.ToArray(),
                InvoiceDistributionType = ConvertDistributionTypeToInvoiceDistributionType(_builder.DistributionType)
            };

            // make request to correct endpoint, return response object
            var endpoint = _builder.GetConfig().GetEndPoint(PaymentType.ADMIN_TYPE);
            var adminWS = new AdminServiceClient(AdminServiceClient.EndpointConfiguration.WcfAdminSoapService , endpoint);
            var response = await adminWS.DeliverOrdersAsync(request);

            return response;
        }
    }
}