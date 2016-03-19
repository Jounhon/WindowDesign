using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_System.Model
{
    public class Meal : Button
    {
        private string _name;
        private string _price;
        private string _description;
        private string _imagePath;
        private Category _category;

        public string Title
        {
            get 
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        public string Category
        {
            get
            {
                return _category.Name;
            }
        }

        //output name and price
        public override string ToString()
        {
            const string WRAP = "\n";
            const string DOLLAR_SIGN = " NTD.";
            string buttonText = _name + WRAP + _price + DOLLAR_SIGN;
            return buttonText;
        }

        // set value
        public void SetValue(string name, string price, string description, string imagePath)
        {
            _name = name;
            _price = price;
            _description = description;
            _imagePath = imagePath;
        }

        // change category
        public void SetCategory(Category category)
        {
            _category = category;
        }
    }
}
