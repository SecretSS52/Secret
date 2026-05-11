using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLibrary
{
    public class OrderCalculator
    {
        public float CalculateDiscount(float kolvo, float price, float discount) 
        {
            string path = Path.Combine(AppContext.BaseDirectory, "traceLog.txt");
            TextWriterTraceListener myListener = new TextWriterTraceListener(path);
            
            Trace.Listeners.Add(myListener);
            if (kolvo <= 0)
            {
                Debug.WriteLine("Была ошибка1");
                Trace.WriteLine("Была ошибка1");
                Trace.Flush();
                throw new ArgumentException("Количество товара должно быть больше нуля");
                
            }

            if (price <= 0)
            {
                Debug.WriteLine("Была ошибка2 дебаг");
                Trace.WriteLine("Была ошибка2 трейс");
                Trace.Flush();
                throw new ArgumentException("Цена товара должно быть больше нуля");
                
            }

            if (discount <= 0 || discount >= 100)
            {
                Debug.WriteLine("Была ошибка3");
                Trace.WriteLine("Была ошибка3");
                Trace.Flush();
                throw new ArgumentException("Скидка товара должно быть от 0 до 100");
                
            }

            return kolvo * price - (kolvo * price * discount)/100;
        }
    }

}



