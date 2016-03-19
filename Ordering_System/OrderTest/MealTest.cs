using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System;
using Ordering_System.Model;
using System.Windows.Forms;

namespace OrderTest
{
    [TestClass]
    public class MealTest
    {
        const string INIT_CATEGORY = "飲料";
        const string INIT_NAME = "Cola";
        const string INIT_PRICE = "25";
        const string INIT_DESCRIPTION = "Good Drink";
        const string INIT_IMAGE = "/image/Beverage Syrup Coca Cola_L_hero.png";
        Category _category;
        PrivateObject _target;
        Meal _meal;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _category = new Category();
            _meal = new Meal();
            _target = new PrivateObject(_meal);
        }
        [TestMethod()]
        public void MealSetValueTest()
        {
            _meal.SetValue(INIT_NAME, INIT_PRICE, INIT_DESCRIPTION, INIT_IMAGE);
            Assert.AreEqual(INIT_NAME, _target.GetProperty("Title"));
            Assert.AreEqual(INIT_PRICE, _target.GetProperty("Price"));
            Assert.AreEqual(INIT_DESCRIPTION, _target.GetProperty("Description"));
            Assert.AreEqual(INIT_IMAGE, _target.GetProperty("ImagePath"));
        }
        [TestMethod()]
        public void MealSetCategoryTest()
        {
            _category.Name = INIT_CATEGORY; 
            _meal.SetCategory(_category);
            Assert.AreEqual(INIT_CATEGORY, _target.GetProperty("Category"));
        }
        [TestMethod()]
        public void MealPropertyTest()
        {
            _meal.Title = INIT_NAME;
            _meal.Price = INIT_PRICE;
            _meal.Description = INIT_DESCRIPTION;
            _meal.ImagePath = INIT_IMAGE;
            Assert.AreEqual(INIT_NAME, _target.GetProperty("Title"));
            Assert.AreEqual(INIT_PRICE, _target.GetProperty("Price"));
            Assert.AreEqual(INIT_DESCRIPTION, _target.GetProperty("Description"));
            Assert.AreEqual(INIT_IMAGE, _target.GetProperty("ImagePath"));
        }
    }
}
