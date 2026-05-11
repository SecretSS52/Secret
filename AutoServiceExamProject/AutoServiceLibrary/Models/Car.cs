namespace AutoServiceLibrary.Models;

/// <summary>Автомобиль клиента.</summary>
public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string brand, string model, int year)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Марка автомобиля не может быть пустой.");

        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Модель автомобиля не может быть пустой.");

        if (year < 1980 || year > DateTime.Now.Year)
            throw new ArgumentException("Некорректный год автомобиля.");

        Brand = brand;
        Model = model;
        Year = year;
    }
}
