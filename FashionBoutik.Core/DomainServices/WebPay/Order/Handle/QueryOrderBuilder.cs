
using Webpay.Integration.CONST;
using Webpay.Integration.AdminService;

namespace Webpay.Integration.Order.Handle
{
    public class QueryOrderBuilder : Builder<QueryOrderBuilder>
    {
        internal long Id { get; private set; }
        internal PaymentType OrderType { get; private set; }

        public QueryOrderBuilder(IConfigurationProvider config) : base(config)
        {
            // intentionally left blank
        }

        public QueryOrderBuilder SetOrderId(long orderId)
        {
            Id = orderId;
            return this;
        }

        public QueryOrderBuilder SetTransactionId(long orderId)
        {
            return this.SetOrderId(orderId);
        }

        public override QueryOrderBuilder SetCountryCode(CountryCode countryCode)
        {
            _countryCode = countryCode;
            return this;
        }

        public GetOrdersRequest QueryInvoiceOrder()
        {
            OrderType = PaymentType.INVOICE;
            return new GetOrdersRequest(this);
        }

        public GetOrdersRequest QueryPaymentPlanOrder()
        {
            OrderType = PaymentType.PAYMENTPLAN;
            return new GetOrdersRequest(this);
        }

        public AdminService.QueryTransactionRequest QueryCardOrder()
        {
            return new AdminService.QueryTransactionRequest(this);
        }

        public AdminService.QueryTransactionRequest QueryDirectBankOrder()
        {
            return new AdminService.QueryTransactionRequest(this);
        }
    }
}
