using System;
using System.Collections.Generic;
using System.IO;
using QuizWeek3.App.Concrete;
using System.Text;
using QuizWeek3.Domain.Entity;

namespace QuizWeek3.App.Managers
{
    public class CategoryManager : CategoryService
    {

        public void OpenCategory()
        {
            string path = "categories.txt";
            StreamReader sr = File.OpenText(path);
            string valueCategory;
            int counterCategories = 1;
            while ((valueCategory = sr.ReadLine()) != null)
            {
                Category category = new Category(counterCategories, valueCategory);
                AddExistItems(category);
                counterCategories++;
            }
            sr.Close();
        }

        public void AddNewCategory()
        {
            Console.WriteLine("Oto kategorię aktualnie znajdujące się w bazie danych: ");
            Items.Clear();
            OpenCategory();
            ShowItems();
            Console.WriteLine("Podaj nazwę kategorii, którą chcesz dodać.");
            int lastId = LastIdOnList();
            string newCategory = Console.ReadLine();
            Category category = new Category(lastId++, newCategory); // Id nowego elementu o 1 większe niż Id poprzedniego elementu
            string stringToFileTxt = $"{category.Name}";
            string path = @"categories.txt";
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(stringToFileTxt);
            sw.Close();

            string newpath = @$"{stringToFileTxt.ToLower()}.txt";
            StreamWriter newSw = File.CreateText(newpath);
            newSw.Close();
            Console.WriteLine("Kategoria została dodana pomyślnie.\r\n");
        }
    }
}
