using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System;
using Ordering_System.Model;
using System.Windows.Forms;

namespace OrderTest
{
    [TestClass]
    public class OrderTest
    {
        const string INIT_CATEGORY = "飲料";
        const string INIT_NAME = "Cola";
        const string INIT_PRICE = "25";
        const string INIT_DESCRIPTION = "Good Drink";
        const string INIT_IMAGE = "/image/Beverage Syrup Coca Cola_L_hero.png";
        const int INIT_QUANTITY = 1;
        Meal _meal;
        PrivateObject _target;
        Order _order;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _meal = new Meal();
            _meal.SetValue(INIT_NAME, INIT_PRICE, INIT_DESCRIPTION, INIT_IMAGE);
            _order = new Order();
            _order.SetValue(_meal);
            _target = new PrivateObject(_order);
        }
        [TestMethod()]
        public void OrderSetValueTest()
        {
            int total = Convert.ToInt16(INIT_PRICE) * INIT_QUANTITY;
            Assert.AreEqual(INIT_QUANTITY.ToString(), _target.GetProperty("Quantity"));
            Assert.AreEqual(total.ToString(), _target.GetProperty("Total"));
            Assert.AreEqual(INIT_NAME, _target.GetProperty("Name"));
        }
        [TestMethod()]
        public void OrderPropertyTest()
        {
            const int NEW_QUANTITY = 2;
            _order.Quantity = NEW_QUANTITY.ToString();
            int total = (Convert.ToInt16(INIT_PRICE)) * NEW_QUANTITY;
            Assert.AreEqual(NEW_QUANTITY.ToString(), _target.GetProperty("Quantity"));
            Assert.AreEqual(total.ToString(), _target.GetProperty("Total"));
        }
        [TestMethod()]
        public void OrderGetMealTest()
        {
            Meal meal = _order.GetMeal();
            Assert.AreEqual(_meal, meal);
        }
        [TestMethod()]
        public void OrderIncreaseQuantityTest()
        {
            const int NEW_QUANTITY = 2;
            _order.IncreaseQuantity();
            Assert.AreEqual(NEW_QUANTITY.ToString(), _target.GetProperty("Quantity"));
        }
        [TestMethod()]
        public void OrderSetTotalTest()
        {
            const string TOTAL = "25";
            _order.Total = TOTAL;
            Assert.AreEqual(TOTAL.ToString(), _target.GetProperty("Total"));
        }
    }
}
