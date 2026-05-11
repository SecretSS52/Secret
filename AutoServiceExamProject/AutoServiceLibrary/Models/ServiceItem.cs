using AutoServiceLibrary.Enums;

namespace AutoServiceLibrary.Models;

/// <summary>Одна услуга автосервиса.</summary>
public class ServiceItem
{
    public string Name { get; set; }
    public ServiceCategory Category { get; set; }
    public decimal Price { get; set; }

    public ServiceItem(string name, ServiceCategory category, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название услуги не может быть пустым.");

        if (price <= 0)
            throw new ArgumentException("Цена услуги должна быть больше нуля.");

        Name = name;
        Category = category;
        Price = price;
    }
}
