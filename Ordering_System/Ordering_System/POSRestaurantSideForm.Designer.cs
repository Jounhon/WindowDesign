namespace Ordering_System
{
    partial class RestaurantSideForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._manageTabControl = new System.Windows.Forms.TabControl();
            this._mealTabPage = new System.Windows.Forms.TabPage();
            this._mealTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._mealListBox = new System.Windows.Forms.ListBox();
            this._mealManagerGroupBox = new System.Windows.Forms.GroupBox();
            this._mealManagerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._saveMealButton = new System.Windows.Forms.Button();
            this._mealNameLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._categoryLabel = new System.Windows.Forms.Label();
            this._pathLabel = new System.Windows.Forms.Label();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this._priceTextBox = new System.Windows.Forms.TextBox();
            this._mealNameTextBox = new System.Windows.Forms.TextBox();
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._pathTextBox = new System.Windows.Forms.TextBox();
            this._browseButton = new System.Windows.Forms.Button();
            this._addMealButton = new System.Windows.Forms.Button();
            this._deleteMealButton = new System.Windows.Forms.Button();
            this._categoryTabPage = new System.Windows.Forms.TabPage();
            this._categoryTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._categoryListBox = new System.Windows.Forms.ListBox();
            this._categoryGroupBox = new System.Windows.Forms.GroupBox();
            this._categoryManagerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._saveCategoryButton = new System.Windows.Forms.Button();
            this._mealOfCategoryListBox = new System.Windows.Forms.ListBox();
            this._mealLabel = new System.Windows.Forms.Label();
            this._categoryNameLabel = new System.Windows.Forms.Label();
            this._categoryNameTextBox = new System.Windows.Forms.TextBox();
            this._addCategoryButton = new System.Windows.Forms.Button();
            this._deleteCategoryButton = new System.Windows.Forms.Button();
            this._manageTabControl.SuspendLayout();
            this._mealTabPage.SuspendLayout();
            this._mealTableLayoutPanel.SuspendLayout();
            this._mealManagerGroupBox.SuspendLayout();
            this._mealManagerTableLayoutPanel.SuspendLayout();
            this._categoryTabPage.SuspendLayout();
            this._categoryTableLayoutPanel.SuspendLayout();
            this._categoryGroupBox.SuspendLayout();
            this._categoryManagerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _manageTabControl
            // 
            this._manageTabControl.Controls.Add(this._mealTabPage);
            this._manageTabControl.Controls.Add(this._categoryTabPage);
            this._manageTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._manageTabControl.Location = new System.Drawing.Point(0, 0);
            this._manageTabControl.Name = "_manageTabControl";
            this._manageTabControl.SelectedIndex = 0;
            this._manageTabControl.Size = new System.Drawing.Size(918, 451);
            this._manageTabControl.TabIndex = 0;
            // 
            // _mealTabPage
            // 
            this._mealTabPage.Controls.Add(this._mealTableLayoutPanel);
            this._mealTabPage.Location = new System.Drawing.Point(4, 22);
            this._mealTabPage.Name = "_mealTabPage";
            this._mealTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._mealTabPage.Size = new System.Drawing.Size(910, 425);
            this._mealTabPage.TabIndex = 0;
            this._mealTabPage.Text = "Meal Manager";
            this._mealTabPage.UseVisualStyleBackColor = true;
            // 
            // _mealTableLayoutPanel
            // 
            this._mealTableLayoutPanel.ColumnCount = 3;
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._mealTableLayoutPanel.Controls.Add(this._mealListBox, 0, 0);
            this._mealTableLayoutPanel.Controls.Add(this._mealManagerGroupBox, 2, 0);
            this._mealTableLayoutPanel.Controls.Add(this._addMealButton, 0, 1);
            this._mealTableLayoutPanel.Controls.Add(this._deleteMealButton, 1, 1);
            this._mealTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this._mealTableLayoutPanel.Name = "_mealTableLayoutPanel";
            this._mealTableLayoutPanel.RowCount = 2;
            this._mealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._mealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealTableLayoutPanel.Size = new System.Drawing.Size(904, 419);
            this._mealTableLayoutPanel.TabIndex = 0;
            // 
            // _mealListBox
            // 
            this._mealListBox.AccessibleName = "_mealListBox";
            this._mealTableLayoutPanel.SetColumnSpan(this._mealListBox, 2);
            this._mealListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealListBox.FormattingEnabled = true;
            this._mealListBox.ItemHeight = 12;
            this._mealListBox.Location = new System.Drawing.Point(3, 3);
            this._mealListBox.Name = "_mealListBox";
            this._mealListBox.Size = new System.Drawing.Size(354, 371);
            this._mealListBox.TabIndex = 0;
            this._mealListBox.SelectedIndexChanged += new System.EventHandler(this.SelectMealItem);
            // 
            // _mealManagerGroupBox
            // 
            this._mealManagerGroupBox.Controls.Add(this._mealManagerTableLayoutPanel);
            this._mealManagerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealManagerGroupBox.Location = new System.Drawing.Point(363, 3);
            this._mealManagerGroupBox.Name = "_mealManagerGroupBox";
            this._mealTableLayoutPanel.SetRowSpan(this._mealManagerGroupBox, 2);
            this._mealManagerGroupBox.Size = new System.Drawing.Size(538, 413);
            this._mealManagerGroupBox.TabIndex = 1;
            this._mealManagerGroupBox.TabStop = false;
            this._mealManagerGroupBox.Text = "Add New Meal";
            // 
            // _mealManagerTableLayoutPanel
            // 
            this._mealManagerTableLayoutPanel.ColumnCount = 4;
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._mealManagerTableLayoutPanel.Controls.Add(this._saveMealButton, 3, 5);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealNameLabel, 0, 0);
            this._mealManagerTableLayoutPanel.Controls.Add(this._priceLabel, 0, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._categoryLabel, 2, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._pathLabel, 0, 2);
            this._mealManagerTableLayoutPanel.Controls.Add(this._descriptionLabel, 0, 3);
            this._mealManagerTableLayoutPanel.Controls.Add(this._descriptionTextBox, 0, 4);
            this._mealManagerTableLayoutPanel.Controls.Add(this._priceTextBox, 1, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealNameTextBox, 1, 0);
            this._mealManagerTableLayoutPanel.Controls.Add(this._categoryComboBox, 3, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._pathTextBox, 1, 2);
            this._mealManagerTableLayoutPanel.Controls.Add(this._browseButton, 3, 2);
            this._mealManagerTableLayoutPanel.Location = new System.Drawing.Point(6, 35);
            this._mealManagerTableLayoutPanel.Name = "_mealManagerTableLayoutPanel";
            this._mealManagerTableLayoutPanel.RowCount = 6;
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.760272F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.760272F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.760272F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.760272F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.55823F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.40068F));
            this._mealManagerTableLayoutPanel.Size = new System.Drawing.Size(526, 372);
            this._mealManagerTableLayoutPanel.TabIndex = 0;
            // 
            // _saveMealButton
            // 
            this._saveMealButton.AccessibleName = "_saveMealButton";
            this._saveMealButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._saveMealButton.Location = new System.Drawing.Point(396, 346);
            this._saveMealButton.Name = "_saveMealButton";
            this._saveMealButton.Size = new System.Drawing.Size(127, 23);
            this._saveMealButton.TabIndex = 0;
            this._saveMealButton.Text = "Add";
            this._saveMealButton.UseVisualStyleBackColor = true;
            // 
            // _mealNameLabel
            // 
            this._mealNameLabel.AutoSize = true;
            this._mealNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealNameLabel.Location = new System.Drawing.Point(3, 0);
            this._mealNameLabel.Name = "_mealNameLabel";
            this._mealNameLabel.Size = new System.Drawing.Size(151, 36);
            this._mealNameLabel.TabIndex = 1;
            this._mealNameLabel.Text = "Meal Name (*)";
            this._mealNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _priceLabel
            // 
            this._priceLabel.AutoSize = true;
            this._priceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._priceLabel.Location = new System.Drawing.Point(3, 36);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(151, 36);
            this._priceLabel.TabIndex = 2;
            this._priceLabel.Text = "Meal Price (*)";
            this._priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _categoryLabel
            // 
            this._categoryLabel.AutoSize = true;
            this._categoryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryLabel.Location = new System.Drawing.Point(265, 36);
            this._categoryLabel.Name = "_categoryLabel";
            this._categoryLabel.Size = new System.Drawing.Size(125, 36);
            this._categoryLabel.TabIndex = 3;
            this._categoryLabel.Text = "NTD   Meal Category (*)";
            this._categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _pathLabel
            // 
            this._pathLabel.AutoSize = true;
            this._pathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pathLabel.Location = new System.Drawing.Point(3, 72);
            this._pathLabel.Name = "_pathLabel";
            this._pathLabel.Size = new System.Drawing.Size(151, 36);
            this._pathLabel.TabIndex = 4;
            this._pathLabel.Text = "Meal Image Relative Path (*)";
            this._pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._descriptionLabel.Location = new System.Drawing.Point(3, 108);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(151, 36);
            this._descriptionLabel.TabIndex = 5;
            this._descriptionLabel.Text = "Meal Description";
            this._descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.AccessibleName = "_descriptionTextBox";
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._descriptionTextBox, 4);
            this._descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._descriptionTextBox.Location = new System.Drawing.Point(3, 147);
            this._descriptionTextBox.Multiline = true;
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.Size = new System.Drawing.Size(520, 129);
            this._descriptionTextBox.TabIndex = 6;
            // 
            // _priceTextBox
            // 
            this._priceTextBox.AccessibleName = "_priceTextBox";
            this._priceTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._priceTextBox.Location = new System.Drawing.Point(160, 47);
            this._priceTextBox.Name = "_priceTextBox";
            this._priceTextBox.Size = new System.Drawing.Size(99, 22);
            this._priceTextBox.TabIndex = 7;
            // 
            // _mealNameTextBox
            // 
            this._mealNameTextBox.AccessibleName = "_mealNameTextBox";
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._mealNameTextBox, 3);
            this._mealNameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealNameTextBox.Location = new System.Drawing.Point(160, 11);
            this._mealNameTextBox.Name = "_mealNameTextBox";
            this._mealNameTextBox.Size = new System.Drawing.Size(363, 22);
            this._mealNameTextBox.TabIndex = 8;
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.AccessibleName = "_categoryComboBox";
            this._categoryComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(396, 49);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(127, 20);
            this._categoryComboBox.TabIndex = 9;
            // 
            // _pathTextBox
            // 
            this._pathTextBox.AccessibleName = "_pathTextBox";
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._pathTextBox, 2);
            this._pathTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pathTextBox.Location = new System.Drawing.Point(160, 83);
            this._pathTextBox.Name = "_pathTextBox";
            this._pathTextBox.ReadOnly = true;
            this._pathTextBox.Size = new System.Drawing.Size(230, 22);
            this._pathTextBox.TabIndex = 10;
            // 
            // _browseButton
            // 
            this._browseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._browseButton.Location = new System.Drawing.Point(396, 82);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(127, 23);
            this._browseButton.TabIndex = 11;
            this._browseButton.Text = "Browse...";
            this._browseButton.UseVisualStyleBackColor = true;
            // 
            // _addMealButton
            // 
            this._addMealButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._addMealButton.Location = new System.Drawing.Point(3, 380);
            this._addMealButton.Name = "_addMealButton";
            this._addMealButton.Size = new System.Drawing.Size(86, 36);
            this._addMealButton.TabIndex = 2;
            this._addMealButton.Text = "Add New Meal";
            this._addMealButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._addMealButton.UseVisualStyleBackColor = true;
            this._addMealButton.Click += new System.EventHandler(this.AddNewMeal);
            // 
            // _deleteMealButton
            // 
            this._deleteMealButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._deleteMealButton.Location = new System.Drawing.Point(236, 380);
            this._deleteMealButton.Name = "_deleteMealButton";
            this._deleteMealButton.Size = new System.Drawing.Size(121, 36);
            this._deleteMealButton.TabIndex = 3;
            this._deleteMealButton.Text = "Delete Selected Meal";
            this._deleteMealButton.UseVisualStyleBackColor = true;
            this._deleteMealButton.Click += new System.EventHandler(this.DeleteMeal);
            // 
            // _categoryTabPage
            // 
            this._categoryTabPage.Controls.Add(this._categoryTableLayoutPanel);
            this._categoryTabPage.Location = new System.Drawing.Point(4, 22);
            this._categoryTabPage.Name = "_categoryTabPage";
            this._categoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._categoryTabPage.Size = new System.Drawing.Size(910, 425);
            this._categoryTabPage.TabIndex = 1;
            this._categoryTabPage.Text = "Category Manager";
            this._categoryTabPage.UseVisualStyleBackColor = true;
            // 
            // _categoryTableLayoutPanel
            // 
            this._categoryTableLayoutPanel.ColumnCount = 3;
            this._categoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._categoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._categoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._categoryTableLayoutPanel.Controls.Add(this._categoryListBox, 0, 0);
            this._categoryTableLayoutPanel.Controls.Add(this._categoryGroupBox, 2, 0);
            this._categoryTableLayoutPanel.Controls.Add(this._addCategoryButton, 0, 1);
            this._categoryTableLayoutPanel.Controls.Add(this._deleteCategoryButton, 1, 1);
            this._categoryTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this._categoryTableLayoutPanel.Name = "_categoryTableLayoutPanel";
            this._categoryTableLayoutPanel.RowCount = 2;
            this._categoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._categoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryTableLayoutPanel.Size = new System.Drawing.Size(904, 419);
            this._categoryTableLayoutPanel.TabIndex = 1;
            // 
            // _categoryListBox
            // 
            this._categoryTableLayoutPanel.SetColumnSpan(this._categoryListBox, 2);
            this._categoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryListBox.FormattingEnabled = true;
            this._categoryListBox.ItemHeight = 12;
            this._categoryListBox.Location = new System.Drawing.Point(3, 3);
            this._categoryListBox.Name = "_categoryListBox";
            this._categoryListBox.Size = new System.Drawing.Size(354, 371);
            this._categoryListBox.TabIndex = 0;
            this._categoryListBox.SelectedIndexChanged += new System.EventHandler(this.SelectCategoryItem);
            // 
            // _categoryGroupBox
            // 
            this._categoryGroupBox.Controls.Add(this._categoryManagerTableLayoutPanel);
            this._categoryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryGroupBox.Location = new System.Drawing.Point(363, 3);
            this._categoryGroupBox.Name = "_categoryGroupBox";
            this._categoryTableLayoutPanel.SetRowSpan(this._categoryGroupBox, 2);
            this._categoryGroupBox.Size = new System.Drawing.Size(538, 413);
            this._categoryGroupBox.TabIndex = 1;
            this._categoryGroupBox.TabStop = false;
            this._categoryGroupBox.Text = "Add Category";
            // 
            // _categoryManagerTableLayoutPanel
            // 
            this._categoryManagerTableLayoutPanel.ColumnCount = 2;
            this._categoryManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._categoryManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._categoryManagerTableLayoutPanel.Controls.Add(this._saveCategoryButton, 1, 3);
            this._categoryManagerTableLayoutPanel.Controls.Add(this._mealOfCategoryListBox, 0, 2);
            this._categoryManagerTableLayoutPanel.Controls.Add(this._mealLabel, 0, 1);
            this._categoryManagerTableLayoutPanel.Controls.Add(this._categoryNameLabel, 0, 0);
            this._categoryManagerTableLayoutPanel.Controls.Add(this._categoryNameTextBox, 1, 0);
            this._categoryManagerTableLayoutPanel.Location = new System.Drawing.Point(6, 35);
            this._categoryManagerTableLayoutPanel.Name = "_categoryManagerTableLayoutPanel";
            this._categoryManagerTableLayoutPanel.RowCount = 4;
            this._categoryManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._categoryManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryManagerTableLayoutPanel.Size = new System.Drawing.Size(526, 372);
            this._categoryManagerTableLayoutPanel.TabIndex = 0;
            // 
            // _saveCategoryButton
            // 
            this._saveCategoryButton.AccessibleName = "_saveCategoryButton";
            this._saveCategoryButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._saveCategoryButton.Location = new System.Drawing.Point(396, 337);
            this._saveCategoryButton.Name = "_saveCategoryButton";
            this._saveCategoryButton.Size = new System.Drawing.Size(127, 32);
            this._saveCategoryButton.TabIndex = 0;
            this._saveCategoryButton.Text = "Add";
            this._saveCategoryButton.UseVisualStyleBackColor = true;
            this._saveCategoryButton.Click += new System.EventHandler(this.SaveCategory);
            // 
            // _mealOfCategoryListBox
            // 
            this._categoryManagerTableLayoutPanel.SetColumnSpan(this._mealOfCategoryListBox, 2);
            this._mealOfCategoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealOfCategoryListBox.FormattingEnabled = true;
            this._mealOfCategoryListBox.ItemHeight = 12;
            this._mealOfCategoryListBox.Location = new System.Drawing.Point(3, 77);
            this._mealOfCategoryListBox.Name = "_mealOfCategoryListBox";
            this._mealOfCategoryListBox.Size = new System.Drawing.Size(520, 254);
            this._mealOfCategoryListBox.TabIndex = 1;
            // 
            // _mealLabel
            // 
            this._mealLabel.AutoSize = true;
            this._mealLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealLabel.Location = new System.Drawing.Point(3, 37);
            this._mealLabel.Name = "_mealLabel";
            this._mealLabel.Size = new System.Drawing.Size(151, 37);
            this._mealLabel.TabIndex = 2;
            this._mealLabel.Text = "Meal(s) Using this Category :";
            this._mealLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _categoryNameLabel
            // 
            this._categoryNameLabel.AutoSize = true;
            this._categoryNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryNameLabel.Location = new System.Drawing.Point(3, 0);
            this._categoryNameLabel.Name = "_categoryNameLabel";
            this._categoryNameLabel.Size = new System.Drawing.Size(151, 37);
            this._categoryNameLabel.TabIndex = 3;
            this._categoryNameLabel.Text = "Category Name (*)";
            this._categoryNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _categoryNameTextBox
            // 
            this._categoryNameTextBox.AccessibleName = "_categoryNameTextBox";
            this._categoryNameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._categoryNameTextBox.Location = new System.Drawing.Point(160, 12);
            this._categoryNameTextBox.Name = "_categoryNameTextBox";
            this._categoryNameTextBox.Size = new System.Drawing.Size(363, 22);
            this._categoryNameTextBox.TabIndex = 4;
            // 
            // _addCategoryButton
            // 
            this._addCategoryButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._addCategoryButton.Location = new System.Drawing.Point(3, 380);
            this._addCategoryButton.Name = "_addCategoryButton";
            this._addCategoryButton.Size = new System.Drawing.Size(86, 36);
            this._addCategoryButton.TabIndex = 2;
            this._addCategoryButton.Text = "Add Category";
            this._addCategoryButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._addCategoryButton.UseVisualStyleBackColor = true;
            this._addCategoryButton.Click += new System.EventHandler(this.AddNewCategory);
            // 
            // _deleteCategoryButton
            // 
            this._deleteCategoryButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._deleteCategoryButton.Location = new System.Drawing.Point(214, 380);
            this._deleteCategoryButton.Name = "_deleteCategoryButton";
            this._deleteCategoryButton.Size = new System.Drawing.Size(143, 36);
            this._deleteCategoryButton.TabIndex = 3;
            this._deleteCategoryButton.Text = "Delete Selected Category";
            this._deleteCategoryButton.UseVisualStyleBackColor = true;
            this._deleteCategoryButton.Click += new System.EventHandler(this.DeleteCategory);
            // 
            // RestaurantSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 451);
            this.Controls.Add(this._manageTabControl);
            this.Name = "RestaurantSideForm";
            this.Text = "POSRestaurantSideForm";
            this._manageTabControl.ResumeLayout(false);
            this._mealTabPage.ResumeLayout(false);
            this._mealTableLayoutPanel.ResumeLayout(false);
            this._mealManagerGroupBox.ResumeLayout(false);
            this._mealManagerTableLayoutPanel.ResumeLayout(false);
            this._mealManagerTableLayoutPanel.PerformLayout();
            this._categoryTabPage.ResumeLayout(false);
            this._categoryTableLayoutPanel.ResumeLayout(false);
            this._categoryGroupBox.ResumeLayout(false);
            this._categoryManagerTableLayoutPanel.ResumeLayout(false);
            this._categoryManagerTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _manageTabControl;
        private System.Windows.Forms.TabPage _mealTabPage;
        private System.Windows.Forms.TableLayoutPanel _mealTableLayoutPanel;
        private System.Windows.Forms.ListBox _mealListBox;
        private System.Windows.Forms.GroupBox _mealManagerGroupBox;
        private System.Windows.Forms.Button _addMealButton;
        private System.Windows.Forms.Button _deleteMealButton;
        private System.Windows.Forms.TableLayoutPanel _mealManagerTableLayoutPanel;
        private System.Windows.Forms.Button _saveMealButton;
        private System.Windows.Forms.Label _mealNameLabel;
        private System.Windows.Forms.TabPage _categoryTabPage;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _categoryLabel;
        private System.Windows.Forms.Label _pathLabel;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.TextBox _descriptionTextBox;
        private System.Windows.Forms.TextBox _priceTextBox;
        private System.Windows.Forms.TextBox _mealNameTextBox;
        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.TextBox _pathTextBox;
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.TableLayoutPanel _categoryTableLayoutPanel;
        private System.Windows.Forms.ListBox _categoryListBox;
        private System.Windows.Forms.GroupBox _categoryGroupBox;
        private System.Windows.Forms.TableLayoutPanel _categoryManagerTableLayoutPanel;
        private System.Windows.Forms.Button _saveCategoryButton;
        private System.Windows.Forms.ListBox _mealOfCategoryListBox;
        private System.Windows.Forms.Label _mealLabel;
        private System.Windows.Forms.Label _categoryNameLabel;
        private System.Windows.Forms.TextBox _categoryNameTextBox;
        private System.Windows.Forms.Button _addCategoryButton;
        private System.Windows.Forms.Button _deleteCategoryButton;

    }
}