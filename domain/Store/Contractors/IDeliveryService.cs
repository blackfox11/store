﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Contractors
{
    public interface IDeliveryService
    {
        string UniqueCode { get; }
        string Title { get; }
        Form CreateForm(Order order);
        Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> value);
        OrderDelivery GetDelivery(Form form);
    }
}
