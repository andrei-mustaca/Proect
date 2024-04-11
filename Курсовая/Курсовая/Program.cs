using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовая
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hotel> list1 = new List<Hotel>();
            List<Client> list2 = new List<Client>();
            List<Employee> list3 = new List<Employee>();
            bool flag = true;
            //Добавление и запись
            while (flag)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("ПЕРВОЕ МЕНЮ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[1] Считывание данных");
                Console.WriteLine("[2] Добавление клиента");
                Console.WriteLine("[3] Добавление служащего");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[4] Выход из первого меню");
                Console.WriteLine("[5]-Выход из программы для сохранения добавленных данных данных");
                Console.ResetColor();
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        try
                        {
                            Console.Clear();
                            using (StreamReader reader = new StreamReader(@"C:\Users\andre\OneDrive\Рабочий стол\Курсач\Служащие.txt"))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    list3.Add(Employee.ReaderEmployee(line));
                                }
                            }
                            using (StreamReader reader = new StreamReader(@"C:\Users\andre\OneDrive\Рабочий стол\Курсач\Клиенты.txt"))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    list2.Add(Client.ReaderClient(line));
                                }
                            }
                            using (StreamReader reader = new StreamReader(@"C:\Users\andre\OneDrive\Рабочий стол\Курсач\Номера.txt"))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    list1.Add(Hotel.ReaderNumbers(line, list2, list3));
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Считывание удалось");
                            Console.ResetColor();
                            Console.Write("Хотите продолжить?");
                            string answer = Console.ReadLine();
                            if (answer == "Нет" || answer == "нет")
                            {
                                flag = false;
                            }
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Считывание не удалось");
                        }
                        break;
                    case '2':
                        try
                        {
                            Console.Clear();
                            list2.Add(Client.AddClient());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Новый клиент успешно добавлен");
                            Console.ResetColor();
                            Console.Write("Хотите продолжить выбор из первого меню? ");
                            string answer = Console.ReadLine();
                            if(answer=="Нет"||answer=="нет")
                            {
                                flag = false;
                            }
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Произошла ошибка, попробуйте еще раз");
                            Console.ResetColor();
                        }
                        break;
                    case '3':
                        try
                        {
                            Console.Clear();
                            list3.Add(Employee.AddEmployee());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Новый служащий успешно добавлен");
                            Console.ResetColor();
                            Console.Write("Хотите продолжить выбор из первого меню? ");
                            string answer = Console.ReadLine();
                            if (answer == "Нет" || answer == "нет")
                            {
                                flag = false;
                            }
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Произошла ошибка, попробуйте еще раз");
                            Console.ResetColor();
                        }
                        break;
                    case '4':
                        flag = false;
                        break;
                    case '5':
                        foreach (var elem in list2)
                        {
                            elem.SaveClients();
                        }
                        foreach (var elem in list3)
                        {
                            elem.SaveEmployees();
                        }
                        return;
                }
            }
            bool flag_main = true;
            while (flag_main)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("ГЛАВНОЕ МЕНЮ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[1] Номера");
                Console.WriteLine("[2] Клиенты");
                Console.WriteLine("[3] Служащие");
                Console.WriteLine("[4] Выход из программы");
                Console.ResetColor();
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        bool flag_number = true;
                        while(flag_number)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("[1] Вывод информации о номерах");
                            Console.WriteLine("[2] Стоимость места для определенного номера");
                            Console.WriteLine("[3] Кол-во свободных номеров");
                            Console.WriteLine("[4] Общая сумма за заселенные номера");
                            Console.WriteLine("[5] Выход в главное меню");
                            Console.ResetColor();
                            switch(Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    try
                                    {
                                        Console.Clear();
                                        foreach (var elem in list1)
                                        {
                                            elem.Print();
                                        }
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Информация успешно выведена");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_number = false;
                                        }
                                    }
                                   catch
                                    {
                                        Console.WriteLine("Ошибка");
                                    }
                                    break;
                                case '2':
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите необходимый номер:");
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        foreach (var elem in list1)
                                        {
                                            if (elem.Number == n)
                                            {
                                                Console.WriteLine($"Стоимость {elem.Number} составляет {elem.Cost()} руб. за место");
                                            }
                                        }
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_number = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка");
                                    }
                                    break;
                                case '3':
                                    try
                                    {
                                        Console.Clear();
                                        foreach (var elem in list1)
                                        {
                                            elem.Empty_number();
                                        }
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_number = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка");
                                    }
                                    break;
                                case '4':
                                    try
                                    {
                                        Console.Clear();
                                        int sum = 0;
                                        int sum_days = 0;
                                        foreach (var elem in list2)
                                        {
                                            sum_days += elem.Kol_vo_days;
                                        }
                                        foreach (var elem in list1)
                                        {
                                            if (elem.list1.Count != 0)
                                            {
                                                sum += elem.Cost();
                                            }
                                        }
                                        Console.WriteLine($"Общая сумма выплаченная клиентами равняется {sum * sum_days} руб.");
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_number = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка");
                                    }
                                    break;
                                case '5':flag_number = false;
                                    break;
                                default:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка попробуйте еще раз");
                                        Console.ResetColor();
                                    break;
                            }
                        }
                        break;
                    case '2':
                        bool flag_client = true;
                        while(flag_client)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("[1] Вывод информации о клиентах");
                            Console.WriteLine("[2] Список клиентов,прибывших из указанного города");
                            Console.WriteLine("[3] Клиенты проживающие в одноместных номерах");
                            Console.WriteLine("[4] Выход в главное меню");
                            Console.ResetColor();
                            switch(Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    try
                                    {
                                        Console.Clear();
                                        foreach (var elem in list2)
                                        {
                                            elem.PrintClient();
                                        }
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_client = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка,попробуйте еще раз");
                                    }
                                    break;
                                case '2':
                                    try
                                    {
                                        Console.Clear();
                                        Client.City(list2);
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_client = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка,попробуйте еще раз");
                                    }
                                    break;
                                case '3':
                                    try
                                    {
                                        Console.Clear();
                                        foreach (var elem in list2)
                                        {
                                            elem.Single();
                                        }
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_client = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка,попробуйте еще раз");
                                    }
                                    break;
                                case '4':flag_client = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка попробуйте еще раз");
                                    Console.ResetColor();
                                    break;
                            }
                        }
                        foreach (var elem in list3)
                        {
                            elem.PrintEmployee();
                        }
                        break;
                    case '3':
                        bool flag_employee = true;
                        while(flag_employee)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("[1] Вывод информации о служащих");
                            Console.WriteLine("[2] Информация о служащем,убиравшим этаж в определенный день");
                            Console.WriteLine("[3] Принятие на работу нового служащего");
                            Console.WriteLine("[4] Увольнение служащего");
                            Console.WriteLine("[5] Выход в главное меню");
                            Console.ResetColor();
                            switch(Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    try
                                    {
                                        Console.Clear();
                                        foreach(var elem in list3)
                                        {
                                            elem.PrintEmployee();
                                        }
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_employee = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ReadLine();
                                    }
                                    break;
                                case '2':
                                    try
                                    {
                                        Console.Clear();
                                        foreach (var elem in list3)
                                        {
                                            elem.Cleaning();
                                        }
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_employee = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка,попробуйте еще раз");
                                    }
                                    break;
                                case '3':
                                    try
                                    {
                                        Console.Clear();
                                        list3.Add(Employee.AddEmployee());
                                        list3.Last().SaveEmployees();
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_employee = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка,попробуйте еще раз");
                                    }
                                    break;
                                case '4':
                                    try
                                    {
                                        Employee.Delete(list3);
                                        Console.Write("Хотите продолжить? ");
                                        string answer = Console.ReadLine();
                                        if (answer == "Нет" || answer == "нет")
                                        {
                                            flag_employee = false;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка,попробуйте еще раз");
                                    }
                                    break;
                                case '5':flag_employee = false;
                                    break;
                                default:Console.WriteLine("Ошибка,попробуйте еще раз");
                                    break;
                            }
                        }
                        break;
                    case '4':return;
                    default:Console.WriteLine("Ошибка,попробуйте еще раз");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
