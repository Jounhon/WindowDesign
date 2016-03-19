namespace Ordering_System
{
    partial class CustomerSideForm
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
            this._boxTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._pageTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._nextButton = new System.Windows.Forms.Button();
            this._pageLabel = new System.Windows.Forms.Label();
            this._previousButton = new System.Windows.Forms.Button();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this._totalLabel = new System.Windows.Forms.Label();
            this._mealGroupBox = new System.Windows.Forms.GroupBox();
            this._recordDataGridView = new System.Windows.Forms.DataGridView();
            this._boxTableLayoutPanel.SuspendLayout();
            this._pageTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._recordDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _boxTableLayoutPanel
            // 
            this._boxTableLayoutPanel.ColumnCount = 2;
            this._boxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._boxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._boxTableLayoutPanel.Controls.Add(this._pageTableLayoutPanel, 0, 1);
            this._boxTableLayoutPanel.Controls.Add(this._totalLabel, 1, 1);
            this._boxTableLayoutPanel.Controls.Add(this._mealGroupBox, 0, 0);
            this._boxTableLayoutPanel.Controls.Add(this._recordDataGridView, 1, 0);
            this._boxTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._boxTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._boxTableLayoutPanel.Name = "_boxTableLayoutPanel";
            this._boxTableLayoutPanel.RowCount = 2;
            this._boxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._boxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._boxTableLayoutPanel.Size = new System.Drawing.Size(1041, 609);
            this._boxTableLayoutPanel.TabIndex = 1;
            // 
            // _pageTableLayoutPanel
            // 
            this._pageTableLayoutPanel.ColumnCount = 3;
            this._pageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._pageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._pageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._pageTableLayoutPanel.Controls.Add(this._nextButton, 2, 1);
            this._pageTableLayoutPanel.Controls.Add(this._pageLabel, 0, 1);
            this._pageTableLayoutPanel.Controls.Add(this._previousButton, 1, 1);
            this._pageTableLayoutPanel.Controls.Add(this._descriptionTextBox, 0, 0);
            this._pageTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pageTableLayoutPanel.Location = new System.Drawing.Point(3, 490);
            this._pageTableLayoutPanel.Name = "_pageTableLayoutPanel";
            this._pageTableLayoutPanel.RowCount = 2;
            this._pageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._pageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._pageTableLayoutPanel.Size = new System.Drawing.Size(514, 116);
            this._pageTableLayoutPanel.TabIndex = 7;
            // 
            // _nextButton
            // 
            this._nextButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._nextButton.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._nextButton.Location = new System.Drawing.Point(436, 84);
            this._nextButton.Name = "_nextButton";
            this._nextButton.Size = new System.Drawing.Size(75, 29);
            this._nextButton.TabIndex = 8;
            this._nextButton.Text = ">";
            this._nextButton.UseVisualStyleBackColor = true;
            this._nextButton.Click += new System.EventHandler(this.GoNextPageButtonClick);
            // 
            // _pageLabel
            // 
            this._pageLabel.AccessibleName = "_pageLabel";
            this._pageLabel.AutoSize = true;
            this._pageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pageLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._pageLabel.Location = new System.Drawing.Point(3, 81);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(165, 35);
            this._pageLabel.TabIndex = 6;
            this._pageLabel.Text = "Page : 1 / 1";
            this._pageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _previousButton
            // 
            this._previousButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._previousButton.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._previousButton.Location = new System.Drawing.Point(264, 84);
            this._previousButton.Name = "_previousButton";
            this._previousButton.Size = new System.Drawing.Size(75, 29);
            this._previousButton.TabIndex = 7;
            this._previousButton.Text = "<";
            this._previousButton.UseVisualStyleBackColor = true;
            this._previousButton.Click += new System.EventHandler(this.GoPreviousPageButtonClick);
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.AccessibleName = "_descriptionTextBox";
            this._pageTableLayoutPanel.SetColumnSpan(this._descriptionTextBox, 3);
            this._descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._descriptionTextBox.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._descriptionTextBox.Location = new System.Drawing.Point(3, 3);
            this._descriptionTextBox.Multiline = true;
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.ReadOnly = true;
            this._descriptionTextBox.Size = new System.Drawing.Size(508, 75);
            this._descriptionTextBox.TabIndex = 9;
            // 
            // _totalLabel
            // 
            this._totalLabel.AccessibleName = "_totalLabel";
            this._totalLabel.AutoSize = true;
            this._totalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._totalLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._totalLabel.Location = new System.Drawing.Point(523, 487);
            this._totalLabel.Name = "_totalLabel";
            this._totalLabel.Size = new System.Drawing.Size(515, 122);
            this._totalLabel.TabIndex = 5;
            this._totalLabel.Text = "Total : 0 NTD.";
            this._totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _mealGroupBox
            // 
            this._mealGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealGroupBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._mealGroupBox.Location = new System.Drawing.Point(3, 3);
            this._mealGroupBox.Name = "_mealGroupBox";
            this._mealGroupBox.Size = new System.Drawing.Size(514, 481);
            this._mealGroupBox.TabIndex = 0;
            this._mealGroupBox.TabStop = false;
            this._mealGroupBox.Text = "Meal";
            // 
            // _recordDataGridView
            // 
            this._recordDataGridView.AccessibleName = "_recordDataGridView";
            this._recordDataGridView.AllowUserToAddRows = false;
            this._recordDataGridView.AllowUserToDeleteRows = false;
            this._recordDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._recordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._recordDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._recordDataGridView.Location = new System.Drawing.Point(523, 3);
            this._recordDataGridView.Name = "_recordDataGridView";
            this._recordDataGridView.RowHeadersVisible = false;
            this._recordDataGridView.RowTemplate.Height = 24;
            this._recordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._recordDataGridView.Size = new System.Drawing.Size(515, 481);
            this._recordDataGridView.TabIndex = 0;
            // 
            // CustomerSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 609);
            this.Controls.Add(this._boxTableLayoutPanel);
            this.Name = "CustomerSideForm";
            this.Text = "POSCustomerSideForm";
            this._boxTableLayoutPanel.ResumeLayout(false);
            this._boxTableLayoutPanel.PerformLayout();
            this._pageTableLayoutPanel.ResumeLayout(false);
            this._pageTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._recordDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _boxTableLayoutPanel;
        private System.Windows.Forms.GroupBox _mealGroupBox;
        private System.Windows.Forms.DataGridView _recordDataGridView;
        private System.Windows.Forms.Label _totalLabel;
        private System.Windows.Forms.TableLayoutPanel _pageTableLayoutPanel;
        private System.Windows.Forms.Button _nextButton;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.Button _previousButton;
        private System.Windows.Forms.TextBox _descriptionTextBox;
    }
}