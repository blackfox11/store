﻿using Store.Contractors;
using Store.Web.Contractors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.YandexKassa
{
    public class YandexKassaPaymentService : IPaymentService, IWebContractorService
    {
        public string UniqueCode => "YandexKassa";

        public string GetUri => "/YandexKassa/";

        public string Title => "Оплата банковской картой";

        public Form CreateForm(Order order)
        {
            return new Form(UniqueCode, order.Id, 1, true, new Field[0]);
        }

        public OrderPayment GetPayment(Form form)
        {
            return new OrderPayment(UniqueCode, "Оплата картой", new Dictionary<string, string>());
        }

        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> value)
        {
            return new Form(UniqueCode, orderId, 2, true, new Field[0]);
        }
    }
}
