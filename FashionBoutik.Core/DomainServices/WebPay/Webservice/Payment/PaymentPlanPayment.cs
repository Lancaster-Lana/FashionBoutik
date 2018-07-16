using Webpay.Integration.CONST;
using Webpay.Integration.Order.Create;
using WebpayWS;

namespace Webpay.Integration.Webservice.Payment
{
    public class PaymentPlanPayment : WebServicePayment
    {
        public PaymentPlanPayment(CreateOrderBuilder orderBuilder)
            : base(orderBuilder)
        {
            PayType = PaymentType.PAYMENTPLAN;
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

            OrderInfo.OrderType = WebpayWS.OrderType.PaymentPlan;
            return OrderInfo;
        }
    }
}