using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System;

namespace OrderTest
{
    [TestClass]
    public class CategoryTest
    {
        const string INIT_CATEGORY = "主餐";
        PrivateObject _target;
        Category _category;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _category = new Category();
            _category.Name = INIT_CATEGORY;
            _target = new PrivateObject(_category);
        }
        [TestMethod()]
        public void CategoryPropertyTest()
        {
            Assert.AreEqual(INIT_CATEGORY,_target.GetProperty("Name"));
        }
    }
}
