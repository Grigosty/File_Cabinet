using System.Diagnostics.Metrics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Console;


namespace Картотека
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool indikator = true;
            Human h = new Human();
            do
            {
                string pathNames = "C:\\Users\\Admin\\Desktop\\учеба\\мои проекты\\Картотека\\Картотека\\Картотека.txt";
                string[] PersonInfoArray = File.ReadAllLines(pathNames);
                WriteLine("Выберите действие:");
                WriteLine("1.Просмотр");
                WriteLine("2.Добавление");
                int counter = Human.CheckPerson(PersonInfoArray);
                int check = Convert.ToInt32(ReadLine());
                if(check == 1)
                {
                    Human.GetPerson(PersonInfoArray); //Вызов метода для вывода всех людей из картотеки
                }
                else
                { 
                    Human.AddPersonAsync(counter);//Добавление нового человека под (последним+1) номером
                }
                WriteLine("Продолжить? \n yes/no");
                string answer = ReadLine();
                if (answer == "no")
                {
                    indikator = false;   
                }
            }
            while (indikator == true);
        }
     

        public class Human
        {
            public static int CheckPerson(string[] PersonInfoArray)
            {  
                int counter=0;
                for (int i = 0; i < PersonInfoArray.Length; i++)
                {
                    if (PersonInfoArray[i].StartsWith("Person") == true)
                    {
                        string checker = PersonInfoArray[i];
                        counter = Convert.ToInt32(checker.Trim('N',':','P','e','r','s','o','n',' '));
                    }  
                }
                return counter;
            }
            public static void GetPerson(string[] PersonInfoArray)
            {
                WriteLine("Введите номер пользователя:");
                
                    for (int i = 0; i < PersonInfoArray.Length; i++)
                    {
                        WriteLine(PersonInfoArray[i]);
                    }   
            }
            public static async Task AddPersonAsync(int counter)
            {
                string pathNames = "C:\\Users\\Admin\\Desktop\\учеба\\мои проекты\\Картотека\\Картотека\\Картотека.txt";
                using (StreamWriter writer = new StreamWriter(pathNames, true))
                {
                    await writer.WriteLineAsync($"Person N:{counter+1}");
                }
                WriteLine("Введите имя:");
                using (StreamWriter writer = new StreamWriter(pathNames, true))
                {
                    await writer.WriteLineAsync(ReadLine());  
                }
                WriteLine("Введите фамилию:");
                using (StreamWriter writer = new StreamWriter(pathNames, true))
                {
                    await writer.WriteLineAsync(ReadLine());
                }
                WriteLine("Введите возраст:");
                using (StreamWriter writer = new StreamWriter(pathNames, true))
                {
                    await writer.WriteLineAsync(ReadLine());
                }
            }
         /*   public static string[] MemoryOfKartoteka(string file)
            {
                string arrayOfLines;
                return;
            }
         */
        }
    }
}

/*
 Алгоритм:
1) Сделать механизм добавления пользователей +
2) Сделать механизм вывода уже находящихся в картотеке пользователей +
3) Сделать механизм поиска пользователя по его номеру/имени/фамилии/возраста ( механизм сортировки пользователей ) -work
4) 
 */