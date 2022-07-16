using System;
using System.Xml;
using System.Xml.Linq;

namespace Task8
{
    internal class SubTask4
    {
        public void Execute()
        {
            Console.WriteLine("=== ЗАДАНИЕ 4 XML ===\n");

            while (true)
            {
                var xmlDoc = new XmlDocument();
                var rootElem = new XElement("Person");

                Console.WriteLine("===> Введите ФИО");
                var inputValue = Console.ReadLine();
                rootElem.Add(new XAttribute("name", inputValue));

                var addressElem = new XElement("Address");

                Console.WriteLine("===> Введите улицу");
                inputValue = Console.ReadLine();
                addressElem.Add(new XElement("Street", inputValue));

                Console.WriteLine("===> Введите дом");
                inputValue = Console.ReadLine();
                addressElem.Add(new XElement("HouseNumber", inputValue));

                Console.WriteLine("===> Введите квартиру");
                inputValue = Console.ReadLine();
                addressElem.Add(new XElement("FlatNumber", inputValue));

                rootElem.Add(addressElem);

                var phoneElem = new XElement("Phones");

                Console.WriteLine("===> Введите мобильный номер");
                inputValue = Console.ReadLine();
                phoneElem.Add(new XElement("MobilePhone", inputValue));

                Console.WriteLine("===> Введите домашний номер");
                inputValue = Console.ReadLine();
                phoneElem.Add(new XElement("FlatPhone", inputValue));

                rootElem.Add(phoneElem);

                rootElem.Save("xmlTest.xml");

                Console.WriteLine("==> xml файл сохранен, имя: xmlTest.xml");

                if (Program.YNQuestion("Завершить работу с заданием?"))
                    break;
            }
        }
    }
}
