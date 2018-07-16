﻿using System.Collections.Generic;
using Webpay.Integration.CONST;
using Webpay.Integration.Order.Row;

namespace Webpay.Integration.Order.Handle
{
    public class AddOrderRowsBuilder : Builder<AddOrderRowsBuilder>
    {
        internal long Id { get; private set; }
        internal PaymentType OrderType { get; set; }
        internal List<OrderRowBuilder> OrderRows { get; private set; }

        public AddOrderRowsBuilder(IConfigurationProvider config) : base(config)
        {
            this.OrderRows = new List<OrderRowBuilder>();
        }

        public AddOrderRowsBuilder SetOrderId(long orderId)
        {
            Id = orderId;
            return this;
        }

        public override AddOrderRowsBuilder SetCountryCode(CountryCode countryCode)
        {
            _countryCode = countryCode;
            return this;
        }

        public AddOrderRowsBuilder AddOrderRow(OrderRowBuilder orderRow)
        {
            OrderRows.Add(orderRow);
            return this;
        }
        public AddOrderRowsBuilder AddOrderRows( IList<OrderRowBuilder> orderRows)
        {
            OrderRows.AddRange(orderRows);
            return this;
        }

        public AdminService.AddOrderRowsRequest AddInvoiceOrderRows()
        {
            OrderType = PaymentType.INVOICE;
            return new AdminService.AddOrderRowsRequest(this);
        }
        public AdminService.AddOrderRowsRequest AddPaymentPlanOrderRows()
        {
            OrderType = PaymentType.PAYMENTPLAN;
            return new AdminService.AddOrderRowsRequest(this);
        }
    }
}