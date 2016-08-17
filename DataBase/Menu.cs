using System;
using System.Collections.Generic;
using System.IO;

namespace DataBase
{
    class Menu
    {
        List<Employee> sourceList = new List<Employee>();
        List<Employee> listToShow = new List<Employee>();

        Options option = new Options();

        XmlReaderWriter xml = new XmlReaderWriter();
        BinReaderWriter bin = new BinReaderWriter();

        string typeOfSerialization;
        string pathXml = "employees.xml";
        string pathBin = "employees.dat";

        public void Show()
        {
            try
            {
                using (StreamReader sr = new StreamReader("settings.ini"))
                {
                    typeOfSerialization = sr.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл конфигурации не найден, создайте файл settings.ini");
                return;
            }
            
            if (typeOfSerialization == "xml")
            {
                FileInfo fi = new FileInfo(pathXml);
                if (fi.Exists)
                {
                    try
                    {
                        sourceList = xml.Read(pathXml);
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Файл базы данных поврежден");
                        return;
                    }
                }
            }
            else if (typeOfSerialization == "bin")
            {
                FileInfo fi = new FileInfo(pathBin);
                if (fi.Exists)
                {
                    try
                    {
                        sourceList = bin.Read(pathBin);
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Файл базы данных поврежден");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл конфигурации настроен не верно, проверьте settings.ini");
                return;
            }

            option.GetAll(sourceList, listToShow);

            while (true)
            {
                Console.Clear();
                foreach (Employee e in listToShow)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");
                try
                {
                    string[] commands = Console.ReadLine().Split(' ');
                    if (commands[0].ToLower() == "exit")
                    {
                        Exit();
                        return;
                    }
                    if (commands.Length == 1)
                    {
                        Operations(commands[0].ToLower());
                    }
                    if (commands.Length == 2)
                    {
                        Operations(commands[0].ToLower(), commands[1].ToLower());
                    }
                    if (commands.Length > 2)
                    {
                        Help();
                        continue;
                    }
                }
                catch (Exception)
                {
                    Help();
                    continue;
                }
            }
        }

        private void Operations(string command)
        {
            switch (command)
            {
                case "add":
                    option.Create(sourceList, listToShow);
                    break;
                case "getall":
                    option.GetAll(sourceList, listToShow);
                    break;
                case "help":
                    Help();
                    break;
                case "sort":
                    option.SortById(sourceList, listToShow);
                    break;
                default:
                    Console.WriteLine("Неизвестная комманда");
                    Help();
                    break;
            }
        }

        private void Operations(string command, string id)
        {
            switch (command)
            {
                case "del":
                    option.DeleteById(sourceList, listToShow, Convert.ToInt32(id));
                    break;
                case "get":
                    option.GetById(sourceList, listToShow, Convert.ToInt32(id));
                    break;
                default:
                    Console.WriteLine("Неизвестная комманда");
                    Help();
                    break;
            }
        }

        private void Exit()
        {
            if (typeOfSerialization == "xml")
            {
                xml.Write(sourceList, pathXml);
            }
            else
            {
                bin.Write(sourceList, pathBin);
            }
        }

        private void Help()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("Add - Добавить сотрудника");
            Console.WriteLine("Del Id - Удалить сотрудника по Id");
            Console.WriteLine("Get Id - Получить информацию о сотруднике по Id");
            Console.WriteLine("GetAll - Получить информацию о всех сотрудниках");
            Console.WriteLine("Sort - Отсортировать информацию о сотрудниках по Id");
            Console.WriteLine("exit");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}
