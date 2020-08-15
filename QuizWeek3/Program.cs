using QuizWeek3.App.Concrete;
using QuizWeek3.App.Managers;
using System;

namespace QuizWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Witaj w grze w QuizWeek3y. Wybierz opcję:");
                MenuActionService menuAction = new MenuActionService();
                menuAction.ShowMenu();
                int choice;
                Int32.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    PlayGame playGame = new PlayGame();
                    playGame.StartGame();
                }
                else if (choice == 2)
                {
                    CategoryManager categoryManager = new CategoryManager();
                    categoryManager.OpenCategory();
                    categoryManager.AddNewCategory();
                    Console.WriteLine("Kliknij Enter, aby przejść z powrotem do menu głównego.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (choice == 3)
                {
                    QuestionManager questionManager = new QuestionManager();
                    questionManager.CheckCategoryToAddQuestion();
                    Console.WriteLine("\r\nPytanie i odpowiedzi zostały pomyślnie dodane.");
                    Console.WriteLine("\r\nNaciśnij Enter, aby przejść do menu głównego.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Do zobaczenia!");
                    break;
                }
            }
        }
    }
}
