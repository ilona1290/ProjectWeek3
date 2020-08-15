using QuizWeek3.Domain.Common;

namespace QuizWeek3.Domain.Entity
{
    public class Menu : BaseEntity
    {
        public Menu(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
