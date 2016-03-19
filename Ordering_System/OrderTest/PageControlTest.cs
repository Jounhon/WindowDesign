using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System.Model;

namespace OrderTest
{
    [TestClass]
    public class PageControlTest
    {
        const int INIT_PAGE = 1;
        PrivateObject _target;
        PageControl _pageControl;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _pageControl = new PageControl();
            _target = new PrivateObject(_pageControl);
        }
        [TestMethod()]
        public void InitializePageTest()
        {
            Assert.AreEqual(INIT_PAGE, _target.GetProperty("Page"));
            _pageControl.InitializePage();
            Assert.AreEqual(INIT_PAGE, _target.GetProperty("Page"));
        }
        [TestMethod()]
        public void GoPreviousPageTest()
        {
            _pageControl.GoPreviousPage();
            Assert.AreEqual(INIT_PAGE, _target.GetProperty("Page"));
            _pageControl.Page = 3;
            _pageControl.GoPreviousPage();
            Assert.AreEqual(INIT_PAGE + 1, _target.GetProperty("Page"));
        }
    }
}
