﻿using Webpay.Integration.CONST;
using Webpay.Integration.Order.Create;
using WebpayWS;

namespace Webpay.Integration.Webservice.Payment
{
    public class InvoicePayment : WebServicePayment
    {
        public InvoicePayment(CreateOrderBuilder orderBuilder) : base(orderBuilder)
        {
            PayType = PaymentType.INVOICE;
        }

        protected override CreateOrderInformation SetOrderType(CreateOrderInformation information)
        {
            if (CrOrderBuilder.GetIsCompanyIdentity() &&
                CrOrderBuilder.GetCompanyCustomer().GetAddressSelector() != null)
            {
                OrderInfo.AddressSelector = CrOrderBuilder.GetCompanyCustomer().GetAddressSelector();
            }
            else
            {
                OrderInfo.AddressSelector = "";
            }

            OrderInfo.OrderType = WebpayWS.OrderType.Invoice;
            return OrderInfo;
        }
    }
}