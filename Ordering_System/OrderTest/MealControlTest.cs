using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System.Model;
using Ordering_System;
using System.Collections.Generic;

namespace OrderTest
{
    [TestClass]
    public class MealControlTest
    {
        PrivateObject _target;
        MealControl _mealControl;
        SystemModel _systemControl;
        CategoryControl _categoryControl;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _systemControl = new SystemModel();
            _mealControl = _systemControl.GetMealControl();
            _categoryControl = _systemControl.GetCategoryControl();
            _categoryControl.InitializeCategoryList();
            _systemControl.InitializeMealList();
            _target = new PrivateObject(_mealControl);
        }
        [TestMethod()]
        public void SaveMealListToFileTest()
        {
            _mealControl.SaveMealListToFile();
        }
        [TestMethod()]
        public void InitializeMealButtonTest()
        {
            Category category = new Category();
            category.Name = "飲料";
            Meal meal = new Meal();
            meal.SetValue("香草奶昔", "25", "", "/image/Milkshake Vanilla_hero.png");
            meal.SetCategory(category);
            bool success = _mealControl.InitializeMealButton(meal);
            Assert.IsTrue(success);
            success = _mealControl.InitializeMealButton(meal);
            Assert.IsFalse(success);
        }
        [TestMethod()]
        public void GetMealListLengthTest()
        {
            int count = _mealControl.GetMealListLength();
            Assert.AreEqual(23, count);
        }
        [TestMethod()]
        public void GetMealByTitleTest()
        {
            string name = "雪碧";
            Meal meal = _mealControl.GetMealByTitle(name);
            Assert.AreEqual(name, meal.Title);
            string newName = "草莓奶昔";
            meal = _mealControl.GetMealByTitle(newName);
            Assert.AreEqual(null, meal);
        }
        [TestMethod()]
        public void GetMealListTest()
        {
            _mealControl.GetMealList();
        }
        [TestMethod()]
        public void RemoveMealTest()
        {
            string name = "可口可樂";
            _mealControl.RemoveMeal(name);
            Assert.AreEqual(22, _mealControl.GetMealListLength());
        }
        [TestMethod()]
        public void GetMealOfCategoryTest()
        {
            string name = "飲料";
            List<Meal> mealList = _mealControl.GetMealOfCategory(name);
            Assert.AreEqual(3, mealList.Count);
        }
        [TestMethod()]
        public void RemoveMultipleMealsTest()
        {
            string name = "飲料";
            _mealControl.RemoveMultipleMeals(name);
            Assert.AreEqual(20, _mealControl.GetMealListLength());
        }
        [TestMethod()]
        public void CountMealOfCategoryTest()
        {
            string name = "飲料";
            int count = _mealControl.CountMealOfCategory(name);
            Assert.AreEqual(3, count);
        }
    }
}
