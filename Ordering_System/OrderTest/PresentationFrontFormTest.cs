using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System;
using Ordering_System.Model;

namespace OrderTest
{
    [TestClass]
    public class PresentationFrontFormTest
    {
        bool _isPreviousButtonVisible = true;
        bool _isNextButtonVisible = true;
        bool _isRecordDataGridViewReadOnly = false;
        bool _isTextBoxColumnReadOnly = true;
        bool _isNumericUpDownColumnReadOnly = false;
        PrivateObject _target;
        PresentationFrontSideFormModel _presentationModel;
        SystemModel _systemModel;
        PageControl _pageControl;
        MealControl _mealControl;
        CategoryControl _categoryControl;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _systemModel = new SystemModel();
            _presentationModel = new PresentationFrontSideFormModel(_systemModel);
            _pageControl = _systemModel.GetPageControl();
            _mealControl = _systemModel.GetMealControl();
            _categoryControl = _systemModel.GetCategoryControl();
            _target = new PrivateObject(_presentationModel);
        }
        [TestMethod()]
        public void GetSystemModelTest()
        {
            SystemModel _model = _presentationModel.GetSystemModel();
            Assert.AreEqual(_systemModel, _model);
        }
        [TestMethod()]
        public void CheckPreviousButtonTest()
        {
            Assert.AreEqual(_isPreviousButtonVisible, _target.GetProperty("IsPreviousButtonVisible"));
            _presentationModel.CheckPreviousButton();
            Assert.AreEqual(false, _target.GetProperty("IsPreviousButtonVisible"));
            _pageControl.Page = 2;
            _presentationModel.CheckPreviousButton();
            Assert.AreEqual(true, _target.GetProperty("IsPreviousButtonVisible"));
        }
        [TestMethod()]
        public void CheckNextButtonTest()
        {
            Category category = new Category();
            category.Name = "主餐";
            Assert.AreEqual(_isNextButtonVisible, _target.GetProperty("IsNextButtonVisible"));
            _presentationModel.CheckNextButton(category.Name);
            Assert.AreEqual(false, _target.GetProperty("IsNextButtonVisible"));
            _categoryControl.InitializeCategoryList();
            _systemModel.InitializeMealList();
            _presentationModel.CheckNextButton(category.Name);
            Assert.AreEqual(true, _target.GetProperty("IsNextButtonVisible"));
        }
        [TestMethod()]
        public void IsNumericUpDownColumnReadOnlyTest()
        {
            Assert.AreEqual(_isNumericUpDownColumnReadOnly, _target.GetProperty("IsNumericUpDownColumnReadOnly"));
        }
        [TestMethod()]
        public void IsTextBoxColumnReadOnlyTest()
        {
            Assert.AreEqual(_isTextBoxColumnReadOnly, _target.GetProperty("IsTextBoxColumnReadOnly"));
        }
        [TestMethod()]
        public void IsRecordDataGridViewReadOnlyTest()
        {
            Assert.AreEqual(_isRecordDataGridViewReadOnly, _target.GetProperty("IsRecordDataGridViewReadOnly"));
        }
    }
}
