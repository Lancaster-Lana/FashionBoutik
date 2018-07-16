using System;
using System.Xml;
using Webpay.Integration.Hosted.Admin.Response;

namespace Webpay.Integration.Hosted.Admin.Actions
{
    public class Confirm
    {
        public readonly DateTime CaptureDate;
        public readonly long TransactionId;

        public Confirm(long transactionId, DateTime captureDate)
        {
            TransactionId = transactionId;
            CaptureDate = captureDate;
        }

        public static ConfirmResponse Response(XmlDocument responseXml)
        {
            return new ConfirmResponse(responseXml);
        }
    }
}