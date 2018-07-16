﻿using System.Xml;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Create;

namespace Webpay.Integration.Hosted.Payment
{
    /// <summary>
    /// Defines one payment method. Directs directly to method without going through PayPage.
    /// </summary>
    public class PaymentMethodPayment : HostedPayment
    {
        private PaymentMethod _paymentMethod;
        private string _simulatorCode;
        private SubscriptionType _subscriptionType;

        public PaymentMethodPayment(CreateOrderBuilder createOrderBuilder, PaymentMethod paymentMethod)
            : base(createOrderBuilder)
        {
            _paymentMethod = paymentMethod;
        }


        public PaymentMethod GetPaymentMethod()
        {
            return _paymentMethod;
        }

        /// <summary>
        /// Only used in CardPayment and DirectPayment
        /// </summary>
        public PaymentMethodPayment SetReturnUrl(string returnUrl)
        {
            ReturnUrl = returnUrl;
            return this;
        }

        public PaymentMethodPayment SetCancelUrl(string returnUrl)
        {
            CancelUrl = returnUrl;
            return this;
        }

        public PaymentMethodPayment SetCallbackUrl(string callbackUrl)
        {
            CallbackUrl = callbackUrl;
            return this;
        }

        public PaymentMethodPayment SetPayPageLanguageCode(LanguageCode languageCode)
        {
            LanguageCode = languageCode.ToString().ToLower();
            return this;
        }

        public PaymentMethodPayment ConfigureExcludedPaymentMethod()
        {
            return this;
        }

        /// <summary>
        /// CalculateRequestValues
        /// </summary>
        /// <exception cref="SveaWebPayValidationException"></exception>
        public override void CalculateRequestValues()
        {
            FormatRequestValues();
            ConfigureExcludedPaymentMethod();
        }

        public override void WritePaymentSpecificXml(XmlWriter xmlw)
        {
            if (_paymentMethod != null)
            {
                WriteSimpleElement(xmlw, "paymentmethod", _paymentMethod.Value);
            }
            if (_subscriptionType != null)
            {
                WriteSimpleElement(xmlw, "subscriptiontype", _subscriptionType.Value);
            }
            if (_simulatorCode != null)
            {
                WriteSimpleElement(xmlw, "simulatorCode", _simulatorCode);
            }
        }

        public PaymentMethodPayment SetSubscriptionType(SubscriptionType subscriptionType)
        {
            _subscriptionType = subscriptionType;
            return this;
        }

        public PaymentMethodPayment ___SetSimulatorCode_ForTestingOnly(string forcedResult)
        {
            _simulatorCode = forcedResult;
            return this;
        }
    }
}