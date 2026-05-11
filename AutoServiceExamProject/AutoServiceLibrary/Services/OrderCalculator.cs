using System.Diagnostics;
using AutoServiceLibrary.Enums;
using AutoServiceLibrary.Exceptions;
using AutoServiceLibrary.Models;

namespace AutoServiceLibrary.Services;

//Главный класс, который выполняет расчет стоимости заказа.
public class OrderCalculator
{
    public decimal CalculateTotal(ServiceOrder order)
    {
        TraceLogger.Configure();

        Debug.WriteLine("Debug: запущен расчет заказа.");
        Trace.WriteLine("Trace: запущен расчет заказа.");

        if (order == null)
            throw new ArgumentNullException(nameof(order));

        if (order.Services.Count == 0)
            throw new OrderValidationException("В заказе должна быть хотя бы одна услуга.");

        decimal servicesSum = order.Services.Sum(service => service.Price);
        decimal discountPercent = GetDiscountPercent(order.Client.Level);
        decimal discountAmount = servicesSum * discountPercent / 100;
        decimal total = servicesSum - discountAmount;

        Debug.WriteLine($"Debug: клиент = {order.Client.FullName}");
        Debug.WriteLine($"Debug: автомобиль = {order.Car.Brand} {order.Car.Model}");
        Debug.WriteLine($"Debug: сумма услуг = {servicesSum}");
        Debug.WriteLine($"Debug: скидка = {discountPercent}%");
        Debug.WriteLine($"Debug: итог = {total}");

        Trace.WriteLine($"Trace: клиент = {order.Client.FullName}");
        Trace.WriteLine($"Trace: автомобиль = {order.Car.Brand} {order.Car.Model}");
        Trace.WriteLine($"Trace: сумма услуг = {servicesSum}");
        Trace.WriteLine($"Trace: скидка = {discountPercent}%");
        Trace.WriteLine($"Trace: итог = {total}");

        return total;
    }

    public decimal GetDiscountPercent(ClientLevel level)
    {
        return level switch
        {
            ClientLevel.Regular => 0,
            ClientLevel.Silver => 5,
            ClientLevel.Gold => 10,
            _ => 0
        };
    }
}
