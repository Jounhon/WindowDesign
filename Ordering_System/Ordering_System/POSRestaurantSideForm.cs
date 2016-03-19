using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ordering_System.Model;
using System.IO;

namespace Ordering_System
{
    public partial class RestaurantSideForm : Form
    {
        PresentationBackSideFormModel _presentationModel;
        SystemModel _model;
        MealControl _mealControl;
        OrderControl _orderControl;
        CategoryControl _categoryControl;
        const string ADD_MEAL = "Add New Meal";
        const string EDIT_MEAL = "Edit Meal";
        const string ADD_CATEGORY = "Add Category";
        const string EDIT_CATEGORY = "Edit Category";
        const string ADD = "Add";
        const string SAVE = "Save";

        public RestaurantSideForm(PresentationBackSideFormModel presentationModel)
        {
            InitializeComponent();
            this._presentationModel = presentationModel;
            this._model = _presentationModel.GetSystemModel();
            this._mealControl = _model.GetMealControl();
            this._orderControl = _model.GetOrderControl();
            this._categoryControl = _model.GetCategoryControl();
            _model._eventMealButtonClick += new EventHandler(EnableDeleteCategoryButton);
            InitializeMealTabPage();
            InitializeCategoryTabPage();
        }

        // delete category button enable or not
        private void EnableDeleteCategoryButton(object sender, EventArgs e)
        {
            if (_categoryListBox.SelectedIndex >= 0)
                _presentationModel.CheckOrderIfHaveMeal(_categoryListBox.SelectedItem.ToString());
            _deleteCategoryButton.Enabled = _presentationModel.IsDeleteCategoryEnabled;
        }

        // Initialize meal tab page
        private void InitializeMealTabPage()
        {
            _saveMealButton.Enabled = _presentationModel.IsSaveMealEnabled;
            _mealListBox.Items.Clear();
            RefreshMealListBox();
            InitializeComboBox();
            _browseButton.Click -= BrowseButtonClick;
            _saveMealButton.Click -= SaveMeal;
            _browseButton.Click += new EventHandler(BrowseButtonClick);
            _saveMealButton.Click += new EventHandler(SaveMeal);
            _deleteMealButton.Click += new EventHandler(DeleteMeal);
            _addMealButton.Click += new EventHandler(AddNewMeal);
            _categoryNameTextBox.TextChanged += new EventHandler(CheckCategoryTextBox);
            _mealNameTextBox.TextChanged += new EventHandler(CheckMealGroupBoxTextBox);
            _priceTextBox.TextChanged += new EventHandler(CheckMealGroupBoxTextBox);
            _pathTextBox.TextChanged += new EventHandler(CheckMealGroupBoxTextBox);
        }

        // check meal group text boxs is empty?
        private void CheckMealGroupBoxTextBox(object sender, EventArgs e)
        {
            if (_mealNameTextBox.Text.Equals("") || _priceTextBox.Text.Equals("") || _pathTextBox.Text.Equals(""))
                _presentationModel.IsEmptyOfMealGroupTextBox(true);
            else
                _presentationModel.IsEmptyOfMealGroupTextBox(false);
            _saveMealButton.Enabled = _presentationModel.IsSaveMealEnabled;
        }

        // check category text box is empty?
        private void CheckCategoryTextBox(object sender, EventArgs e)
        {
            _presentationModel.IsEmptyOfCategoryTextBox(_categoryNameTextBox.Text);
            //if (_categoryListBox.SelectedIndex > 0)
            //    _presentationModel.IsDefaultCategory(_categoryListBox.SelectedItem.ToString());
            _saveCategoryButton.Enabled = _presentationModel.IsSaveCategoryEnabled;
        }

        // browse button click
        private void BrowseButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string imagePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) +"\\image\\";
            Console.WriteLine(imagePath);
            openFileDialog.InitialDirectory = imagePath;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image|*.png;*.jpg;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string absoluteFilePath = openFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(absoluteFilePath);
                string extension = Path.GetExtension(absoluteFilePath);
                if (!absoluteFilePath.Equals(imagePath + fileName + extension))
                    File.Copy(absoluteFilePath, imagePath + fileName + extension);
                _pathTextBox.Text = "/image/" + fileName + extension;
            }
        }

        // save meal button
        private void SaveMeal(object sender, EventArgs e)
        {
            Meal meal = new Meal();
            meal.SetValue(_mealNameTextBox.Text, _priceTextBox.Text, _descriptionTextBox.Text, _pathTextBox.Text);
            meal.SetCategory(_categoryControl.GetCategoryByName(_categoryComboBox.SelectedItem.ToString()));
            if (_mealManagerGroupBox.Text.Equals(ADD_MEAL))
            {
                bool success = _mealControl.InitializeMealButton(meal);
                if (!success)
                    ShowDoubleMessageBox();
            }
            else if (_mealManagerGroupBox.Text.Equals(EDIT_MEAL))
                _model.ChangeMealDetail(_mealListBox.SelectedItem.ToString(), meal);
            RefreshBySaveMeal();
            _model.UpdateMealList();
            _mealControl.SaveMealListToFile();
        }

        // refresh after save meal
        private void RefreshBySaveMeal()
        {
            RefreshMealListBox();
            RefreshMealManagerView();
            RefreshCategoryManagerView();
        }

        // initialize combo box
        private void InitializeComboBox()
        {
            _categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _categoryComboBox.Items.Clear();
            foreach (Category item in _categoryControl.GetCategoryList())
            {
                _categoryComboBox.Items.Add(item.Name);
            }
            _categoryComboBox.SelectedIndex = 0;
        }

        // click add meal button
        private void AddNewMeal(object sender, EventArgs e)
        {
            _saveMealButton.Text = ADD;
            RefreshMealManagerView();
        }

        //refresh meal manager view
        private void RefreshMealManagerView()
        {
            _mealManagerGroupBox.Text = ADD_MEAL;
            _mealListBox.ClearSelected();
            _mealNameTextBox.Text = _priceTextBox.Text = _pathTextBox.Text = _descriptionTextBox.Text = "";
            _presentationModel.DisableDeleteMealButton();
            _deleteMealButton.Enabled = _presentationModel.IsDeleteMealEnabled;
        }

        // click delete meal button
        private void DeleteMeal(object sender, EventArgs e)
        {
            if (_mealListBox.SelectedIndex < 0)
                return;
            string mealName = _mealListBox.SelectedItem.ToString();
            _mealListBox.Items.Remove(mealName);
            _mealControl.RemoveMeal(mealName);
            _model.UpdateMealList();
            _mealControl.SaveMealListToFile();
            RefreshMealManagerView();
            RefreshCategoryManagerView();
        }

        // meal item selected
        private void SelectMealItem(object sender, EventArgs e)
        {
            _saveMealButton.Text = SAVE;
            int index = _mealListBox.SelectedIndex;
            if (index >= 0)
            {
                _presentationModel.EnableDeleteMealButton();
                _deleteMealButton.Enabled = _presentationModel.IsDeleteMealEnabled;
                _mealManagerGroupBox.Text = EDIT_MEAL;
                Meal meal = _mealControl.GetMealByTitle(_mealListBox.SelectedItem.ToString());
                _mealNameTextBox.Text = meal.Title;
                _priceTextBox.Text = meal.Price;
                _descriptionTextBox.Text = meal.Description;
                _pathTextBox.Text = meal.ImagePath;
                _categoryComboBox.SelectedIndex = _categoryComboBox.Items.IndexOf(meal.Category);
            }
        }

        // click add Category button
        private void AddNewCategory(object sender, EventArgs e)
        {
            _presentationModel.EnableCategoryTextBox();
            _presentationModel.IsEmptyOfCategoryTextBox(_categoryNameTextBox.Text);
            InitializeCategoryTabPage();
            _saveCategoryButton.Text = ADD;
        }

        // init category tab page
        private void InitializeCategoryTabPage()
        {
            _deleteMealButton.Enabled = _presentationModel.IsDeleteMealEnabled;
            _deleteCategoryButton.Enabled = _presentationModel.IsDeleteCategoryEnabled;
            _saveCategoryButton.Enabled = _presentationModel.IsSaveCategoryEnabled;
            _categoryNameTextBox.ReadOnly = _presentationModel.IsCategoryReadOnly;
            _categoryGroupBox.Text = ADD_CATEGORY;
            _categoryListBox.ClearSelected();
            _categoryNameTextBox.Text = "";
            _mealOfCategoryListBox.Items.Clear();
            _categoryListBox.Items.Clear();
            RefreshCategoryListBox();
        }

        // click delete Category button
        private void DeleteCategory(object sender, EventArgs e)
        {
            int index = _categoryListBox.SelectedIndex;
            if (index >= 0)
            {
                _model.RemoveCategory(_categoryListBox.SelectedItem.ToString());
                _categoryListBox.Items.RemoveAt(index);
                InitializeCategoryTabPage();
                InitializeMealTabPage();
                _model.UpdateCategoryList();
                _categoryControl.SaveCategoryListToFile();
                _mealControl.SaveMealListToFile();
            }
        }

        // Category item selected
        private void SelectCategoryItem(object sender, EventArgs e)
        {
            _saveCategoryButton.Text = SAVE;
            if (_categoryListBox.SelectedIndex >= 0)
                _presentationModel.CheckOrderIfHaveMeal(_categoryListBox.SelectedItem.ToString());
            RefreshCategoryManagerView();
        }

        // refresh category manager view
        private void RefreshCategoryManagerView()
        {
            int index = _categoryListBox.SelectedIndex;
            if (index >= 0)
            {
                //_presentationModel.IsDefaultCategory(_categoryListBox.SelectedItem.ToString());
                _deleteCategoryButton.Enabled = _presentationModel.IsDeleteCategoryEnabled;
                _saveCategoryButton.Enabled = _presentationModel.IsSaveCategoryEnabled;
                _categoryNameTextBox.ReadOnly = _presentationModel.IsCategoryReadOnly;
                _categoryGroupBox.Text = EDIT_CATEGORY;
                _categoryNameTextBox.Text = _categoryListBox.SelectedItem.ToString();
                _mealOfCategoryListBox.Items.Clear();
                List<Meal> mealLis = _mealControl.GetMealOfCategory(_categoryListBox.SelectedItem.ToString());
                foreach (Meal item in mealLis)
                    _mealOfCategoryListBox.Items.Add(item.Title);
            }
        }

        // click save category to add new or edit old
        private void SaveCategory(object sender, EventArgs e)
        {
            if (_categoryGroupBox.Text.Equals(ADD_CATEGORY))
                AddCategory();
            else if (_categoryGroupBox.Text.Equals(EDIT_CATEGORY))
                _categoryControl.ChangeCategoryName(_categoryListBox.SelectedItem.ToString(), _categoryNameTextBox.Text);
            InitializeComboBox();
            InitializeCategoryTabPage();
            _model.UpdateCategoryList();
            _categoryControl.SaveCategoryListToFile();
            _mealControl.SaveMealListToFile();
        }

        // add category
        private void AddCategory()
        {
            bool success = _categoryControl.AddCategory(_categoryNameTextBox.Text.ToString());
            if (!success)
                ShowDoubleMessageBox();
            else
            {
                _categoryListBox.Items.Insert(0, _categoryNameTextBox.Text.ToString());
                _model.UpdateCategoryList();
                _categoryControl.SaveCategoryListToFile();
                _mealControl.SaveMealListToFile();
            }
            _categoryNameTextBox.Text = "";
        }

        // show message box
        private void ShowDoubleMessageBox()
        {
            MessageBox.Show("Dublicated Name", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Refresh category list box
        private void RefreshCategoryListBox()
        {
            _categoryListBox.Items.Clear();
            foreach (Category item in _categoryControl.GetCategoryList())
            {
                _categoryListBox.Items.Add(item.Name);
            }
        }

        // Refresh meal list box
        private void RefreshMealListBox()
        {
            _mealListBox.Items.Clear();
            foreach (Meal item in _mealControl.GetMealList())
            {
                _mealListBox.Items.Add(item.Title);
            }
        }
    }
}
