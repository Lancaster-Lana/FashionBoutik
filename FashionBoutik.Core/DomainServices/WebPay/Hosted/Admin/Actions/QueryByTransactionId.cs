using System;
using System.Collections.Generic;
using System.Xml;

namespace Webpay.Integration.Hosted.Admin.Actions
{
    public class QueryByTransactionId : Query
    {
        public readonly long TransactionId;

        public QueryByTransactionId(long transactionId)
        {
            TransactionId = transactionId;
        }
    }

}