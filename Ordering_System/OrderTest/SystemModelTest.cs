using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System;
using Ordering_System.Model;

namespace OrderTest
{
    [TestClass]
    public class SystemModelTest
    {
        PrivateObject _target;
        SystemModel _model;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _model = new SystemModel();
            _target = new PrivateObject(_model);
        }
        void FackFunction(object sender, EventArgs e)
        {
        }
        [TestMethod()]
        public void EnableDeleteCategoryButtonTest()
        {
            _model._eventMealButtonClick += new EventHandler(FackFunction);
            _model.EnableDeleteCategoryButton();
        }
        [TestMethod()]
        public void UpdateMealListTest()
        {
            _model._eventMealListUpdate += new EventHandler(FackFunction);
            _model.UpdateMealList();
        }
        [TestMethod()]
        public void UpdateCategoryListTest()
        {
            _model._eventCategoryListUpdate += new EventHandler(FackFunction);
            _model.UpdateCategoryList();
        }
        [TestMethod()]
        public void GetMealControlTest()
        {
            MealControl mealControl = _model.GetMealControl();
        }
        [TestMethod()]
        public void GetOrderControlTest()
        {
            OrderControl orderControl = _model.GetOrderControl();
        }
        [TestMethod()]
        public void GetCategoryControlTest()
        {
            CategoryControl categoryControl = _model.GetCategoryControl();
        }
        [TestMethod()]
        public void GetPageControlTest()
        {
            PageControl pageControl = _model.GetPageControl();
        }
        [TestMethod()]
        public void InitializeMealListTest()
        {
            _model.InitializeMealList();
        }
        [TestMethod()]
        public void ChangeMealDetailTest()
        {
            _model.InitializeMealList();
            Meal meal =new Meal();
            meal.SetValue("可樂","25","","/image/Beverage Syrup Coca Cola_L_hero.png");
            Category category =new Category();
            category.Name="飲料";
            meal.SetCategory(category);
            _model.ChangeMealDetail("可口可樂", meal);
        }
        [TestMethod()]
        public void AddOrderTest()
        {
            _model.GetCategoryControl().InitializeCategoryList();
            _model.InitializeMealList();
            Meal meal = _model.GetMealControl().GetMealByTitle("可口可樂");
            _model.AddOrder(meal);
            _model.AddOrder(meal);
            Meal newMeal = new Meal();
            newMeal.SetValue("沙士", "25", "", "/image/Beverage Syrup Coca Cola_L_hero.png");
            Category category = new Category();
            category.Name = "飲料";
            newMeal.SetCategory(category);
            _model.AddOrder(newMeal);
        }
        [TestMethod()]
        public void RemoveCategoryTest()
        {
            _model.GetCategoryControl().InitializeCategoryList();
            _model.RemoveCategory("飲料");
        }
        [TestMethod()]
        public void GetMaxPageTest()
        {
            _model.GetCategoryControl().InitializeCategoryList();
            _model.InitializeMealList();
            int max = _model.GetMaxPage("主餐");
            Assert.AreEqual(2, max);
        }
        [TestMethod()]
        public void GoNextPageTest()
        {
            _model.GetCategoryControl().InitializeCategoryList();
            _model.InitializeMealList();
            _model.GoNextPage("主餐");
            Assert.AreEqual(2, _model.GetPageControl().Page);
        }
    }
}
