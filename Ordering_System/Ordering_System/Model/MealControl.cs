using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Ordering_System.Model
{
    public class MealControl
    {
        const string MEAL_FILE_NAME = "/defaultMeal.txt";
        string _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        private List<Meal> _mealList = new List<Meal>();

        // save meal list to file
        public void SaveMealListToFile()
        {
            StreamWriter file = new StreamWriter(_projectPath + MEAL_FILE_NAME);
            List<Meal> list = GetMealList();
            for (int index = 0; index < list.Count; index++)
            {
                file.WriteLine(list[index].Title);
                file.WriteLine(list[index].Price);
                file.WriteLine(list[index].ImagePath);
                file.WriteLine(list[index].Description);
                file.WriteLine(list[index].Category);
            }
            file.Close();
        }

        // add and init meal button
        public bool InitializeMealButton(Meal data)
        {
            foreach (Meal item in _mealList)
            {
                if (item.Title.Equals(data.Title))
                    return false;
            }
            const int SIZE = 11;
            data.Text = data.ToString();
            data.Name = data.Title;
            data.TextAlign = ContentAlignment.TopRight;
            data.Font = new Font(data.Font.FontFamily, SIZE, data.Font.Style | FontStyle.Bold);
            data.Dock = DockStyle.Fill;
            data.BackgroundImage = Image.FromFile(_projectPath + data.ImagePath);
            data.BackgroundImageLayout = ImageLayout.Stretch;
            _mealList.Add(data);
            return true;
        }

        // get length of meal list
        public int GetMealListLength()
        {
            return _mealList.Count;
        }

        // get meal by title
        public Meal GetMealByTitle(string title)
        {
            for (int index = 0; index < _mealList.Count; index++)
            {
                if (_mealList[index].Title.Equals(title))
                    return _mealList[index];
            }
            return null;
        }

        //get meal list
        public List<Meal> GetMealList()
        {
            return _mealList;
        }

        // remove meal
        public void RemoveMeal(string name)
        {
            foreach (Meal item in _mealList)
            {
                if (item.Title.Equals(name))
                {
                    _mealList.Remove(item);
                    break;
                }
            }
            //foreach (Order item in _orderList)
            //{
            //    if (item.Name.Equals(name))
            //    {
            //        _orderList.Remove(item);
            //        break;
            //    }
            //}
        }

        // get the meal of same category 
        public List<Meal> GetMealOfCategory(string name)
        {
            List<Meal> list = new List<Meal>();
            foreach (Meal item in _mealList)
            {
                if (item.Category.Equals(name))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        //remove multiple meals
        public void RemoveMultipleMeals(string name)
        {
            while (!CountMealOfCategory(name).Equals(0))
            {
                foreach (Meal item in _mealList)
                {
                    if (item.Category.Equals(name))
                    {
                        _mealList.Remove(item);
                        break;
                    }
                }
            }
        }

        // get count meal of one category
        public int CountMealOfCategory(string name)
        {
            int count = 0;
            foreach (Meal item in _mealList)
            {
                if (item.Category.Equals(name))
                    count++;
            }
            return count;
        }
    }
}
