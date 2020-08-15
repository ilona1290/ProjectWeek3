using QuizWeek3.Domain.Common;

namespace QuizWeek3.Domain.Entity
{
    public class QuestionAndAnwers
    {
        public int IdQuestion { get; set; }
        public string GoodAnswer { get; set; }
        public string Question { get; set; }
        public string BadAnswer { get; set; }
        public string BadAnswer1 { get; set; }
        public string BadAnswer2 { get; set; }
    }
}
