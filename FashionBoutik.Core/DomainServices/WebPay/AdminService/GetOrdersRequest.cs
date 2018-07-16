﻿using AdminWS;
using System.Threading.Tasks;
using Webpay.Integration.Order.Handle;

namespace Webpay.Integration.AdminService
{
    public class GetOrdersRequest : WebpayAdminRequest
    {
        private readonly QueryOrderBuilder _builder;

        public GetOrdersRequest(QueryOrderBuilder builder)
        {
            _builder = builder;
        }

        public async Task<GetOrdersResponse> DoRequest()
        {
            var auth = new AdminWS.Authentication()
            {
                Password = _builder.GetConfig().GetPassword(_builder.OrderType,_builder.GetCountryCode()),
                Username = _builder.GetConfig().GetUsername(_builder.OrderType,_builder.GetCountryCode())                
            };

            var request = new AdminWS.GetOrdersRequest()
            {
                Authentication = auth,
                OrdersToRetrieve = new[]
                {
                    new GetOrderInformation()
                    {
                        SveaOrderId = _builder.Id,
                        OrderType = ConvertPaymentTypeToOrderType(_builder.OrderType),
                        ClientId = _builder.GetConfig().GetClientNumber(_builder.OrderType, _builder.GetCountryCode())
                    }
                }
            };

            // make request to correct endpoint, return response object
            var endpoint = _builder.GetConfig().GetEndPoint(CONST.PaymentType.ADMIN_TYPE);
            var adminWS = new AdminServiceClient(AdminServiceClient.EndpointConfiguration.WcfAdminSoapService, endpoint);
            var response = await adminWS.GetOrdersAsync(request);

            return response;
        }
    }
}