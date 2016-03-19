using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System;
using Ordering_System.Model;

namespace OrderTest
{
    [TestClass]
    public class PresentationBackFromTest
    {
        bool _isDeleteCategoryEnabled = false;
        bool _isSaveCategoryEnabled = false;
        bool _isSaveMealEnabled = false;
        bool _isCategoryTextBoxReadOnly = false;
        bool _isDeleteMealEnabled = false;
        PrivateObject _target;
        PresentationBackSideFormModel _presentationModel;
        SystemModel _systemModel;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _systemModel = new SystemModel();
            _presentationModel = new PresentationBackSideFormModel(_systemModel);
            _target = new PrivateObject(_presentationModel);
        }
        [TestMethod()]
        public void GetSystemModelTest()
        {
            SystemModel _model = _presentationModel.GetSystemModel();
            Assert.AreEqual(_systemModel, _model);
        }
        [TestMethod()]
        public void IsEmptyOfCategoryTextBoxTest()
        {
            Assert.AreEqual(_isSaveCategoryEnabled, _target.GetProperty("IsSaveCategoryEnabled"));
            _presentationModel.IsEmptyOfCategoryTextBox("");
            Assert.AreEqual(false, _target.GetProperty("IsSaveCategoryEnabled"));
            _presentationModel.IsEmptyOfCategoryTextBox("Drink");
            Assert.AreEqual(true, _target.GetProperty("IsSaveCategoryEnabled"));
        }
        [TestMethod()]
        public void IsEmptyOfMealGroupTextBoxTest()
        {
            bool empty = true;
            Assert.AreEqual(_isSaveMealEnabled, _target.GetProperty("IsSaveMealEnabled"));
            _presentationModel.IsEmptyOfMealGroupTextBox(empty);
            Assert.AreEqual(false, _target.GetProperty("IsSaveMealEnabled"));
            empty = false;
            _presentationModel.IsEmptyOfMealGroupTextBox(empty);
            Assert.AreEqual(true, _target.GetProperty("IsSaveMealEnabled"));
        }
        [TestMethod()]
        public void EnableCategoryTextBoxTest()
        {
            Assert.AreEqual(_isCategoryTextBoxReadOnly, _target.GetProperty("IsCategoryReadOnly"));
            _presentationModel.EnableCategoryTextBox();
            Assert.AreEqual(false, _target.GetProperty("IsCategoryReadOnly"));
        }
        [TestMethod()]
        public void EnableSaveCategoryButtonTest()
        {
            Assert.AreEqual(_isSaveCategoryEnabled, _target.GetProperty("IsSaveCategoryEnabled"));
            _presentationModel.EnableSaveCategoryButton();
            Assert.AreEqual(true, _target.GetProperty("IsSaveCategoryEnabled"));
        }
        [TestMethod()]
        public void DisableDeleteMealButtonTest()
        {
            Assert.AreEqual(_isDeleteMealEnabled, _target.GetProperty("IsDeleteMealEnabled"));
            _presentationModel.DisableDeleteMealButton();
            Assert.AreEqual(false, _target.GetProperty("IsDeleteMealEnabled"));
        }
        [TestMethod()]
        public void EnableDeleteMealButtonTest()
        {
            Assert.AreEqual(_isDeleteMealEnabled, _target.GetProperty("IsDeleteMealEnabled"));
            _presentationModel.EnableDeleteMealButton();
            Assert.AreEqual(true, _target.GetProperty("IsDeleteMealEnabled"));
        }
        [TestMethod()]
        public void IsEmptyMealOfCategoryTest()
        {
            Assert.AreEqual(_isDeleteCategoryEnabled, _target.GetProperty("IsDeleteCategoryEnabled"));
            _presentationModel.IsEmptyMealOfCategory("Cola");
            Assert.AreEqual(true, _target.GetProperty("IsDeleteCategoryEnabled"));
            _systemModel.GetCategoryControl().InitializeCategoryList();
            _systemModel.InitializeMealList();
            _presentationModel.IsEmptyMealOfCategory("主餐");
            Assert.AreEqual(false, _target.GetProperty("IsDeleteCategoryEnabled"));
        }
        [TestMethod()]
        public void CheckOrderIfHaveMealTest()
        {
            _presentationModel.CheckOrderIfHaveMeal("主餐");
            Assert.AreEqual(true, _target.GetProperty("IsDeleteCategoryEnabled"));
            _systemModel.GetCategoryControl().InitializeCategoryList();
            _systemModel.InitializeMealList();
            Meal meal = _systemModel.GetMealControl().GetMealByTitle("大麥克");
            Order order = new Order();
            order.SetValue(meal);
            _systemModel.GetOrderControl().AddOrder(order);
            _presentationModel.CheckOrderIfHaveMeal("主餐");
            Assert.AreEqual(false, _target.GetProperty("IsDeleteCategoryEnabled"));
        }
    }
}
