using AutoServiceLibrary.Enums;

namespace AutoServiceLibrary.Models;

/// <summary>Клиент автосервиса.</summary>
public class Client
{
    public string FullName { get; set; }
    public ClientLevel Level { get; set; }

    public Client(string fullName, ClientLevel level)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Имя клиента не может быть пустым.");

        FullName = fullName;
        Level = level;
    }
}
