using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ordering_System.Model;

namespace Ordering_System.Model
{
    public class Order
    {
        private Meal _meal;
        private int _quantity;
        private int _total;

        public string Name
        {
            get
            {
                return _meal.Title;
            }
        }

        public string Quantity
        {
            get
            {
                return _quantity.ToString();
            }
            set
            {
                _quantity = Convert.ToInt16(value);
            }
        }

        public string Total
        {
            get
            {
                return (Convert.ToInt16(_meal.Price) * _quantity).ToString();
            }
            set
            {
                _total = Convert.ToInt16(value);
            }
        }
        // set value
        public void SetValue(Meal meal)
        {
            _meal = meal;
            _quantity = 1;
        }

        // increase quantity and calculate total
        public void IncreaseQuantity()
        {
            _quantity++;
        }

        // get meal
        public Meal GetMeal()
        {
            return _meal;
        }
    }
}
