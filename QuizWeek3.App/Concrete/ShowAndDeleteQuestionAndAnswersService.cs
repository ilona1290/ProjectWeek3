using QuizWeek3.Domain.Entity;
using System;
using System.Collections.Generic;

namespace QuizWeek3.App.Concrete
{
    public class ShowAndDeleteQuestionAndAnswersService
    {
        public HelperClass ShowQuestionAndAnswerOfCategory(List<QuestionAndAnwers> questionAndAnwersofCat)
        {
            Random rnd = new Random();
            var Idquestion = rnd.Next(0, questionAndAnwersofCat.Count); // losujemy id od 0 do ostaniego elementu listy z 
            // pytaniami. Kraniec końcowy nie jest brany pod uwagę w metodzie Next obiektu klasy Random. Dlatego id ostatniego
            // pytania to liczba ostatnio brana pod uwagę w metodzie Next().
            string goodAnswer = "";
            string question = "";
            HelperClass helper;
            for (int i = 0; i < questionAndAnwersofCat.Count; i++)
            {
                if (i == Idquestion)
                {
                    goodAnswer = questionAndAnwersofCat[i].GoodAnswer;
                    question = questionAndAnwersofCat[i].Question;
                    List<string> answers = new List<string>();
                    answers.AddRange(new List<string>() { questionAndAnwersofCat[i].GoodAnswer,
                            questionAndAnwersofCat[i].BadAnswer, questionAndAnwersofCat[i].BadAnswer1,
                            questionAndAnwersofCat[i].BadAnswer2 });
                    answers.Sort();
                    Console.WriteLine($"\r\n{questionAndAnwersofCat[i].Question}");
                    foreach (var answer in answers)
                    {
                        Console.WriteLine(answer);
                    }
                }
                else
                    continue;
            }
            helper = new HelperClass(goodAnswer, question);
            return helper;
        }
        public void DeleteShowedQuestion(List<QuestionAndAnwers> questionAndAnwersofCat, string question)
        {
            for (int i = 0; i < questionAndAnwersofCat.Count; i++)
            {
                QuestionAndAnwers item = questionAndAnwersofCat[i];
                if (item.Question == question)
                {
                    questionAndAnwersofCat.Remove(item);
                    break;
                }
            }
        }
    }
}
