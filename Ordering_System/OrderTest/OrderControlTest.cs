using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System.Model;
using Ordering_System;
using System.Collections.Generic;

namespace OrderTest
{
    [TestClass]
    public class OrderControlTest
    {
        PrivateObject _target;
        OrderControl _orderControl;
        Order order;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _orderControl = new OrderControl();
            _target = new PrivateObject(_orderControl);
            order = new Order();
            Meal meal = new Meal();
            Category category = new Category();
            category.Name = "Drink";
            meal.SetValue("Cola", "25", "", "/image/");
            meal.SetCategory(category);
            order.SetValue(meal);
        }
        [TestMethod()]
        public void AddOrderTest()
        {
            _orderControl.AddOrder(order);
        }
        [TestMethod()]
        public void GetOrderListTest()
        {
            List<Order> orderList = _orderControl.GetOrderList();
        }
        [TestMethod()]
        public void UpdateOrderTest()
        {
            const int QUANTITY = 2;
            _orderControl.AddOrder(order);
            _orderControl.UpdateOrder(QUANTITY, "Soda");
            _orderControl.UpdateOrder(QUANTITY, "Cola");
        }
        [TestMethod()]
        public void RemoveOneMealOfListTest()
        {
            _orderControl.AddOrder(order);
            _orderControl.RemoveOneMealOfList("Soda");
            _orderControl.RemoveOneMealOfList("Cola");
        }
        [TestMethod()]
        public void CalculateTotalTest()
        {
            _orderControl.AddOrder(order);
            int total = _orderControl.CalculateTotal();
            Assert.AreEqual(25, total);
            _orderControl.UpdateOrder(4, "Cola");
            total = _orderControl.CalculateTotal();
            Assert.AreEqual(100, total);
        }
    }
}
