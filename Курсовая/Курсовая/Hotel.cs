using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовая
{
    class Hotel
    {
        /// <summary>
        /// Свойства класса
        /// </summary>
        public int Number { set; get; }
        public int Floor { set; get; }
        public string Type { set; get; }
        public int Cost_per_day { set; get; }
        public List<Client> list1 = new List<Client>();
        public List<Employee> list2 = new List<Employee>();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="number"></param>
        /// <param name="floor"></param>
        /// <param name="type"></param>
        /// <param name="cost_per_day"></param>
        /// <param name="clients"></param>
        /// <param name="employees"></param>
        public Hotel(int number,int floor,string type,int cost_per_day,List<Client>clients,List<Employee>employees)
        {
            Number = number;
            Floor = floor;
            Type = type;
            Cost_per_day = cost_per_day;
            this.list1 = clients;
            this.list2 = employees;
        }
        /// <summary>
        /// Метод добавления номера
        /// </summary>
        /// <param name="clients_to_number"></param>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Hotel AddNumber(List<Client>clients_to_number,List<Employee>employees)
        {
            Console.Write("Номер:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Этаж:");
            int floor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Тип номера:");
            string type = Console.ReadLine();
            Console.Write("Стоимость одной ночи:");
            int cost_per_day = Convert.ToInt32(Console.ReadLine());
            List<Client> list1 = new List<Client>();
            for(int i=0;i<clients_to_number.Count;i++)
            {
                if(clients_to_number[i].Number==number&&clients_to_number[i].Place==type)
                {
                    list1.Add(clients_to_number[i]);
                }
            }
            List<Employee> list2 = new List<Employee>();
            list2 = employees;
            return new Hotel(number,floor,type,cost_per_day,list1,list2);
        }
        /// <summary>
        /// Метод записи информации о номерах в файл Номера.txt
        /// </summary>
        public void SaveHotel()
        {
            using (StreamWriter writer=new StreamWriter(@"C:\Users\andre\OneDrive\Документы\GitHub\Proect\Номера.txt",true))
            {
                writer.WriteLine($"{Number};{Floor};{Type};{Cost_per_day}");
            }
        }
        /// <summary>
        /// Чтение и запись в объекты строки файла
        /// </summary>
        /// <param name="line"></param>
        /// <param name="clients"></param>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Hotel ReaderNumbers(string line,List<Client>clients,List<Employee>employees)
        {
            string[] parts = line.Split(';');
            List<Client> clients_txt = new List<Client>();
            for(int i=0;i<clients.Count;i++)
            {
                if(int.Parse(parts[0])==clients[i].Number&&parts[2]==clients[i].Place)
                {
                    clients_txt.Add(clients[i]);
                }
            }
            List<Employee> employees_txt = employees;
            return new Hotel(int.Parse(parts[0]),int.Parse(parts[1]),parts[2],int.Parse(parts[3]),clients_txt,employees_txt);
        }
        /// <summary>
        /// Вывод информации
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Номер:{Number},Этаж:{Floor},Тип:{Type},Оплата:{Cost_per_day}");
        }
        public int Cost()
        {
            if(Type=="Одноместный")
            {
                return Cost_per_day;
            }
            else if(Type=="Двухместный")
            {
                return Cost_per_day / 2;
            }
            else
            {
                return Cost_per_day / 3;
            }
        }
        public void Empty_number()
        {
                if(list1.Count==0)
                {
                    Print();
                }
        }
    }
}
