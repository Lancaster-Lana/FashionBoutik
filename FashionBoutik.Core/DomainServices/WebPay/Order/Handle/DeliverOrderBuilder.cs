﻿using AdminWS;
using System;
using System.Collections.Generic;
using Webpay.Integration.CONST;
using Webpay.Integration.Hosted.Admin;
using Webpay.Integration.Hosted.Admin.Actions;
using Webpay.Integration.Order.Row;
using Webpay.Integration.Order.Validator;
using Webpay.Integration.Webservice.Handleorder;

namespace Webpay.Integration.Order.Handle
{
    public class DeliverOrderBuilder : OrderBuilder<DeliverOrderBuilder>
    {
        private HandleOrderValidator _validator;

        private long _orderId;
        private CONST.OrderType _orderType = CONST.OrderType.NONE;
        private DistributionType _distributionType;
        private long? _invoiceIdToCredit;
        private int _numberOfCreditDays;
        private DateTime? _captureDate;

        public DeliverOrderBuilder(IConfigurationProvider config) : base(config)
        {
            _captureDate = null;
        }

        public HandleOrderValidator GetValidator()
        {
            return _validator;
        }

        public DeliverOrderBuilder SetValidator(HandleOrderValidator validator)
        {
            _validator = validator;
            return this;
        }

        public long GetOrderId()
        {
            return _orderId;
        }

        public DeliverOrderBuilder SetOrderId(long orderId)
        {
            _orderId = orderId;
            return this;
        }

        public CONST.OrderType GetOrderType()
        {
            return _orderType;
        }

        public void SetOrderType(CONST.OrderType orderType)
        {
            _orderType = orderType;
        }

        public DistributionType GetInvoiceDistributionType()
        {
            return _distributionType;
        }

        public DeliverOrderBuilder SetInvoiceDistributionType(DistributionType type)
        {
            _distributionType = type;
            return this;
        }

        public long? GetCreditInvoice()
        {
            return _invoiceIdToCredit;
        }

        public DeliverOrderBuilder SetCreditInvoice(long invoiceId)
        {
            _invoiceIdToCredit = invoiceId;
            return this;
        }

        public int GetNumberOfCreditDays()
        {
            return _numberOfCreditDays;
        }

        public DeliverOrderBuilder SetNumberOfCreditDays(int numberOfCreditDays)
        {
            _numberOfCreditDays = numberOfCreditDays;
            return this;
        }

        /// <summary>
        /// Updates the invoice order with additional information and prepares it for delivery.
        /// Will automatically match all order rows that are to be delivered with those which was sent
        /// when creating the invoice order.
        /// </summary>
        /// <exception cref="SveaWebPayValidationException"></exception>
        /// <returns>HandleOrder</returns>
        public HandleOrder DeliverInvoiceOrder()
        {
            _orderType = CONST.OrderType.INVOICE;
            return new HandleOrder(this);
        }

        /// <summary>
        /// Prepares the PaymentPlan order for delivery.
        /// </summary>
        /// <exception cref="SveaWebPayValidationException"></exception>
        /// <returns>HandleOrder</returns>
        public HandleOrder DeliverPaymentPlanOrder()
        {
            _orderType = CONST.OrderType.PAYMENTPLAN;
            return new HandleOrder(this);
        }

        public override DeliverOrderBuilder SetFixedDiscountRows(List<FixedDiscountBuilder> fixedDiscountRows)
        {
            FixedDiscountRows = fixedDiscountRows;
            return this;
        }

        public override DeliverOrderBuilder SetRelativeDiscountRows(List<RelativeDiscountBuilder> relativeDiscountRows)
        {
            RelativeDiscountRows = relativeDiscountRows;
            return this;
        }

        public override DeliverOrderBuilder AddOrderRow(OrderRowBuilder itemOrderRow)
        {
            OrderRows.Add(itemOrderRow);
            return this;
        }

        public override DeliverOrderBuilder SetCountryCode(CountryCode countryCode)
        {
            _countryCode = countryCode;
            return this;
        }

        public override DeliverOrderBuilder AddOrderRows(IEnumerable<OrderRowBuilder> itemOrderRow)
        {
            OrderRows.AddRange(itemOrderRow);
            return this;
        }

        public override DeliverOrderBuilder AddDiscount(IRowBuilder itemDiscount)
        {
            if (itemDiscount is FixedDiscountBuilder)
            {
                FixedDiscountRows.Add(itemDiscount as FixedDiscountBuilder);
            }
            else
            {
                RelativeDiscountRows.Add(itemDiscount as RelativeDiscountBuilder);
            }
            return this;
        }

        public override DeliverOrderBuilder AddFee(IRowBuilder itemFee)
        {
            if (itemFee is ShippingFeeBuilder)
            {
                ShippingFeeRows.Add(itemFee as ShippingFeeBuilder);
            }
            else
            {
                InvoiceFeeRows.Add(itemFee as InvoiceFeeBuilder);
            }
            return this;
        }


        public DeliverOrderBuilder SetCaptureDate(DateTime captureDate)
        {
            _captureDate = captureDate;
            return this;
        }

        public HostedActionRequest DeliverCardOrder()
        {
            // no validation for this release, we fall back on the service error messages

            var action = new Confirm(
                this.GetOrderId(),
                this._captureDate ?? DateTime.Now // if no captureDate given, use today
            );

            var request = new HostedAdmin(_config, _countryCode);

            return request.Confirm( action );
        }
    }
}