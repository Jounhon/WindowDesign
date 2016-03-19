using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering_System.Model;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Ordering_System
{
    public class SystemModel
    {
        public event EventHandler _eventMealListUpdate;
        public event EventHandler _eventCategoryListUpdate;
        public event EventHandler _eventMealButtonClick;
        OrderControl _orderControl = new OrderControl();
        MealControl _mealControl = new MealControl();
        CategoryControl _categoryControl = new CategoryControl();
        PageControl _pageControl = new PageControl();
        const string MEAL_FILE_NAME = "/defaultMeal.txt";
        string _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));

        // set event to enable category button
        public void EnableDeleteCategoryButton()
        {
            if (_eventMealButtonClick != null)
                _eventMealButtonClick(_orderControl.GetOrderList(), new EventArgs());
        }

        // set event to update meal
        public void UpdateMealList()
        {
            if (_eventMealListUpdate != null)
                _eventMealListUpdate(_mealControl.GetMealList(), new EventArgs());
        }

        // set evnet to update category
        public void UpdateCategoryList()
        {
            if (_eventCategoryListUpdate != null)
                _eventCategoryListUpdate(_orderControl.GetOrderList(), new EventArgs());
        }

        // get meal control model
        public MealControl GetMealControl()
        {
            return _mealControl; 
        }

        // get order control model
        public OrderControl GetOrderControl()
        {
            return _orderControl;
        }

        // get category control model
        public CategoryControl GetCategoryControl()
        {
            return _categoryControl;
        }

        // get page control model
        public PageControl GetPageControl()
        {
            return _pageControl;
        }

        // load meal list
        public void InitializeMealList()
        {
            StreamReader file = new StreamReader(_projectPath + MEAL_FILE_NAME);
            string name;
            while ((name = file.ReadLine()) != null)
            {
                string price = file.ReadLine();
                string imagePath = file.ReadLine();
                string description = file.ReadLine();
                string categoryName = file.ReadLine();
                Category category = _categoryControl.GetCategoryByName(categoryName);
                Meal meal = new Meal();
                meal.SetValue(name, price, description, imagePath);
                meal.SetCategory(category);
                _mealControl.InitializeMealButton(meal);
            }
            file.Close();
        }

        // change meal detail
        public void ChangeMealDetail(string originalName, Meal meal)
        {
            foreach (Meal item in _mealControl.GetMealList())
            {
                if (item.Title.Equals(originalName))
                {
                    item.SetValue(meal.Title, meal.Price, meal.Description, meal.ImagePath);
                    item.SetCategory(_categoryControl.GetCategoryByName(meal.Category));
                    item.Text = item.ToString();
                    item.BackgroundImage = Image.FromFile(_projectPath + item.ImagePath);
                }
            }
        }

        // add order to order list
        public void AddOrder(Meal meal)
        {
            Boolean noItem = CheckOrder(meal);
            if (noItem)
            {
                Order data = new Order();
                data.SetValue(meal);
                _orderControl.AddOrder(data);
            }
        }

        // check order
        public Boolean CheckOrder(Meal meal)
        {
            foreach (Order item in _orderControl.GetOrderList())
            {
                if (item.GetMeal().Title.Equals(meal.Title))
                {
                    item.IncreaseQuantity();
                    return false;
                }
                else
                    continue;
            }
            return true;
        }

        // remove category by name
        public void RemoveCategory(string name)
        {
            //Category category = GetCategoryByName(CATEGORY_NAME);
            //RemoveMultipleOrder(name);
            _mealControl.RemoveMultipleMeals(name);
            foreach (Category item in _categoryControl.GetCategoryList())
            {
                if (item.Name.Equals(name))
                {
                    _categoryControl.RemoveCategory(item);
                    break;
                }
            }
        }

        // get max page
        public int GetMaxPage(string name)
        {
            const int MAX_BUTTONS = 9;
            int maxPage = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(_mealControl.GetMealOfCategory(name).Count) / MAX_BUTTONS));
            if (maxPage.Equals(0))
                maxPage = 1;
            return maxPage;
        }

        // go next page
        public void GoNextPage(string name)
        {
            if (_pageControl.Page + 1 <= GetMaxPage(name))
                _pageControl.Page++;
        }
    }
}
