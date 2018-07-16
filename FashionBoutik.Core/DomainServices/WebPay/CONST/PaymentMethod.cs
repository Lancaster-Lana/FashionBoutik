﻿using System.Collections.Generic;

namespace Webpay.Integration.CONST
{
    public class PaymentMethod
    {
        public string Value { get; private set; }
        public PaymentMethodType PaymentMethodType { get; private set; }

        public static readonly PaymentMethod BANKAXESS = new PaymentMethod("BANKAXESS", PaymentMethodType.DIRECT);
        public static readonly PaymentMethod NORDEASE = new PaymentMethod("DBNORDEASE", PaymentMethodType.DIRECT);
        public static readonly PaymentMethod SEBSE = new PaymentMethod("DBSEBSE", PaymentMethodType.DIRECT);
        public static readonly PaymentMethod SEBFTGSE = new PaymentMethod("DBSEBFTGSE", PaymentMethodType.DIRECT);
        public static readonly PaymentMethod SHBSE = new PaymentMethod("DBSHBSE", PaymentMethodType.DIRECT);
        public static readonly PaymentMethod SWEDBANKSE = new PaymentMethod("DBSWEDBANKSE", PaymentMethodType.DIRECT);

        public static readonly PaymentMethod KORTCERT = new PaymentMethod("KORTCERT", PaymentMethodType.CARD);
        public static readonly PaymentMethod SKRILL = new PaymentMethod("SKRILL", PaymentMethodType.CARD);
        public static readonly PaymentMethod SVEACARDPAY = new PaymentMethod("SVEACARDPAY", PaymentMethodType.CARD);
        public static readonly PaymentMethod SVEACARDPAY_PF = new PaymentMethod("SVEACARDPAY_PF", PaymentMethodType.CARD);

        public static readonly PaymentMethod PAYPAL = new PaymentMethod("PAYPAL", PaymentMethodType.PSP);

        public static readonly PaymentMethod INVOICE = new PaymentMethod("INVOICE", PaymentMethodType.INVOICE);
        public static readonly PaymentMethod PAYMENTPLAN = new PaymentMethod("PAYMENTPLAN", PaymentMethodType.PAYMENTPLAN);

        private PaymentMethod(string value, PaymentMethodType paymentMethodType)
        {
            Value = value;
            PaymentMethodType = paymentMethodType;
        }

        public static readonly List<PaymentMethod> AllPaymentMethods = new List<PaymentMethod>
        {
            BANKAXESS,
            NORDEASE,
            SEBSE,
            SEBFTGSE,
            SHBSE,
            SWEDBANKSE,

            KORTCERT,
            SKRILL,
            SVEACARDPAY,
            SVEACARDPAY_PF,

            PAYPAL,

            INVOICE,
            PAYMENTPLAN
        };
    }
}