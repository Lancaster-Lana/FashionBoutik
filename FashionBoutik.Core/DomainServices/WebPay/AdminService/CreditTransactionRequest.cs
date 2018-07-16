using System;
using Webpay.Integration.Hosted.Admin;
using Webpay.Integration.Hosted.Admin.Actions;
using Webpay.Integration.Hosted.Admin.Response;
using Webpay.Integration.Order.Handle;

namespace Webpay.Integration.AdminService
{
    public class CreditTransactionRequest
    {
        private readonly CreditAmountBuilder _builder;

        public CreditTransactionRequest(CreditAmountBuilder builder) {
            _builder = builder;
        }

        public CreditResponse DoRequest()
        {
            // should validate _builder.GetOrderId() existence here

            var hostedActionRequest = new HostedAdmin(_builder.GetConfig(), _builder.GetCountryCode())
                .Credit(new Credit(
                    transactionId: _builder.Id,
                    amountToCredit: Decimal.ToInt64(_builder.AmountIncVat * 100)    //centessimal
                    ));

            return hostedActionRequest.DoRequest<CreditResponse>();
        }
    }
}