namespace Ordering_System
{
    partial class POS
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MealGroupBox = new System.Windows.Forms.GroupBox();
            this.recordDataGridView = new System.Windows.Forms.DataGridView();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.MealTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pageLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.preButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.MealGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordDataGridView)).BeginInit();
            this.MealTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MealGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.recordDataGridView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TotalLabel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 471);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MealGroupBox
            // 
            this.MealGroupBox.Controls.Add(this.MealTableLayoutPanel);
            this.MealGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MealGroupBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MealGroupBox.Location = new System.Drawing.Point(3, 3);
            this.MealGroupBox.Name = "MealGroupBox";
            this.tableLayoutPanel1.SetRowSpan(this.MealGroupBox, 2);
            this.MealGroupBox.Size = new System.Drawing.Size(403, 465);
            this.MealGroupBox.TabIndex = 0;
            this.MealGroupBox.TabStop = false;
            this.MealGroupBox.Text = "Meal";
            // 
            // recordDataGridView
            // 
            this.recordDataGridView.AllowUserToAddRows = false;
            this.recordDataGridView.AllowUserToDeleteRows = false;
            this.recordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordDataGridView.Location = new System.Drawing.Point(412, 3);
            this.recordDataGridView.Name = "recordDataGridView";
            this.recordDataGridView.ReadOnly = true;
            this.recordDataGridView.RowTemplate.Height = 24;
            this.recordDataGridView.Size = new System.Drawing.Size(403, 417);
            this.recordDataGridView.TabIndex = 1;
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalLabel.Location = new System.Drawing.Point(412, 423);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(403, 48);
            this.TotalLabel.TabIndex = 2;
            this.TotalLabel.Text = "Total";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MealTableLayoutPanel
            // 
            this.MealTableLayoutPanel.ColumnCount = 3;
            this.MealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MealTableLayoutPanel.Controls.Add(this.pageLabel, 0, 3);
            this.MealTableLayoutPanel.Controls.Add(this.nextButton, 2, 3);
            this.MealTableLayoutPanel.Controls.Add(this.preButton, 1, 3);
            this.MealTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MealTableLayoutPanel.Location = new System.Drawing.Point(3, 33);
            this.MealTableLayoutPanel.Margin = new System.Windows.Forms.Padding(10);
            this.MealTableLayoutPanel.Name = "MealTableLayoutPanel";
            this.MealTableLayoutPanel.RowCount = 4;
            this.MealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MealTableLayoutPanel.Size = new System.Drawing.Size(397, 429);
            this.MealTableLayoutPanel.TabIndex = 0;
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pageLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageLabel.Location = new System.Drawing.Point(3, 384);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(52, 45);
            this.pageLabel.TabIndex = 0;
            this.pageLabel.Text = "page:";
            this.pageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nextButton
            // 
            this.nextButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.nextButton.Location = new System.Drawing.Point(344, 387);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(50, 39);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // preButton
            // 
            this.preButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.preButton.Location = new System.Drawing.Point(211, 387);
            this.preButton.Name = "preButton";
            this.preButton.Size = new System.Drawing.Size(50, 39);
            this.preButton.TabIndex = 2;
            this.preButton.Text = "<";
            this.preButton.UseVisualStyleBackColor = true;
            this.preButton.Click += new System.EventHandler(this.preButton_Click);
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "POS";
            this.Text = "POS";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MealGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordDataGridView)).EndInit();
            this.MealTableLayoutPanel.ResumeLayout(false);
            this.MealTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox MealGroupBox;
        private System.Windows.Forms.DataGridView recordDataGridView;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.TableLayoutPanel MealTableLayoutPanel;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button preButton;
    }
}