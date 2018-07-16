using System.Xml;
using Webpay.Integration.CONST;
using Webpay.Integration.Hosted.Admin.Response;

namespace Webpay.Integration.Hosted.Admin.Actions
{
    public class Recur
    {
        public readonly long Amount;
        public readonly Currency Currency;
        public readonly string CustomerRefNo;
        public readonly string SubscriptionId;
        public readonly long Vat;

        public Recur(string customerRefNo, string subscriptionId, Currency currency, long amount, long vat = 0)
        {
            CustomerRefNo = customerRefNo;
            SubscriptionId = subscriptionId;
            Currency = currency;
            Amount = amount;
            Vat = vat;
        }

        public static RecurResponse Response(XmlDocument responseXml)
        {
            return new RecurResponse(responseXml);
        }
    }
}