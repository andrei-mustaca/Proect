using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовая
{
    class Employee
    {
        /// <summary>
        /// Свойства
        /// </summary>
        public int Key { set; get; }
        public string FIO { set; get; }
        public List<int> floors = new List<int>(7);
        public List<string> days = new List<string>(7);
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fio"></param>
        /// <param name="floors"></param>
        /// <param name="days"></param>
        public Employee(int key,string fio,List<int>floors,List<string>days)
        {
            Key = key;
            FIO = fio;
            this.floors = floors;
            this.days = days;
        }
        /// <summary>
        /// Метод добавления
        /// </summary>
        /// <returns></returns>
        public static Employee AddEmployee()
        {
            Console.Write("Введите ключ:");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ФИО:");
            string fio = Console.ReadLine();
            List<int> floors = new List<int>(7);
            for(int i=0;i<floors.Capacity;i++)
            {
                Console.Write("Введите этаж:");
                floors.Add(Convert.ToInt32(Console.ReadLine()));
                if(floors[i]>3)
                {
                    Console.Write("Попробуйте еще раз,ошибка:");
                    floors[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            List<string> days = new List<string>(7);
            for(int i=0;i<days.Capacity;i++)
            {
                Console.Write("Введите день недели:");
                days.Add(Console.ReadLine());
            }
            return new Employee(key,fio,floors,days);
        }
        /// <summary>
        /// Метод записи в файл
        /// </summary>
        public void SaveEmployees()
        {
            using (StreamWriter writer=new StreamWriter(@"C:\Users\andre\OneDrive\Рабочий стол\Курсач\Служащие.txt", true))
            {
                writer.WriteLine($"{Key};{FIO};{floors[0]};{floors[1]};{floors[2]};" +
                    $"{floors[3]};{floors[4]};{floors[5]};" +
                    $"{floors[6]};{days[0]};{days[1]};" +
                    $"{days[2]};{days[3]};{days[4]};{days[5]};{days[6]};");
            }
        }
        /// <summary>
        /// Метод чтения
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Employee ReaderEmployee(string line)
        {
            string[] parts = line.Split(';');
            List<int> floors_txt = new List<int>();
            for(int i=2;i<=8;i++)
            {
                floors_txt.Add(int.Parse(parts[i]));
            }
            List<string> days_txt = new List<string>();
            for(int i=9;i<=15;i++)
            {
                days_txt.Add(parts[i]);
            }
            return new Employee(int.Parse(parts[0]),parts[1],floors_txt,days_txt);
        }
        /// <summary>
        /// Метод вывода информации
        /// </summary>
        public void PrintEmployee()
        {
            Console.WriteLine($"Ключ:{Key},ФИО:{FIO}");
            foreach(var elem in floors)
            {
                Console.WriteLine($"Этаж:{elem};");
            }
            foreach(var elem in days)
            {
                Console.WriteLine($"День недели:{elem}");
            }
        }
        public  void Cleaning()
        {
            Console.WriteLine("Введите день недели:");
            string day = Console.ReadLine();
            Console.WriteLine("Введите этаж:");
            int floor = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<days.Count;i++)
            {
               if(days[i]==day&&floors[i]==floor)
                {
                    PrintEmployee();
                }
            }
        }
        public static void Delete(List<Employee>employees)
        {
            Console.Write("Введите номер служащего,которого необходимо удалить:");
            int delete = Convert.ToInt32(Console.ReadLine());
            employees = employees.Where(x=>x.Key!=delete).ToList();
            string[] lines = File.ReadAllLines(@"C:\Users\andre\OneDrive\Рабочий стол\Курсач\Служащие.txt");
            if(delete-1>=0&&delete-1<lines.Length)
            {
                lines = lines.Where((line, index) => index != delete - 1).ToArray();
            }
            File.WriteAllLines(@"C:\Users\andre\OneDrive\Рабочий стол\Курсач\Служащие.txt", lines);
        }
    }
}
