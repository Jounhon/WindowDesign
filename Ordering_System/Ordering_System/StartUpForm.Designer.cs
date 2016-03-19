namespace Ordering_System
{
    partial class StartUpForm
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
            this._backButton = new System.Windows.Forms.Button();
            this._frontButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _backButton
            // 
            this._backButton.Location = new System.Drawing.Point(210, 30);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(171, 65);
            this._backButton.TabIndex = 0;
            this._backButton.Text = "Restaurant ( backend )";
            this._backButton.UseVisualStyleBackColor = true;
            this._backButton.Click += new System.EventHandler(this.ClickBackButton);
            // 
            // _frontButton
            // 
            this._frontButton.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._frontButton.Location = new System.Drawing.Point(12, 30);
            this._frontButton.Name = "_frontButton";
            this._frontButton.Size = new System.Drawing.Size(171, 65);
            this._frontButton.TabIndex = 0;
            this._frontButton.Text = "Customer ( frontend )";
            this._frontButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._frontButton.UseVisualStyleBackColor = true;
            this._frontButton.Click += new System.EventHandler(this.ClickFrontButton);
            // 
            // _exitButton
            // 
            this._exitButton.Location = new System.Drawing.Point(114, 122);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(171, 47);
            this._exitButton.TabIndex = 0;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ClickExitButton);
            // 
            // StartUpForm
            // 
            this.AccessibleName = "StartUpForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 181);
            this.Controls.Add(this._frontButton);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._backButton);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Button _frontButton;
        private System.Windows.Forms.Button _exitButton;
    }
}