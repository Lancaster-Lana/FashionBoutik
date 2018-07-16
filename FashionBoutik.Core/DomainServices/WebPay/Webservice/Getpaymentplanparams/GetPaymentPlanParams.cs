﻿using System.ServiceModel;
using System.Threading.Tasks;
using Webpay.Integration.CONST;
using Webpay.Integration.Exception;
using WebpayWS;

namespace Webpay.Integration.Webservice.Getpaymentplanparams
{
    public class GetPaymentPlanParams
    {
        protected ServiceSoapClient Soapsc;
        private CountryCode _countryCode;
        private readonly IConfigurationProvider _config;

        public GetPaymentPlanParams(IConfigurationProvider config)
        {
            _config = config;
        }

        /// <summary>
        /// Required
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns>GetPaymentPlanParams</returns>
        public GetPaymentPlanParams SetCountryCode(CountryCode countryCode)
        {
            _countryCode = countryCode;
            return this;
        }

        protected ClientAuthInfo GetStoreAuthorization()
        {
            var auth = new ClientAuthInfo
                {
                    ClientNumber = _config.GetClientNumber(PaymentType.PAYMENTPLAN, _countryCode),
                    Password = _config.GetPassword(PaymentType.PAYMENTPLAN, _countryCode),
                    Username = _config.GetUsername(PaymentType.PAYMENTPLAN, _countryCode)
                };

            return auth;
        }

        public string ValidateRequest()
        {
            return _countryCode == CountryCode.NONE ? "MISSING VALUE - CountryCode is required, use SetCountryCode(...).\n" : "";
        }

        /// <summary>
        /// prepareRequest
        /// </summary>
        /// <exception cref="SveaWebPayValidationException"></exception>
        /// <returns>SveaRequest</returns>
        public GetPaymentPlanParamsEuRequest PrepareRequest()
        {
            string errors = ValidateRequest();
            if (errors.Length > 0)
            {
                throw new SveaWebPayValidationException(errors, null);
            }

            var request = new GetPaymentPlanParamsEuRequest
                {
                    Auth = GetStoreAuthorization()
                };

            return request;
        }

        /// <summary>
        /// doRequest
        /// </summary>
        /// <returns>PaymentPlanParamsResponse</returns>
        public async Task<GetPaymentPlanParamsEuResponse> DoRequest()
        {
            GetPaymentPlanParamsEuRequest request = PrepareRequest();

            Soapsc = new ServiceSoapClient(new BasicHttpBinding
                {
                    Name = "ServiceSoap",

                    //Security = new BasicHttpSecurity()
                    //    {
                    //        Mode = BasicHttpSecurityMode.Transport
                    //    }
                }, new EndpointAddress(_config.GetEndPoint(PaymentType.PAYMENTPLAN)));

            return await Soapsc.GetPaymentPlanParamsEuAsync(request);
        }
    }
}