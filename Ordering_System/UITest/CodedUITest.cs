using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.IO;
using System.Threading.Tasks;


namespace UITest
{
    /// <summary>
    /// CodedUITest1 的摘要描述
    /// </summary>
    [CodedUITest]
    public class OrderUITest
    {
        String _projectPath;
        String _startFormName;
        String _customFormName;
        String _restaurantDFormName;
        String _totalLebleName;
        String _recordDGVName;
        String _pageLebleName;
        public OrderUITest()
        {
            //_projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())).Replace("TestResults", "");
            //_projectPath += "\\Ordering_System\\bin\\Debug\\Ordering_System.exe";
            _projectPath = @"Ordering_System.exe";
            _startFormName = "StartUpForm";
            _customFormName = "POSCustomerSideForm";
            _restaurantDFormName = "POSRestaurantSideForm";
            _recordDGVName = "_recordDataGridView";
            _totalLebleName = "_totalLabel";
            _pageLebleName = "_pageLabel";
        }
        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(_projectPath, _startFormName);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        /// <summary>
        /// Runs the script: 
        /// click customer button 
        /// -> click restaurant button 
        /// -> close restaurant form
        /// -> close customer form
        /// -> close start form
        /// </summary>
        private void RunScriptStartForm()
        {
            Robot.ClickOtherFormButton(_startFormName, "Customer ( frontend )");
            Robot.AssertWindow(_customFormName);
            Robot.AssertButtonEnable("Customer ( frontend )", false);

            Robot.ClickOtherFormButton(_startFormName, "Restaurant ( backend )");
            Robot.AssertButtonEnable("Restaurant ( backend )", false);
            Robot.AssertWindow(_restaurantDFormName);

            Robot.CloseWindow(_restaurantDFormName);
            Robot.AssertButtonEnable("Restaurant ( backend )", true);
            //Robot.AssertWindowExist(_restaurantDFormName, false);

            Robot.CloseWindow(_customFormName);
            Robot.AssertButtonEnable("Customer ( frontend )", true);
            //Robot.AssertWindowExist(_customFormName, false);

            Robot.ClickOtherFormButton(_startFormName, "Exit");
        }

        /// <summary>
        /// Runs the script: test for customer side form
        /// </summary>
        private void RunScriptCustomerSide()
        {
            //click customer side button
            Robot.ClickOtherFormButton(_startFormName, "Customer ( frontend )");
            Robot.FindWindow(_customFormName);
            //click next & privious button
            Robot.AssertText(_pageLebleName, "Page : 1 / 2");
            Robot.ClickButton(">");
            Robot.AssertText(_pageLebleName, "Page : 2 / 2");
            Robot.ClickButton("<");
            Robot.AssertText(_pageLebleName, "Page : 1 / 2");
            //click tab page
            Robot.ClickTabControl("飲料");
            Robot.ClickTabControl("甜點");
            Robot.ClickTabControl("主餐");
        }
        private void RunScriptOrderMeal()
        {
            //test for order
            Robot.AssertText(_totalLebleName, "Total : 0 NTD.");
            Robot.ClickOtherFormButton(_customFormName, "大麥克\n999 NTD.");
            Robot.AssertEdit("_descriptionTextBox", "材料:牛肉餅、生菜、大麥克麵包、吉事、大麥克醬、脫水洋蔥、酸黃瓜");
            Robot.AssertDataGridViewByIndex(_recordDGVName, "1", new string[] { "大麥克", "主餐", "999", "1", "999", "x" });
            Robot.AssertText(_totalLebleName, "Total : 999 NTD.");
            Robot.ClickOtherFormButton(_customFormName, "大麥克\n999 NTD.");
            Robot.AssertDataGridViewByIndex(_recordDGVName, "1", new string[] { "大麥克", "主餐", "999", "2", "1998", "x" });
            Robot.AssertText(_totalLebleName, "Total : 1998 NTD.");
            Robot.ClickButton(">");
            Robot.ClickOtherFormButton(_customFormName, "麥克鷄塊(6塊)\n113 NTD.");
            Robot.AssertDataGridViewByIndex(_recordDGVName, "2", new string[] { "麥克鷄塊(6塊)", "主餐", "113", "1", "113", "x" });
            Robot.AssertText(_totalLebleName, "Total : 2111 NTD.");
            Robot.ClickTabControl("甜點");
            Robot.ClickOtherFormButton(_customFormName, "大薯\n39 NTD.");
            Robot.AssertDataGridViewByIndex(_recordDGVName, "3", new string[] { "大薯", "甜點", "39", "1", "39", "x" });
            Robot.AssertText(_totalLebleName, "Total : 2150 NTD.");
            Robot.ClickTabControl("飲料");
            Robot.ClickOtherFormButton(_customFormName, "雪碧\n25 NTD.");
            Robot.AssertDataGridViewByIndex(_recordDGVName, "4", new string[] { "雪碧", "飲料", "25", "1", "25", "x" });
            Robot.AssertText(_totalLebleName, "Total : 2175 NTD.");
            Robot.ClickNumericUpDownButtonInDataGridView(_recordDGVName, 3, 3, Robot.NumericDirect.UP, 2);
            Robot.AssertDataGridViewNumericUpDownCellValue(_recordDGVName, 3, 3, 3);
            Robot.AssertText(_totalLebleName, "Total : 2225 NTD.");
            Robot.AssertDataItemsInDataGridView(_recordDGVName, 4);
            Robot.ClickButtonInDataGridView(_recordDGVName, 3, 5);
            Robot.AssertText(_totalLebleName, "Total : 2150 NTD.");
            Robot.ClickButtonInDataGridView(_recordDGVName, 1, 5);
            Robot.ClickButtonInDataGridView(_recordDGVName, 1, 5);
            Robot.ClickNumericUpDownButtonInDataGridView(_recordDGVName, 0, 3, Robot.NumericDirect.DOWN, 2);
            Robot.AssertDataGridViewNumericUpDownCellValue(_recordDGVName, 0, 3, 1);
            Robot.ClickButtonInDataGridView(_recordDGVName, 0, 5);
            Robot.AssertText(_totalLebleName, "Total : 0 NTD.");
            Robot.ClickOtherFormButton(_startFormName, "Exit");
        }

        /// <summary>
        /// Runs the script: test for restaurant side form
        /// </summary>  
        private void RunScriptRestaurantSide()
        {
            //click restaurant side button
            Robot.ClickButton("Restaurant ( backend )");
            Robot.FindWindow(_restaurantDFormName);

            //meal manager button status
            Robot.AssertButtonEnable("Add New Meal", true);
            Robot.AssertButtonEnable("_saveMealButton", false);
            Robot.AssertButtonEnable("Delete Selected Meal", false);

            //meal manager list
            Robot.AssertListViewByValue(_restaurantDFormName, new string[] { "大麥克", "雙層牛肉吉事堡", "四盎司牛肉堡餐", "雙層四盎司牛肉堡餐", "1955 美式培根牛肉堡", "麥克雙牛堡", "漢堡5", "吉事漢堡", "麥香鷄堡", "勁辣鷄腿堡", "板烤鷄腿堡", "麥脆鷄原味", "麥脆鷄辣味", "麥克鷄塊(4塊)", "麥克鷄塊(6塊)", "大薯", "中薯", "小薯", "冰炫風-焦糖脆片", "冰炫風-OREO", "可口可樂", "雪碧", "檸檬紅茶" });
            //click tab page
            Robot.ClickTabControl("Category Manager");

            //category manager button status
            Robot.AssertButtonEnable("Add Category", true);
            Robot.AssertButtonEnable("_saveCategoryButton", false);
            Robot.AssertButtonEnable("Delete Selected Category", false);

            //click tab page
            Robot.ClickTabControl("Meal Manager");
        }
        private void RunScriptMealEdit()
        {
            // click customer side form
            Robot.ClickOtherFormButton(_startFormName, "Customer ( frontend )");
            Robot.FindWindow(_customFormName);
            Robot.ClickButton("漢堡5\n105 NTD.");

            // click list item
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickListViewByValue(_restaurantDFormName, "漢堡5");

            //meal manager button status
            Robot.AssertButtonEnable("Add New Meal", true);
            Robot.AssertButtonEnable("_saveMealButton", true);
            Robot.AssertButtonEnable("Delete Selected Meal", true);

            //check item detail
            Robot.AssertEdit("_mealNameTextBox", "漢堡5");
            Robot.AssertEdit("_priceTextBox", "105");
            Robot.AssertEdit("_descriptionTextBox", "材料:芥末醬、番茄醬、漢堡麵包、牛肉餅、脫水洋蔥、酸黃瓜");
            Robot.AssertEdit("_pathTextBox", "/image/Hamburger_hero.png");

            //set word
            Robot.SetEdit("_mealNameTextBox", "漢堡");
            Robot.SetEdit("_priceTextBox", "99");
            Robot.ClickButton("_saveMealButton");
            Robot.AssertListViewByValue(_restaurantDFormName, new string[] { "大麥克", "雙層牛肉吉事堡", "四盎司牛肉堡餐", "雙層四盎司牛肉堡餐", "1955 美式培根牛肉堡", "麥克雙牛堡", "漢堡", "吉事漢堡", "麥香鷄堡", "勁辣鷄腿堡", "板烤鷄腿堡", "麥脆鷄原味", "麥脆鷄辣味", "麥克鷄塊(4塊)", "麥克鷄塊(6塊)", "大薯", "中薯", "小薯", "冰炫風-焦糖脆片", "冰炫風-OREO", "可口可樂", "雪碧", "檸檬紅茶" });
            Robot.FindWindow(_customFormName);
            Robot.AssertDataGridViewByIndex(_recordDGVName, "1", new string[] { "漢堡", "主餐", "99", "1", "99", "x" });
            Robot.ClickButtonInDataGridView(_recordDGVName, 0, 5);
        }
        private void RunScriptMealDelete()
        {
            Robot.FindWindow(_customFormName);
            Robot.ClickTabControl("飲料");
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickListViewByValue(_restaurantDFormName, "檸檬紅茶");
            Robot.ClickButton("Delete Selected Meal");
            Robot.AssertListViewByValue(_restaurantDFormName, new string[] { "大麥克", "雙層牛肉吉事堡", "四盎司牛肉堡餐", "雙層四盎司牛肉堡餐", "1955 美式培根牛肉堡", "麥克雙牛堡", "漢堡", "吉事漢堡", "麥香鷄堡", "勁辣鷄腿堡", "板烤鷄腿堡", "麥脆鷄原味", "麥脆鷄辣味", "麥克鷄塊(4塊)", "麥克鷄塊(6塊)", "大薯", "中薯", "小薯", "冰炫風-焦糖脆片", "冰炫風-OREO", "可口可樂", "雪碧", "檸檬紅茶" });
            Robot.FindWindow(_customFormName);
            Robot.ClickTabControl("飲料");
        }
        private void RunScriptMealAdd()
        {
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickListViewByValue(_restaurantDFormName, "大麥克");
            Robot.ClickButton("Add New Meal");
            Robot.SetEdit("_mealNameTextBox", "檸檬紅茶");
            Robot.SetEdit("_priceTextBox", "25");
            Robot.ClickButton("Browse...");
            Robot.FindWindow("開啟");
            Robot.KeyText("Nestle Lemon Tea_L_hero.png");
            Robot.ClickButton("開啟(O)");
            Robot.FindWindow(_restaurantDFormName);
            Robot.SetComboBox("_categoryComboBox", "飲料");
            Robot.ClickButton("_saveMealButton");
            Robot.FindWindow(_customFormName);
            Robot.ClickTabControl("飲料");
        }

        private void RunScriptCategoryEdit()
        {
            // click customer side tab page
            Robot.FindWindow(_customFormName);
            Robot.ClickTabControl("飲料");
            Robot.ClickButton("可口可樂\n25 NTD.");

            //click tab page
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickTabControl("Category Manager");

            //click list item
            Robot.ClickListViewByValue(_restaurantDFormName, "飲料");

            //change category name
            Robot.SetEdit("_categoryNameTextBox","Drink");
            Robot.ClickButton("_saveCategoryButton");

            Robot.FindWindow(_customFormName);
            Robot.AssertDataGridViewByIndex(_recordDGVName, "1", new string[] { "可口可樂", "Drink", "25", "1", "25", "x" });
            Robot.ClickTabControl("Drink");
        }

        private void RunScriptCategoryDelete()
        {
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickListViewByValue(_restaurantDFormName, "Drink");
            Robot.AssertButtonEnable("Delete Selected Category", false);

            Robot.FindWindow(_customFormName);
            Robot.ClickButtonInDataGridView(_recordDGVName, 0, 5);
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickListViewByValue(_restaurantDFormName, "Drink");
            Robot.AssertButtonEnable("Delete Selected Category", true);

            Robot.ClickButton("Delete Selected Category");
            Robot.AssertListViewByValue(_restaurantDFormName, new string[] { "主餐", "甜點" });
            Robot.FindWindow(_customFormName);
            Robot.ClickTabControl("主餐");
        }

        private void RunScriptCategoryAdd()
        {
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickButton("Add Category");

            Robot.SetEdit("_categoryNameTextBox", "飲料");
            Robot.ClickButton("_saveCategoryButton");

            Robot.FindWindow(_customFormName);
            Robot.ClickTabControl("飲料");
        }

        private void RunScriptResetRecord()
        {
            Robot.FindWindow(_restaurantDFormName);
            Robot.ClickTabControl("Meal Manager");

            Robot.ClickListViewByValue(_restaurantDFormName, "漢堡");
            Robot.SetEdit("_mealNameTextBox", "漢堡5");
            Robot.SetEdit("_priceTextBox", "105");
            Robot.ClickButton("_saveMealButton");

            Robot.ClickButton("Add New Meal");
            Robot.SetEdit("_mealNameTextBox", "可口可樂");
            Robot.SetEdit("_priceTextBox", "25");
            Robot.ClickButton("Browse...");
            Robot.FindWindow("開啟");
            Robot.KeyText("Beverage Syrup Coca Cola_L_hero.png");
            Robot.ClickButton("開啟(O)");
            Robot.FindWindow(_restaurantDFormName);
            Robot.SetComboBox("_categoryComboBox", "飲料");
            Robot.ClickButton("_saveMealButton");

            Robot.ClickButton("Add New Meal");
            Robot.SetEdit("_mealNameTextBox", "雪碧");
            Robot.SetEdit("_priceTextBox", "25");
            Robot.ClickButton("Browse...");
            Robot.FindWindow("開啟");
            Robot.KeyText("Beverage Syrup Sprite_L_hero.png");
            Robot.ClickButton("開啟(O)");
            Robot.FindWindow(_restaurantDFormName);
            Robot.SetComboBox("_categoryComboBox", "飲料");
            Robot.ClickButton("_saveMealButton");

            Robot.ClickButton("Add New Meal");
            Robot.SetEdit("_mealNameTextBox", "檸檬紅茶");
            Robot.SetEdit("_priceTextBox", "25");
            Robot.ClickButton("Browse...");
            Robot.FindWindow("開啟");
            Robot.KeyText("Nestle Lemon Tea_L_hero.png");
            Robot.ClickButton("開啟(O)");
            Robot.FindWindow(_restaurantDFormName);
            Robot.SetComboBox("_categoryComboBox", "飲料");
            Robot.ClickButton("_saveMealButton");

            Robot.FindWindow(_customFormName);
            Robot.ClickTabControl("飲料");
        }
        

        /// <summary>
        /// Tests the start form button
        /// </summary>        
        [TestMethod]
        public void TestStartForm()
        {
            RunScriptStartForm();
        }
        /// <summary>
        /// Tests the customer side form 
        /// </summary>     
        [TestMethod]
        public void TestCustomerSide()
        {
            RunScriptCustomerSide();
            RunScriptOrderMeal();
        }
        /// <summary>
        /// Tests the start form button
        /// </summary>     
        [TestMethod]
        public void TestRestaurantSide()
        {
            RunScriptRestaurantSide();
            RunScriptMealEdit();
            RunScriptMealDelete();
            RunScriptMealAdd();
            RunScriptCategoryEdit();
            RunScriptCategoryDelete();
            RunScriptCategoryAdd();
            RunScriptResetRecord();
        }
    }
}
