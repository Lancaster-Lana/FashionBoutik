using AdminWS;
using System.Linq;
using System.Threading.Tasks;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Handle;

namespace Webpay.Integration.AdminService
{
    public class CreditInvoiceOrderRowsRequest : WebpayAdminRequest
    {
        private readonly CreditOrderRowsBuilder _builder;

        public CreditInvoiceOrderRowsRequest(CreditOrderRowsBuilder builder)
        {
            _builder = builder;
        }

        public async Task<DeliveryResponse> DoRequest()
        {
            var auth = new Authentication()
            {
                Password = _builder.GetConfig().GetPassword(_builder.OrderType,_builder.GetCountryCode()),
                Username = _builder.GetConfig().GetUsername(_builder.OrderType,_builder.GetCountryCode())                
            };

            var request = new CreditInvoiceRequest
            {
                Authentication = auth,
                InvoiceId = _builder.Id,
                ClientId = _builder.GetConfig().GetClientNumber(_builder.OrderType, _builder.GetCountryCode()),
                RowNumbers = _builder.RowIndexesToCredit.ToArray(),
                InvoiceDistributionType = ConvertDistributionTypeToInvoiceDistributionType(_builder.DistributionType),
                NewCreditInvoiceRows = _builder.NewCreditOrderRows.Select( x => ConvertOrderRowBuilderToAdminWSOrderRow(x) ).ToArray()
            };

            // make request to correct endpoint, return response object
            var endpoint = _builder.GetConfig().GetEndPoint(PaymentType.ADMIN_TYPE);
            var adminWS = new AdminServiceClient(AdminServiceClient.EndpointConfiguration.WcfAdminSoapService);// "WcfAdminSoapService", endpoint);
            var response = await adminWS.CreditInvoiceRowsAsync(request);

            return response;
        }
    }
}