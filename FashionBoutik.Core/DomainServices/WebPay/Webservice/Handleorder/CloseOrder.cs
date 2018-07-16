using System.ServiceModel;
using System.Threading.Tasks;
using Webpay.Integration.CONST;
using Webpay.Integration.Exception;
using Webpay.Integration.Order.Handle;
using WebpayWS;

namespace Webpay.Integration.Webservice.Handleorder
{
    public class CloseOrder
    {
        protected ServiceSoapClient Soapsc;
        private CloseOrderBuilder _order;

        public CloseOrder(CloseOrderBuilder order)
        {
            _order = order;
        }

        protected ClientAuthInfo GetStoreAuthorization()
        {
            PaymentType type = (_order.GetOrderType() == "Invoice" ? PaymentType.INVOICE : PaymentType.PAYMENTPLAN);

            var auth = new ClientAuthInfo
                {
                    Username = _order.GetConfig().GetUsername(type, _order.GetCountrycode()),
                    Password = _order.GetConfig().GetPassword(type, _order.GetCountrycode()),
                    ClientNumber = _order.GetConfig().GetClientNumber(type, _order.GetCountrycode())
                };
            return auth;
        }

        public string ValidateRequest()
        {
            string errors = "";
            if (_order.GetCountrycode() == CountryCode.NONE)
            {
                errors += "MISSING VALUE - CountryCode is required, use SetCountryCode(...).\n";
            }
            return errors;
        }

        /// <summary>
        /// prepareRequest
        /// </summary>
        /// <exception cref="SveaWebPayValidationException"></exception>
        /// <returns>SveaRequest</returns>
        public CloseOrderEuRequest PrepareRequest()
        {
            string errors = ValidateRequest();
            if (errors != "")
            {
                throw new SveaWebPayValidationException(errors);
            }

            var orderInfo = new CloseOrderInformation {SveaOrderId = _order.GetOrderId()};

            var sveaCloseOrder = new CloseOrderEuRequest
                {
                    CloseOrderInformation = orderInfo,
                    Auth = GetStoreAuthorization()
                };

            return sveaCloseOrder;
        }

        /// <summary>
        /// doRequest
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <returns>CloseOrderResponse</returns>
        public async Task<CloseOrderEuResponse> DoRequest()
        {
            CloseOrderEuRequest request = PrepareRequest();

            Soapsc = new ServiceSoapClient(new BasicHttpBinding
                {
                    Name = "ServiceSoap",
                    //Security = new BasicHttpSecurity
                    //    {
                    //        Mode = BasicHttpSecurityMode.Transport
                    //    }
                },
                                           new EndpointAddress(
                                               _order.GetConfig()
                                                     .GetEndPoint(_order.GetOrderType() == "Invoice"
                                                                      ? PaymentType.INVOICE
                                                                      : PaymentType.PAYMENTPLAN)));


            return await Soapsc.CloseOrderEuAsync(request);
        }
    }
}