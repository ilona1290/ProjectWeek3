using QuizWeek3.Domain.Common;
using QuizWeek3.App.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizWeek3.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        public BaseService()
        {
            Items = new List<T>();
        }
        public void AddExistItems(T items)
        {
            Items.Add(items);
        }
        public List<T> GetAllItems()
        {
            return Items;
        }
        public int LastIdOnList()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public List<T> ShowItems()
        {
            foreach (var item in Items)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            return Items;
        }
        public void DeleteItem(int idOfItemToRemove)
        {
            foreach (var item in Items)
            {
                if (item.Id == idOfItemToRemove)
                {
                    Items.Remove(item);
                    break;
                }
            }
        }
    }
}
