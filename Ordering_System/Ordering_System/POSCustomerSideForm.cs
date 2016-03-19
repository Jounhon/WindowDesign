using Ordering_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DataGridViewNumericUpDownElements;

namespace Ordering_System
{
    public partial class CustomerSideForm : Form
    {
        PresentationFrontSideFormModel _presentationModel;
        SystemModel _model;
        MealControl _mealControl;
        OrderControl _orderControl;
        CategoryControl _categoryControl;
        PageControl _pageControl;
        TabControl _tabControl = new TabControl();
        const int MAX_BUTTONS = 9;
        const int MAX_COLUMNS = 3;
        const string TABLE_NAME = "table";

        public CustomerSideForm(PresentationFrontSideFormModel presentationModel)
        {
            InitializeComponent();
            this._presentationModel = presentationModel;
            this._model = _presentationModel.GetSystemModel();
            this._mealControl = _model.GetMealControl();
            this._orderControl = _model.GetOrderControl();
            this._categoryControl = _model.GetCategoryControl();
            this._pageControl = _model.GetPageControl();
            _model._eventMealListUpdate += new EventHandler(UpdateGroupBox);
            _model._eventCategoryListUpdate += new EventHandler(UpdateTab);
            InitializeDataGridView();
            InitializeGroupBox();
        }

        // update meal list form back end
        private void UpdateGroupBox(object sender, EventArgs e)
        {
            RefreshTabPage();
            UpdateDataGridView();
        }

        // update category list form back end
        private void UpdateTab(object sender, EventArgs e)
        {
            InitializeGroupBox();
            UpdateDataGridView();
        }

        // init group box
        public void InitializeGroupBox()
        {
            int index = InitializeTabControl();
            foreach (Category item in _categoryControl.GetCategoryList())
            {
                if (item.Name.Equals("未分類"))
                    continue;
                TabPage tabPage = new TabPage();
                tabPage.Text = tabPage.Name = item.Name;
                _tabControl.Controls.Add(tabPage);
                TableLayoutPanel mealTableLayoutPanel = CreateTableLayout();
                tabPage.Controls.Add(mealTableLayoutPanel);
            }
            _tabControl.SelectedIndex = index;
            RefreshTabPage();
        }

        //init tab control
        private int InitializeTabControl()
        {
            _tabControl.Controls.Clear();
            _tabControl.Dock = DockStyle.Fill;
            _tabControl.Font = new Font(_tabControl.Font.FontFamily, 10, _tabControl.Font.Style | FontStyle.Bold);
            _tabControl.SelectedIndexChanged += new EventHandler(ChangeIndexOfTabControl);
            _mealGroupBox.Controls.Add(_tabControl);
            int index = _tabControl.SelectedIndex;
            if (index < 0)
                index = 0;
            return index;
        }

        // refresh Tab page
        public void RefreshTabPage()
        {
            if (!_tabControl.TabPages.Count.Equals(0))
            {
                ClearButtons();
                DisplayTabPageContent(_tabControl.SelectedTab.Text);
            }
        }

        // tab control index select change
        private void ChangeIndexOfTabControl(object sender, EventArgs e)
        {
            _pageControl.InitializePage();
            RefreshTabPage();
        }

        // create table layout panel
        private TableLayoutPanel CreateTableLayout()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Name = TABLE_NAME;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            return tableLayoutPanel;
        }

        // show page button
        private void ShowPageButton()
        {
            _presentationModel.CheckPreviousButton();
            _presentationModel.CheckNextButton(_tabControl.SelectedTab.Text);
            _previousButton.Visible = _presentationModel.IsPreviousButtonVisible;
            _nextButton.Visible = _presentationModel.IsNextButtonVisible;
        }

        // create and change buttons & page
        public void DisplayTabPageContent(string categoryName)
        {
            ShowPageButton();
            List<Meal> mealList = _mealControl.GetMealOfCategory(categoryName);
            for (int index = (_pageControl.Page - 1) * MAX_BUTTONS; index < _pageControl.Page * MAX_BUTTONS; index++)
            {
                if (index >= mealList.Count)
                    break;
                int columnIndex = index / MAX_COLUMNS - (_pageControl.Page - 1) * MAX_COLUMNS;
                int rowIndex = index % MAX_COLUMNS;
                Meal mealButton = mealList[index];
                CreateMealButton(mealButton, rowIndex, columnIndex);
            }
            _pageLabel.Text = "Page : " + _pageControl.Page + " / " + _model.GetMaxPage(categoryName);
        }

        // create meal button
        private void CreateMealButton(Meal meal, int row, int column)
        {
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];
            TableLayoutPanel table = tabPage.Controls[TABLE_NAME] as TableLayoutPanel;
            meal.Click -= ClickMealButton;
            meal.Click += new EventHandler(ClickMealButton);
            meal.MouseEnter += new EventHandler(EnterMealButton);
            meal.MouseLeave += new EventHandler(LeaveMealButton);
            table.Controls.Add(meal, row, column);
        }

        // add order and update record data grid view
        private void ClickMealButton(object sender, EventArgs e)
        {
            Meal mealData = (Meal)sender;
            _model.AddOrder(mealData);
            _model.EnableDeleteCategoryButton();
            UpdateDataGridView();
        }

        // enter the meal button
        private void EnterMealButton(object sender, EventArgs e)
        {
            Meal mealData = (Meal)sender;
            _descriptionTextBox.Text = mealData.Description;
        }

        // leave the meal button
        private void LeaveMealButton(object sender, EventArgs e)
        {
            _descriptionTextBox.Text = "";
        }

        // clear buttons
        private void ClearButtons()
        {
            int currentPage = _pageControl.Page - 1;
            string categoryName = _tabControl.SelectedTab.Text;
            TabPage tabPage = _tabControl.TabPages[_tabControl.SelectedIndex];
            TableLayoutPanel table = tabPage.Controls["table"] as TableLayoutPanel;
            for (int index = (_pageControl.Page - 1) * MAX_BUTTONS; index < _pageControl.Page * MAX_BUTTONS; index++)
            {
                if (index >= _mealControl.GetMealOfCategory(categoryName).Count)
                    break;
                Meal meal = table.Controls[_mealControl.GetMealOfCategory(categoryName)[index].Title] as Meal;
                if (meal != null)
                    meal.Click -= ClickMealButton;
            }
            table.Controls.Clear();
        }

        // initialze data grid view
        private void InitializeDataGridView()
        {
            _recordDataGridView.ReadOnly = _presentationModel.IsRecordDataGridViewReadOnly;
            const string QUANTITY = "Qty";
            string[] headerText = { "Meal Name", "Category", "Unit Price", QUANTITY, "Subtotal" };
            const int MINIMUM = 1;
            for (var counter = 0; counter < headerText.Length; counter++)
            {
                if (headerText[counter].Equals(QUANTITY))
                    AddNumericUpDownColumn(headerText[counter], MINIMUM);
                else
                    AddTextBoxColumn(headerText[counter]);
            }
            AddDeleteColumn();
        }

        // add text box Column
        private void AddTextBoxColumn(string text)
        {
            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.HeaderText = text;
            textBoxColumn.Name = text;
            textBoxColumn.ReadOnly = _presentationModel.IsTextBoxColumnReadOnly;
            _recordDataGridView.Columns.Add(textBoxColumn);
        }

        // add numeric up and down Column
        private void AddNumericUpDownColumn(string text, int minimum)
        {
            DataGridViewNumericUpDownColumn numericUpDownColumn = new DataGridViewNumericUpDownColumn();
            numericUpDownColumn.HeaderText = text;
            numericUpDownColumn.Name = text;
            numericUpDownColumn.Minimum = minimum;
            numericUpDownColumn.ReadOnly = _presentationModel.IsNumericUpDownColumnReadOnly;
            _recordDataGridView.Columns.Add(numericUpDownColumn);
            _recordDataGridView.CellValueChanged += new DataGridViewCellEventHandler(UpdateRow);
        }

        // add delete button Column
        private void AddDeleteColumn()
        {
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Name = "deleteColumn";
            _recordDataGridView.Columns.Add(deleteColumn);
            _recordDataGridView.CellContentClick += new DataGridViewCellEventHandler(DeleteButton);
        }

        // update data grid view
        public void UpdateDataGridView()
        {
            _recordDataGridView.Rows.Clear();
            foreach (Order item in _orderControl.GetOrderList())
            {
                _recordDataGridView.Rows.Add(item.GetMeal().Title, item.GetMeal().Category, item.GetMeal().Price, Convert.ToInt16(item.Quantity), item.Total, "x");
            }
            _totalLabel.Text = "Total : " + _orderControl.CalculateTotal().ToString() + " NTD.";
        }

        // delete order
        private void DeleteButton(object sender, DataGridViewCellEventArgs e)
        {
            const int DELETE_COLUMN = 5;
            if (e.ColumnIndex.Equals(DELETE_COLUMN) && e.RowIndex >= 0)
            {
                string mealName = _recordDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                _orderControl.RemoveOneMealOfList(mealName);
                _model.EnableDeleteCategoryButton();
                UpdateDataGridView();
            }
        }

        // go previous page
        private void GoPreviousPageButtonClick(object sender, EventArgs e)
        {
            ClearButtons();
            _pageControl.GoPreviousPage();
            DisplayTabPageContent(_tabControl.SelectedTab.Text);
        }

        // go next page
        private void GoNextPageButtonClick(object sender, EventArgs e)
        {
            ClearButtons();
            _model.GoNextPage(_tabControl.SelectedTab.Text);
            DisplayTabPageContent(_tabControl.SelectedTab.Text);
        }

        // update row value to order list
        private void UpdateRow(object sender, DataGridViewCellEventArgs e)
        {
            const int NUMERIC_COLUMN = 3;
            if (e.ColumnIndex.Equals(NUMERIC_COLUMN))
            {
                int quantity = Convert.ToInt16(_recordDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                string name = _recordDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                _orderControl.UpdateOrder(quantity, name);
                UpdateDataGridView();
            }
        }
    }
}
