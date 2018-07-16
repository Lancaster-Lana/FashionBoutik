﻿using Webpay.Integration.CONST;

namespace Webpay.Integration.Order.Handle
{
    public class UpdateOrderBuilder : Builder<UpdateOrderBuilder>
    {
        internal long SveaOrderId { get; private set; }
        internal PaymentType OrderType { get; private set; }
        internal string ClientOrderNumber { get; private set; }
        internal string Notes { get; private set; }

        public UpdateOrderBuilder(IConfigurationProvider config) : base(config)
        {}

        public UpdateOrderBuilder SetOrderId(long orderId)
        {
            SveaOrderId = orderId;
            return this;
        }

        public override UpdateOrderBuilder SetCountryCode(CountryCode countryCode)
        {
            _countryCode = countryCode;
            return this;
        }

        public UpdateOrderBuilder SetClientOrderNumber(string clientOrderNumber)
        {
            ClientOrderNumber = clientOrderNumber;
            return this;
        }

        public UpdateOrderBuilder SetNotes(string notes)
        {
            Notes = notes;
            return this;
        }

        public AdminService.UpdateOrderRequest UpdateInvoiceOrder()
        {
            OrderType = PaymentType.INVOICE;
            return new AdminService.UpdateOrderRequest(this);
        }

        public AdminService.UpdateOrderRequest UpdatePaymentPlanOrder()
        {
            OrderType = PaymentType.PAYMENTPLAN;
            return new AdminService.UpdateOrderRequest(this);
        }
    }
}
