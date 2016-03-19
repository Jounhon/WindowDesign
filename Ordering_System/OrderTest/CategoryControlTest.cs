using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System.Model;
using Ordering_System;
using System.Collections.Generic;

namespace OrderTest
{
    [TestClass]
    public class CategoryControlTest
    {
        const string CATEGORY_NAME = "Food";
        PrivateObject _target;
        CategoryControl _categoryControl;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _categoryControl = new CategoryControl();
            _target = new PrivateObject(_categoryControl);
        }
        [TestMethod()]
        public void InitializeCategoryListTest()
        {
            _categoryControl.InitializeCategoryList();
        }
        [TestMethod()]
        public void SaveCategoryListToFileTest()
        {
            _categoryControl.InitializeCategoryList();
            _categoryControl.SaveCategoryListToFile();
        }
        [TestMethod()]
        public void AddCategoryTest()
        {
            bool success = _categoryControl.AddCategory(CATEGORY_NAME);
            Assert.IsTrue(success);
            success = _categoryControl.AddCategory(CATEGORY_NAME);
            Assert.IsFalse(success);
        }
        [TestMethod()]
        public void ChangeCategoryNameTest()
        {
            _categoryControl.AddCategory(CATEGORY_NAME);
            string newName = "Drink";
            _categoryControl.ChangeCategoryName(CATEGORY_NAME, newName);
        }
        [TestMethod()]
        public void GetCategoryListTest()
        {
            List<Category> categoryList = _categoryControl.GetCategoryList();
        }
        [TestMethod()]
        public void GetCategoryByNameTest()
        {
            Category category;
            category = _categoryControl.GetCategoryByName(CATEGORY_NAME);
            Assert.AreEqual(null, category);
            _categoryControl.AddCategory(CATEGORY_NAME);
            Category foodCategory = new Category();
            foodCategory.Name = "Food";
            category = _categoryControl.GetCategoryByName(CATEGORY_NAME);
            Assert.AreEqual(foodCategory.Name, category.Name);
        }
        [TestMethod()]
        public void RemoveCategoryTest()
        {
            _categoryControl.AddCategory(CATEGORY_NAME);
            Category category = new Category();
            category.Name = CATEGORY_NAME;
            _categoryControl.RemoveCategory(category);
        }
        
    }
}
