using QuizWeek3.Domain.Common;

namespace QuizWeek3.Domain.Entity
{
    public class Category : BaseEntity
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
