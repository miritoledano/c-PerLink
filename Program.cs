using System;
using System.Collections.Generic;
using System.IO;

namespace preLink
{
    delegate void ArrayPrinterDelegate(int[] array);

    class ArrayHandler
    {

        public static void PrintArray(int[] array)
        {

            ArrayPrinterDelegate arrayPrinter = PrintArrayContent;
            arrayPrinter(array);
        }


        private static void PrintArrayContent(int[] array)
        {
            Console.WriteLine("Array content:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

    }

    public interface INameId
    {
        string Name { get; }
        int Id { get; }
    }

    public static class MyExtensions
    {
        public static void CompareToPrint(this IComparable obj, object other)
        {
            int result = obj.CompareTo(other);
            if (result == 0)
            {
                Console.WriteLine("Objects are equal");
            }
            else if (result < 0)
            {
                Console.WriteLine("Object is less than other");
            }
            else
            {
                Console.WriteLine("Object is greater than other");
            }
        }

        public static void CompareNameId(this INameId obj1, INameId obj2)
        {
            if (obj1.Name == obj2.Name && obj1.Id == obj2.Id)
            {
                Console.WriteLine("Objects have the same Name and Id");
            }
            else
            {
                Console.WriteLine("Objects do not have the same Name and Id");
            }
        }
    }

    public class ExampleClass : INameId
    {
        public string Name { get; }
        public int Id { get; }

        public ExampleClass(string name, int id)
        {
            Name = name;
            Id = id;
        }
       
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            ExampleClass obj1 = new ExampleClass("John", 1);
            ExampleClass obj2 = new ExampleClass("Jane", 2);

            int y = 7;
            y.CompareToPrint(7);
            obj1.CompareNameId(obj2);

            // Example usage for built-in class (using System.String as an example)
            string str1 = "Hello";
            string str2 = "World";
            //str1.CompareToPrint(str2);

            int x = 3;
            x.Print("Red");

            char ch1 = 'ש';
            ch1.ch();
            DateTime date1 = new DateTime(2024, 4, 7);
            DateTime date2 = new DateTime(2024, 4, 14);
            DateComparisonDelegate isSameWeekDay = IsSameWeekDay;
            DateComparisonDelegate isSameMonth = IsSameMonth;
            DateComparisonDelegate isSameYear = IsSameYear;

            Console.WriteLine($"Are the dates on the same weekday? {isSameWeekDay(date1, date2)}");
            Console.WriteLine($"Are the dates in the same month? {isSameMonth(date1, date2)}");
            Console.WriteLine($"Are the dates in the same year? {isSameYear(date1, date2)}");
            int days = 7;
            DateComparisonDelegate isWithinDaysDifference = (date3, date4) => (date3 - date4).Duration() <= TimeSpan.FromDays(days);
            
            Console.WriteLine($"Is the difference between the dates within {days} days? {isWithinDaysDifference(date1, date2)}");
            int[] arr = { 1, 2, 3 };
            ArrayHandler.PrintArray(arr);



        }
        public static void Print(this int number, string color)
        {
            Console.WriteLine($"{color}{number}");
        }

   
       
    
    public static void ch(this char tav)
        {
          

            Dictionary<char, char> translationMap = new Dictionary<char, char>()
            {
                {'a', 'ש'}, {'b', 'נ'}, {'c', 'ב'}, {'d', 'ג'}, {'e', 'ק'},
                {'f', 'כ'}, {'g', 'ע'}, {'h', 'י'}, {'i', 'ן'}, {'j', 'ח'},
                {'k', 'ל'}, {'l', 'ך'}, {'m', 'צ'}, {'n', 'מ'}, {'o', 'ם'},
                {'p', 'פ'}, {'q', '/'}, {'r', 'ר'}, {'s', 'ד'}, {'t', 'א'},
                {'u', 'ו'}, {'v', 'ה'}, {'x', 'ס'}, {'y', 'ט'}, {'z', 'ז'},
                {'A', 'ש'}, {'B', 'נ'}, {'C', 'ב'}, {'D', 'ג'}, {'E', 'ק'},
                {'F', 'כ'}, {'G', 'ע'}, {'H', 'י'}, {'I', 'ן'}, {'J', 'ח'},
                {'K', 'ל'}, {'L', 'ך'}, {'M', 'צ'}, {'N', 'מ'}, {'O', 'ם'},
                {'P', 'פ'}, {'Q', '/'}, {'R', 'ר'}, {'S', 'ד'}, {'T', 'א'},
                {'U', 'ו'}, {'V', 'ה'}, {'X', 'ס'}, {'Y', 'ט'}, {'Z', 'ז'}
            };

            // בדיקה האם התו קיים במיפוי
            if (translationMap.ContainsKey(char.ToUpper(tav)))
            {
                Console.WriteLine(translationMap[char.ToUpper(tav)]);
            }
            else
            {
                Console.WriteLine(tav); // אם התו לא נמצא במיפוי, הדפסת התו המקורי
            }
        }
        static bool IsSameWeekDay(DateTime date1, DateTime date2)
        {
            return date1.DayOfWeek == date2.DayOfWeek;
        }

        // פונקציה לבדיקה האם שני תאריכים חלים באותו חודש
        static bool IsSameMonth(DateTime date1, DateTime date2)
        {
            return date1.Month == date2.Month;
        }

        // פונקציה לבדיקה האם שני תאריכים חלים באותה שנה
        static bool IsSameYear(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year;
        }
    }
}
