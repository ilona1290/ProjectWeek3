using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using QuizWeek3.App.Concrete;

namespace QuizWeek3.App.Managers
{
    public class QuestionManager : CategoryManager
    {
        public void CheckCategoryToAddQuestion()
        {
            OpenCategory();
            Console.WriteLine("Podaj numer kategorii, do której chcesz dodać pytanie.");
            var categories = ShowItems();
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);
            foreach (var item in categories)
            {
                if (item.Id == choice)
                {
                    string nameOfCategory = item.Name;
                    AddNewQuestionMethod(nameOfCategory);
                }
            }
        }
        public void AddNewQuestionMethod(string nameOfCategory)
        {
            string path = $@"{nameOfCategory.ToLower()}.txt";
            StreamWriter sw = new StreamWriter(path, true);
            Console.WriteLine("Proszę, o podawanie prawidłowych pytań i odpowiedzi zgodnych z prawdą.");
            Console.WriteLine("Podaj pytanie.");
            string question = Console.ReadLine();
            sw.WriteLine(question);
            Console.WriteLine("\r\nTeraz będziesz podawać odpowiedzi. Proszę Cię, abyś zaczął od dużej litery A, B, C lub D." +
                "A następnie postawił kropkę, spację i treść odpowiedzi.");
            Console.WriteLine("\r\nNajpierw będę Cię prosić o podanie poprawnej odpowiedzi. Nie musisz podawać, że pierwsza" +
                "podana odpowiedź ma listerkę A, druga B itd. \r\nJak chcesz, aby poprawna odpowiedź była oznaczona " +
                "literką C to jak zapytam Cię o poprawną odpowiedź możesz np napisać: \r\n C. Treść Odpowiedzi\r\n" +
                "Błędne odpowiedzi: \r\n" +
                "A. Treść Odpowiedzi\r\n" +
                "D. Treść Odpowiedzi\r\n" +
                "B. Treść Odpowiedzi.\r\n" +
                "W wyświetleniu i tak ułożymy je zgodnie z alfabetem, a ty decydujesz jaką literkę ma prawidłowa odpowiedź" +
                "i błędne.");
            Console.Write("Podaj poprawną odpowiedź na twoje pytanie i oznacz je literką od A do D: ");
            string goodAnswer = Console.ReadLine();
            sw.WriteLine(goodAnswer);
            Console.Write("Podaj pierwszą błędną odpowiedź: ");
            string badAnswer = Console.ReadLine();
            sw.WriteLine(badAnswer);
            Console.Write("Podaj drugą błędną odpowiedź: ");
            string badAnswer1 = Console.ReadLine();
            sw.WriteLine(badAnswer1);
            Console.Write("Podaj ostatnią błędną odpowiedź: ");
            string badAnswer2 = Console.ReadLine();
            sw.WriteLine(badAnswer2);
            sw.WriteLine(" ");
            sw.Close();
        }
    }
}
