using System.Xml;
using Webpay.Integration.Hosted.Admin.Response;

namespace Webpay.Integration.Hosted.Admin.Actions
{
    public class Credit
    {
        public readonly long AmountToCredit;
        public readonly long TransactionId;

        public Credit(long transactionId, long amountToCredit)
        {
            TransactionId = transactionId;
            AmountToCredit = amountToCredit;
        }

        public static CreditResponse Response(XmlDocument responseXml)
        {
            return new CreditResponse(responseXml);
        }
    }
}