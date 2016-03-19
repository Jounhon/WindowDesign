using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering_System.Model
{
    public class OrderControl
    {
        private List<Order> _orderList = new List<Order>();

        // add order
        public void AddOrder(Order data)
        {
            _orderList.Add(data);
        }

        // get order list
        public List<Order> GetOrderList()
        {
            return _orderList;
        }

        // update order of one meal
        public void UpdateOrder(int quantity, string name)
        {
            foreach (Order item in _orderList)
            {
                if (item.GetMeal().Title.Equals(name))
                {
                    item.Quantity = quantity.ToString();
                    break;
                }
                else
                    continue;
            }
        }

        // remove order list of one meal
        public void RemoveOneMealOfList(string name)
        {
            foreach (Order Item in _orderList)
            {
                if (Item.GetMeal().Title.Equals(name))
                {
                    _orderList.Remove(Item);
                    break;
                }
                else
                    continue;
            }
        }

        // calculate order total price
        public int CalculateTotal()
        {
            int total = 0;
            foreach (Order item in _orderList)
                total += Convert.ToInt16(item.Total);
            return total;
        }

        // remove multiple order
        //public void RemoveMultipleOrder(string name)
        //{
        //    while (!CountOrderOfCategory(name).Equals(0))
        //    {
        //        foreach (Order item in _orderList)
        //        {
        //            if (item.GetMeal().Category.Equals(name))
        //            {
        //                _orderList.Remove(item);
        //                break;
        //            }
        //        }
        //    }
        //}

        // get count order of one category
        //public int CountOrderOfCategory(string name)
        //{
        //    int count = 0;
        //    foreach (Order item in _orderList)
        //    {
        //        if (item.GetMeal().Category.Equals(name))
        //            count++;
        //    }
        //    return count;
        //}
    }
}
