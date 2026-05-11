using AutoServiceLibrary.Enums;
using AutoServiceLibrary.Exceptions;
using AutoServiceLibrary.Models;
using AutoServiceLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoServiceTests;

[TestClass]
public sealed class OrderCalculatorTests
{
    [TestMethod]
    public void CalculateTotal_RegularClient_ReturnsTotalWithoutDiscount()
    {
        Client client = new Client("Иван Петров", ClientLevel.Regular);
        Car car = new Car("Skoda", "Octavia", 2018);
        ServiceOrder order = new ServiceOrder(client, car);
        order.AddService(new ServiceItem("Диагностика", ServiceCategory.Diagnostics, 1500));
        order.AddService(new ServiceItem("Замена масла", ServiceCategory.Oil, 2500));
        OrderCalculator calculator = new OrderCalculator();
        decimal result = calculator.CalculateTotal(order);
        Assert.AreEqual(4000, result);
    }

    [TestMethod]
    public void CalculateTotal_SilverClient_ReturnsTotalWithFivePercentDiscount()
    {
        Client client = new Client("Иван Петров", ClientLevel.Silver);
        Car car = new Car("Skoda", "Octavia", 2018);
        ServiceOrder order = new ServiceOrder(client, car);
        order.AddService(new ServiceItem("Диагностика", ServiceCategory.Diagnostics, 1500));
        order.AddService(new ServiceItem("Замена масла", ServiceCategory.Oil, 2500));
        OrderCalculator calculator = new OrderCalculator();
        decimal result = calculator.CalculateTotal(order);
        Assert.AreEqual(3800, result);
    }

    [TestMethod]
    public void CalculateTotal_GoldClient_ReturnsTotalWithTenPercentDiscount()
    {
        Client client = new Client("Иван Петров", ClientLevel.Gold);
        Car car = new Car("Skoda", "Octavia", 2018);
        ServiceOrder order = new ServiceOrder(client, car);
        order.AddService(new ServiceItem("Диагностика", ServiceCategory.Diagnostics, 1500));
        order.AddService(new ServiceItem("Замена масла", ServiceCategory.Oil, 2500));
        OrderCalculator calculator = new OrderCalculator();
        decimal result = calculator.CalculateTotal(order);
        Assert.AreEqual(3600, result);
    }

    [TestMethod]
    public void CalculateTotal_OrderWithoutServices_ThrowsOrderValidationException()
    {
        Client client = new Client("Иван Петров", ClientLevel.Gold);
        Car car = new Car("Skoda", "Octavia", 2018);
        ServiceOrder order = new ServiceOrder(client, car);
        OrderCalculator calculator = new OrderCalculator();
        Assert.ThrowsException<OrderValidationException>(() => calculator.CalculateTotal(order));
    }

    [TestMethod]
    public void CreateServiceItem_NegativePrice_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new ServiceItem("Замена масла", ServiceCategory.Oil, -100));
    }

    [TestMethod]
    public void CreateClient_EmptyName_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Client("", ClientLevel.Regular));
    }
}
