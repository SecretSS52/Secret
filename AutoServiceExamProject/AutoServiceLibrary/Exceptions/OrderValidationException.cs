namespace AutoServiceLibrary.Exceptions;

/// <summary>Пользовательское исключение для ошибок проверки заказа.</summary>
public class OrderValidationException : Exception
{
    public OrderValidationException(string message) : base(message)
    {
    }
}
