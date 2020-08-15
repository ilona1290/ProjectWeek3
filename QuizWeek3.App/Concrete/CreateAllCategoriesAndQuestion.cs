using QuizWeek3.App.Common;
using QuizWeek3.App.Managers;
using QuizWeek3.Domain.Entity;
using System.Collections.Generic;
using System.IO;

namespace QuizWeek3.App.Concrete
{
    public class CreateAllCategoriesAndQuestion
    {
        public List<List<QuestionAndAnwers>> CreateListsToQuestionOfEachCategory()
        {
            // Lista z listami, gdzie pojedyncza lista to są obiekty (pytanie i odpowiedź) z pojedyńczej kategorii
            List<List<QuestionAndAnwers>> listofListsWithQuestionsFromEachCategory = new List<List<QuestionAndAnwers>>();
            CategoryManager categoryManager = new CategoryManager();
            categoryManager.OpenCategory();
            var listOfCategories = categoryManager.GetAllItems();
            List<QuestionAndAnwers> questionAndAnwersOfSingleCat = new List<QuestionAndAnwers>();
            var allQuestion = OpenQuestionFromEachCategory(questionAndAnwersOfSingleCat, listOfCategories, listofListsWithQuestionsFromEachCategory);
            return allQuestion;
        }
        public List<List<QuestionAndAnwers>> OpenQuestionFromEachCategory(List<QuestionAndAnwers> questionAndAnwersOfSingleCat, List<Category> categories, List<List<QuestionAndAnwers>> listofListsWithQuestionsFromEachCategory)
        {
            foreach (var item in categories)
            {
                string path = $"{item.Name.ToLower()}.txt";
                StreamReader sr = null;
                string lineOfText;
                int counterLine = 1;
                QuestionAndAnwers question = new QuestionAndAnwers();
                sr = File.OpenText(path);
                while ((lineOfText = sr.ReadLine()) != null)
                {
                    switch (counterLine)
                    {
                        case 1:
                            question.Question = lineOfText;
                            counterLine++;
                            break;
                        case 2:
                            question.GoodAnswer = lineOfText;
                            counterLine++;
                            break;
                        case 3:
                            question.BadAnswer = lineOfText;
                            counterLine++;
                            break;
                        case 4:
                            question.BadAnswer1 = lineOfText;
                            counterLine++;
                            break;
                        case 5:
                            question.BadAnswer2 = lineOfText;
                            counterLine++;
                            break;
                        default:
                            questionAndAnwersOfSingleCat.Add(question);
                            counterLine = 1;
                            question = new QuestionAndAnwers();
                            break;
                    }
                }
                listofListsWithQuestionsFromEachCategory.Add(questionAndAnwersOfSingleCat);
                questionAndAnwersOfSingleCat = new List<QuestionAndAnwers>();
                sr.Close();
            }
            return listofListsWithQuestionsFromEachCategory;
        }
    }
}