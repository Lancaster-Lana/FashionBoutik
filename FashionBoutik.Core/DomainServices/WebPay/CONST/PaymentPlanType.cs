﻿using System.Collections.Generic;
using System.Linq;

namespace Webpay.Integration.CONST
{
    public class PaymentPlanType
    {
        public static readonly PaymentPlanType PAYMENTPLANEUSE = new PaymentPlanType("SVEASPLITEU_SE", CountryCode.SE);
        public static readonly PaymentPlanType PAYMENTPLANSE = new PaymentPlanType("SVEASPLITSE", CountryCode.SE);
        public static readonly PaymentPlanType PAYMENTPLANNO = new PaymentPlanType("SVEASPLITEU_NO", CountryCode.NO);
        public static readonly PaymentPlanType PAYMENTPLANDK = new PaymentPlanType("SVEASPLITEU_DK", CountryCode.DK);
        public static readonly PaymentPlanType PAYMENTPLANFI = new PaymentPlanType("SVEASPLITEU_FI", CountryCode.FI);
        public static readonly PaymentPlanType PAYMENTPLANDE = new PaymentPlanType("SVEASPLITEU_DE", CountryCode.DE);
        public static readonly PaymentPlanType PAYMENTPLANNL = new PaymentPlanType("SVEASPLITEU_NL", CountryCode.NL);

        public string Value { get; private set; }
        public CountryCode CountryCode { get; private set; }

        private PaymentPlanType(string value, CountryCode countryCode)
        {
            Value = value;
            CountryCode = countryCode;
        }

        public static readonly List<PaymentPlanType> AllPaymentPlanValueTypes = new List<PaymentPlanType>
            {
                PAYMENTPLANEUSE,
                PAYMENTPLANSE,
                PAYMENTPLANNO,
                PAYMENTPLANDK,
                PAYMENTPLANFI,
                PAYMENTPLANDE,
                PAYMENTPLANNL
            };


        public static IEnumerable<string> AllPaymentPlanValues()
        {
            return AllPaymentPlanValueTypes.Select(it => it.Value);
        }

        public static IEnumerable<PaymentPlanType> AllPaymentPlanTypes()
        {
            return AllPaymentPlanValueTypes.Select(it => it);
        }
    }
}