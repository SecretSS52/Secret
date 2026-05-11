using Magaz.Enum;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;

namespace Magaz.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

        public Product(string name, Category category, decimal price)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "gay.txt");
            Trace.Listeners.Add(new TextWriterTraceListener(path));


            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.WriteLine("Имя продукта не может быть пустым.");
                Trace.WriteLine("Имя продукта не может быть пустым.");
                Trace.Flush();
                throw new ArgumentException("Имя продукта не может быть пустым.");
            }

            if (price <= 0)
            {
                Debug.WriteLine("Цена не должна быть меньше нуля");
                Trace.WriteLine("Цена не должна быть меньше нуля");
                Trace.Flush();
                throw new ArgumentException("Цена продукта должна быть больше нуля.");
            }

            Name = name;
            Category = category;
            Price = price;
        }
    }
    

}

