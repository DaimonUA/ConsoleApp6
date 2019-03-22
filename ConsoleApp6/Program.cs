using System;
using System.Collections.Generic;
//Задание №1. Коллекции
//В задании на преобразование типов Занятие №07. C#. Объектная модель, Задание №4. Преобразование типов измените способ хранения объектов. Вместо массива необходимо использовать коллекцию.
//Реализуйте 4 версии текущего задания, используя следующие коллекции:
//1. ArrayList;
//2. List<T>;
//3. LinkedList<T>;
//4. Dictionary<T, V>.

//Задание №2. Строки
//Есть некий текст.Замените в этом тексте все слова "Nikolay" на "Oleg".

//Задание №3. Строки
//Дан текст – "Сегодня мы с вами рассмотрели, как работать со строками в Си-шарп. Были описаны основные операторы и методы, которые используются для работы со строками". Обрежьте этот текст так, чтобы осталась только часть "Были описаны основные операторы и методы".

//Задание №4. Строки
//Дана строка, которая содержит имена пользователей, разделенные запятой – "Login1,LOgin2,login3,loGin4". Разбейте эту строку на массив строк (чтобы отдельно были логины), и приведите их все в нижний регистр.

//Задание №5. Строки
//Напишите программу, которая запрашивает у пользователя строки.Ввод строк должен быть завершен, когда пользователь вводит строку end.Далее программа проверяет, есть ли в строке цифры, если да, добавляет в начало строки текст "Numbers: ", если нет – "No numbers: " и выводит результат в виде следующей таблицы:

//+-----------------+---------------------+
//| Исходная строка | Обработанная строка |
//+-----------------+---------------------+
//| строка_1        | строка_1_обр        |
//+-----------------+---------------------+
//| строка_2        | строка_2_обр        |
//+-----------------+---------------------+

namespace ConsoleHomeWork.CollectionAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "there were three sisters, three sisters, three sisters, three three three"+
"\nOne was called Olga, the second was Ekaterina, and the third was Nikolay.";
            Console.WriteLine(str.Replace("Nikolay", "Oleg"));

            str = "Сегодня мы с вами рассмотрели, как работать со строками в Си-шарп. Были описаны основные операторы и методы, которые используются для работы со строками";

            Console.WriteLine(str.Substring((str.IndexOf("Были"))));

            str = "lOgin1, login2, loGIN3,    LOgIN7";
           foreach(string str0 in str.Split(','))
            {
                Console.WriteLine(str0.ToLower().Trim());
            }

            Queue<(string, string)> q = new Queue<(string,string)>();
           bool a = true;
           string str1 = "Исходная строка";
           string str2 = "Обработанная строка";
            (int, int) maxPaire = (str1.Length, str2.Length);
            while (a)
            {
                str = Console.ReadLine().Trim().ToLower();
                switch (str)
                {
                    case "end": a = false;  break;
                    case "": break;
                    default:
                        {
                            (string, string) s = (str,null);
                            if (IsNumber(str))
                            {
                                s.Item2 = "Number:" + str;
                            }
                            else
                                s.Item2 = "No numbers: "+str;
                            q.Enqueue(s);
                            if (str.Length > maxPaire.Item1)
                            {
                                maxPaire.Item1 = str.Length;
                            }
                            if (s.Item2.Length > maxPaire.Item2)
                            {
                                maxPaire.Item2 = s.Item2.Length;
                            }
                            break;
                        }

                }
            };
            PrintItem(str1, str2, maxPaire);
            foreach ((string,string) s in q)
            {
                PrintItem(s.Item1,s.Item2,maxPaire);
            }
            PrintLineScreen(maxPaire.Item1 + maxPaire.Item2 + 2, maxPaire.Item1 + 1);
        }

        static public void PrintItem(string str1,string str2, (int x,int y)maxPaire)
        {
            PrintLineScreen(maxPaire.x + maxPaire.y + 2, maxPaire.x+1);
            ModifyString(ref str1, ref str2, maxPaire);
            Console.WriteLine("|"+str1 + "|"+str2+ "|");
        }

        static void PrintLineScreen(int maxL, int midL)
        {
            string res = "";
            for (int i = 0; i <= maxL; i++)
            {
                char s = '-';
                if (i == 0 || i == midL|| i == maxL)
                {
                    s = '+';
                }
                res += s;
            }
            Console.WriteLine(res);
        }
        static bool IsNumber(string s)
        {
            bool res = false;
            foreach (char sn in "0123456789")
            {
                if (s.Contains(sn))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
        static void ModifyString(ref string str1,ref string str2, (int x, int y)maxPaire)
        {
            ModifyString(ref str1, maxPaire.x);
            ModifyString(ref str2, maxPaire.y);
        }

        private static void ModifyString(ref string str, int x)
        {
            for (int i = str.Length+1; i<=x; i++)
            {
                str += " ";
            }
        }
    }
}
