using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовая
{
    class Client
    {
        public int Key { set; get; }
        public string FIO { set; get; }
        public int Number_pasport { set; get; }
        public string Where { set; get; }
        public int Number { set; get; }
        public string Place { set; get; }
        public int Kol_vo_days { set; get; }
        public DateTime Date { set; get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fio"></param>
        /// <param name="number_pasport"></param>
        /// <param name="where"></param>
        /// <param name="number"></param>
        /// <param name="place"></param>
        /// <param name="kol_vo_days"></param>
        public Client(int key,string fio,int number_pasport,string where,int number,string place,int kol_vo_days,DateTime date)
        {
            Key = key;
            FIO = fio;
            Number_pasport = number_pasport;
            Where = where;
            Number = number;
            Place = place;
            Kol_vo_days = kol_vo_days;
            Date = date;
        }

        /// <summary>
        /// Добавление объекта
        /// </summary>
        /// <returns></returns>
        public static Client AddClient()
        {
            Console.Write("Введите ключ:");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ФИО:");
            string fio = Console.ReadLine();
            Console.Write("Введите номер паспорта:");
            int number_pasport = Convert.ToInt32(Console.ReadLine());
            Console.Write("Откуда прибыл:");
            string where = Console.ReadLine();
            Console.Write("Номер в который заселился:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Место номера:");
            string place = Console.ReadLine();
            Console.Write("Количество дней проживания:");
            int kol_vo_days = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите дату приезда:");
            DateTime date = DateTime.Parse(Console.ReadLine());
            return new Client(key,fio,number_pasport,where,number,place,kol_vo_days,date);
        }
        /// <summary>
        /// Запись в файл Клиенты.txt
        /// </summary>
        public void SaveClients()
        {
            using (StreamWriter writer=new StreamWriter(@"C:\Users\andre\OneDrive\Документы\GitHub\Proect\Клиенты.txt",true))
            {
                writer.WriteLine($"{Key};{FIO};{Number_pasport};{Where};{Number};{Place};{Kol_vo_days};{Date.ToString("yyyy-MM-dd")};");
            }
        }
        /// <summary>
        /// Считывание с файла Клиенты.txt и запись результатов считывания в коллекцию
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Client ReaderClient(string line)
        {
            string[] parts = line.Split(';');
            return new Client(int.Parse(parts[0]),parts[1],int.Parse(parts[2]),parts[3],int.Parse(parts[4]),parts[5],int.Parse(parts[6]),DateTime.Parse(parts[7]));
        }
        /// <summary>
        /// Вывод информации в консоль
        /// </summary>
        public void PrintClient()
        {
            Console.WriteLine($"Ключ:{Key},ФИО:{FIO},Номер паспорта:{Number_pasport},Откуда:{Where}");
            Console.WriteLine($"Номер:{Number},Место:{Place},Кол-во дней:{Kol_vo_days},Дата приезда:{Date.ToString("yyyy-MM-dd")}");
        }
        public static void City(List<Client>clients)
        {
            Console.WriteLine("Введите название города:");
            string cities = Console.ReadLine();
            foreach(var elem in clients)
            {
                if(elem.Where==cities)
                {
                    elem.PrintClient();
                }
            }
        }
        public void Single()
        {
            if(Place=="Одноместный")
            {
                PrintClient();
            }
        }
    }
}
