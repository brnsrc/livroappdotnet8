﻿
using FluentValidation.Models; // To use Order.
using FluentValidation.Results; // To use ValidationResult.
using FluentValidation.Validators; // To use OrderValidator.
using System.Globalization; // To use CultureInfo.
using System.Text; // To use Enconding;

OutputEncoding = Encoding.UTF8; //Enable Euro Symbol.

//Control the culture used for formatting of datets and currency
//and for localizing error messages to local language
Thread t = Thread.CurrentThread;
t.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
t.CurrentUICulture = t.CurrentCulture;
WriteLine($"Current culture: {t.CurrentCulture.DisplayName}");

WriteLine();
Order order = new()
{
    // Start with a deliberately invalid order.
    OrderId = 10001,
    CustomerName = "Abcdef",
    CustomerEmail = "abc@example.com",
    CustomerLevel = CustomerLevel.Gold,
    OrderDate = new(2022, month: 12, day: 1),
    ShipDate = new(2022, month: 12, day: 5),
    Total = 49.99M
};

OrderValidator validator = new();
ValidationResult result = validator.Validate(order);

//Output the order data
WriteLine($"CustomerName: {order.CustomerName}");
WriteLine($"CustomerEmail: {order.CustomerEmail}");
WriteLine($"CustomerLevel: {order.CustomerLevel}");
WriteLine($"OrderId: {order.OrderId}");
WriteLine($"OrderDate: {order.OrderDate}");
WriteLine($"ShipDate: {order.ShipDate}");
WriteLine($"Total: {order.Total:C}");
WriteLine();

//Output in the order is valid and any rules that were broken
WriteLine($"IsValid: {result.IsValid}");
foreach (var item in result.Errors)
{
    WriteLine($"{item.Severity}: {item.ErrorMessage}");
}

