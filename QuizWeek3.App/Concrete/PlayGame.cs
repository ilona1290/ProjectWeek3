using QuizWeek3.App.Managers;
using QuizWeek3.Domain.Entity;
using System;
using System.Collections.Generic;

namespace QuizWeek3.App.Concrete
{
    public class PlayGame : CategoryManager
    {
        public void StartGame()
        {
            while (true)
            {
                CreateAllCategoriesAndQuestion createAllCategoriesAndQuestion = new CreateAllCategoriesAndQuestion();
                var listofListsWithQuestionsFromEachCategory = createAllCategoriesAndQuestion.CreateListsToQuestionOfEachCategory();
                Items = new List<Category>();
                Console.WriteLine("Przed Tobą 12 pytań z różnych kategorii.\r\n");

                ShowAndDeleteQuestionAndAnswersService showandDeleteQuestionAndAnswersService = new ShowAndDeleteQuestionAndAnswersService();
                CheckUserAnswer checkUserAnswer = new CheckUserAnswer();
                int goodAnswers = 0;
                bool gameOver = false;
                OpenCategory();

                for (int i = 0; i < 12; i++)
                {
                    Console.WriteLine("Oto dostępne kategorie w QuizWeek3ie: ");
                    var listOfCategories = ShowItems();
                    Console.Write("Podaj numer kategorii, który wybierasz: ");
                    int chosenCategory;
                    Int32.TryParse(Console.ReadLine(), out chosenCategory);

                    if (chosenCategory > 0 && chosenCategory <= listOfCategories.Count)
                    {
                        // Przekazujemy listę z pytaniami z kategorii, którą wybrał użytkownik. Indeks takiej listy na liście 
                        // z listami pytań ze wszystkimi kategorii to numer kategorii (podany przez użytkownika) minus 1.
                        var helpObject = showandDeleteQuestionAndAnswersService.ShowQuestionAndAnswerOfCategory(listofListsWithQuestionsFromEachCategory[chosenCategory - 1]);
                        gameOver = checkUserAnswer.CheckUserAnswerMethod(helpObject.GoodAnswer);
                        showandDeleteQuestionAndAnswersService.DeleteShowedQuestion(listofListsWithQuestionsFromEachCategory[chosenCategory - 1], helpObject.Question);
                        if (gameOver == true)
                        {
                            Console.WriteLine($"\r\nDziękujemy za grę. Odpowiedziałeś/aś dobrze na {goodAnswers} z 12 pytań.");
                            break;
                        }
                        goodAnswers++;
                        // Jeśli nie ma już pytań z danej kategorii, usuwamy ją z wyświetlania.
                        if (listofListsWithQuestionsFromEachCategory[chosenCategory - 1].Count == 0)
                        {
                            foreach (var item in listOfCategories)
                            {
                                if (item.Id - 1 == listofListsWithQuestionsFromEachCategory.IndexOf(listofListsWithQuestionsFromEachCategory[chosenCategory - 1]))
                                {
                                    Console.WriteLine($"\r\nNie możesz już odpowiadać na pytania z kategorii: {item.Name}\r\n");
                                    DeleteCat(item.Id);
                                    listofListsWithQuestionsFromEachCategory[chosenCategory - 1].Add(new QuestionAndAnwers());
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podałeś zły numer kategorii. Wybierz poprawny");
                        i--;
                    }

                }
                if (goodAnswers == 12)
                {
                    Console.WriteLine("\r\nGratulacje!!! Odpowiedziałeś/aś na wszystkie pytania poprawnie.");
                }

                Console.Write("Chcesz zagrać jeszcze raz? Jeśli tak, wpisz 't', jeśli nie, wpisz 'n': ");
                char odp = Char.Parse(Console.ReadLine());
                if (odp == 't')
                {
                    Console.Clear();
                    continue;
                }
                else
                    break;
            }
        }
    }
}

