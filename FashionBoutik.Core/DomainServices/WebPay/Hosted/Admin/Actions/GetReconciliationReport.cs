using System;
using System.Xml;
using Webpay.Integration.Hosted.Admin.Response;

namespace Webpay.Integration.Hosted.Admin.Actions
{
    public class GetReconciliationReport
    {
        public readonly DateTime Date;

        public GetReconciliationReport(DateTime date)
        {
            Date = date;
        }

        public static GetReconciliationReportResponse Response(XmlDocument responseXml)
        {
            return new GetReconciliationReportResponse(responseXml);
        }
    }
}