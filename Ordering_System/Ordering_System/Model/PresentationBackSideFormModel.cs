using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering_System.Model;

namespace Ordering_System
{
    public class PresentationBackSideFormModel
    {
        bool _isDeleteCategoryEnabled = false;
        bool _isSaveCategoryEnabled = false;
        bool _isSaveMealEnabled = false;
        bool _isCategoryTextBoxReadOnly = false;
        bool _isDeleteMealEnabled = false;

        SystemModel _model;
        OrderControl _orderControl;
        MealControl _mealControl;
        public PresentationBackSideFormModel(SystemModel systemModel)
        {
            this._model = systemModel;
            this._orderControl = _model.GetOrderControl();
            this._mealControl = _model.GetMealControl();
        }

        // get system model
        public SystemModel GetSystemModel()
        {
            return _model;
        }

        // is category text box empty
        public void IsEmptyOfCategoryTextBox(string text)
        {
            if (text.Equals(""))
                _isSaveCategoryEnabled = false;
            else
                _isSaveCategoryEnabled = true;
        }

        // is meal group box 's text boxes empty
        public void IsEmptyOfMealGroupTextBox(bool empty)
        {
            if (empty)
                _isSaveMealEnabled = false;
            else
                _isSaveMealEnabled = true;
        }

        // is 未分類 or not
        //public void IsDefaultCategory(string name)
        //{
        //    const string CATEGORY_NAME = "未分類";
        //    if (name.Equals(CATEGORY_NAME))
        //    {
        //        _isDeleteCategoryEnabled = _isSaveCategoryEnabled = false;
        //        _isCategoryTextBoxReadOnly = true;
        //    }
        //    else
        //    {
        //        _isDeleteCategoryEnabled = _isSaveCategoryEnabled = true;
        //        _isCategoryTextBoxReadOnly = false;
        //    }
        //    IsEmptyMealOfCategory(name);
        //}

        // check if order have meal in the category --
        public void CheckOrderIfHaveMeal(string name)
        {
            _isDeleteCategoryEnabled = true;
            foreach (Order item in _orderControl.GetOrderList())
            {
                if (item.GetMeal().Category.Equals(name))
                    _isDeleteCategoryEnabled = false;
            }
        }

        // check is empty Category --
        public void IsEmptyMealOfCategory(string name)
        {
            if (_mealControl.CountMealOfCategory(name) > 0)
                _isDeleteCategoryEnabled = false;
            else
                _isDeleteCategoryEnabled = true;
        }

        // enable categoty text box
        public void EnableCategoryTextBox()
        {
            _isCategoryTextBoxReadOnly = false;
        }

        // enable save category button
        public void EnableSaveCategoryButton()
        {
            _isSaveCategoryEnabled = true;
        }

        // disable delete meal button
        public void DisableDeleteMealButton()
        {
            _isDeleteMealEnabled = false;
        }

        // enable delete meal button
        public void EnableDeleteMealButton()
        {
            _isDeleteMealEnabled = true;
        }

        // save meal button enabled
        public bool IsSaveMealEnabled
        {
            get
            {
                return _isSaveMealEnabled;
            }
        }

        // meal delete button enabled
        public bool IsDeleteMealEnabled
        {
            get
            {
                return _isDeleteMealEnabled;
            }
        }

        // category delete button enabled
        public bool IsDeleteCategoryEnabled
        {
            get
            {
                return _isDeleteCategoryEnabled;
            }
        }

        // category save button enabled
        public bool IsSaveCategoryEnabled
        {
            get
            {
                return _isSaveCategoryEnabled;
            }
        }

        // category name textbox readonly
        public bool IsCategoryReadOnly
        {
            get
            {
                return _isCategoryTextBoxReadOnly;
            }
        }
    }
}
