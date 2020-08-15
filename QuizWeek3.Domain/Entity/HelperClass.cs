using QuizWeek3.Domain.Common;

namespace QuizWeek3.Domain.Entity
{
    public class HelperClass
    {
        public string GoodAnswer { get; set; }
        public string Question { get; set; }

        public HelperClass(string goodAnswer, string question)
        {
            GoodAnswer = goodAnswer;
            Question = question;
        }
    }
}
