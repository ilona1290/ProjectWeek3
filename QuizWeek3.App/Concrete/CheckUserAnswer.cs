using System;

namespace QuizWeek3.App.Concrete
{
    public class CheckUserAnswer
    {
        public bool CheckUserAnswerMethod(string goodAnswer)
        {
            char choice = Char.Parse(Console.ReadLine().ToUpper());
            var correctAnswer = goodAnswer[0];
            var result = choice == correctAnswer ? true : false;
            bool gameOver = false;
            if (result)
            {
                Console.WriteLine("Gratulacje, to prawidłowa odpowiedź.\r\n");
            }
            else
            {
                Console.WriteLine("Niestety to nieprawidłowa odpowiedź. Przegrywasz.");
                gameOver = true;
            }
            return gameOver;
        }
    }
}
