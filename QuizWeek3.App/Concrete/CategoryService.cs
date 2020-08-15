using QuizWeek3.App.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuizWeek3.App.Managers;
using QuizWeek3.Domain.Entity;

namespace QuizWeek3.App.Concrete
{
    public class CategoryService : BaseService<Category>
    {
        public void DeleteCat(int idCat)
        {
            DeleteItem(idCat);
        }
    }
}
