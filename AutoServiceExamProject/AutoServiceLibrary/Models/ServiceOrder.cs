namespace AutoServiceLibrary.Models;

// Заказ клиента в автосервисе.
public class ServiceOrder
{
    public Client Client { get; set; }
    public Car Car { get; set; }
    public List<ServiceItem> Services { get; set; }

    public ServiceOrder(Client client, Car car)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
        Car = car ?? throw new ArgumentNullException(nameof(car));
        Services = new List<ServiceItem>();
    }

    public void AddService(ServiceItem service)
    {
        if (service == null)
            throw new ArgumentNullException(nameof(service));

        Services.Add(service);
    }
}
