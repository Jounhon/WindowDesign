namespace DrawingForm
{
    partial class DrawingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingForm));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._circleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._smileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._firstToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._redoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._secondToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._thirdToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._fourthToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._showColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._colorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveToDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._colorDialog = new System.Windows.Forms.ColorDialog();
            this._toolStrip.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._circleToolStripButton,
            this._rectangleToolStripButton,
            this._smileToolStripButton,
            this._toolStripSeparator,
            this._deleteToolStripButton,
            this._firstToolStripSeparator,
            this._undoToolStripButton,
            this._redoToolStripButton,
            this._secondToolStripSeparator,
            this._clearToolStripButton,
            this._thirdToolStripSeparator,
            this._saveToolStripButton,
            this._fourthToolStripSeparator,
            this._showColorToolStripButton,
            this._colorToolStripButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 24);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(836, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _circleToolStripButton
            // 
            this._circleToolStripButton.Image = global::DrawingForm.Properties.Resources.circles;
            this._circleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleToolStripButton.Name = "_circleToolStripButton";
            this._circleToolStripButton.Size = new System.Drawing.Size(58, 22);
            this._circleToolStripButton.Text = "Circle";
            // 
            // _rectangleToolStripButton
            // 
            this._rectangleToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleToolStripButton.Image")));
            this._rectangleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleToolStripButton.Name = "_rectangleToolStripButton";
            this._rectangleToolStripButton.Size = new System.Drawing.Size(84, 22);
            this._rectangleToolStripButton.Text = "Rectangle";
            // 
            // _smileToolStripButton
            // 
            this._smileToolStripButton.Image = global::DrawingForm.Properties.Resources.smile;
            this._smileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._smileToolStripButton.Name = "_smileToolStripButton";
            this._smileToolStripButton.Size = new System.Drawing.Size(58, 22);
            this._smileToolStripButton.Text = "Smile";
            // 
            // _toolStripSeparator
            // 
            this._toolStripSeparator.Name = "_toolStripSeparator";
            this._toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // _deleteToolStripButton
            // 
            this._deleteToolStripButton.Image = global::DrawingForm.Properties.Resources.deletes;
            this._deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._deleteToolStripButton.Name = "_deleteToolStripButton";
            this._deleteToolStripButton.Size = new System.Drawing.Size(103, 22);
            this._deleteToolStripButton.Text = "Delete Shape";
            // 
            // _firstToolStripSeparator
            // 
            this._firstToolStripSeparator.Name = "_firstToolStripSeparator";
            this._firstToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // _undoToolStripButton
            // 
            this._undoToolStripButton.Image = global::DrawingForm.Properties.Resources.undo;
            this._undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoToolStripButton.Name = "_undoToolStripButton";
            this._undoToolStripButton.Size = new System.Drawing.Size(59, 22);
            this._undoToolStripButton.Text = "Undo";
            // 
            // _redoToolStripButton
            // 
            this._redoToolStripButton.Image = global::DrawingForm.Properties.Resources.redo;
            this._redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoToolStripButton.Name = "_redoToolStripButton";
            this._redoToolStripButton.Size = new System.Drawing.Size(58, 22);
            this._redoToolStripButton.Text = "Redo";
            // 
            // _secondToolStripSeparator
            // 
            this._secondToolStripSeparator.Name = "_secondToolStripSeparator";
            this._secondToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // _clearToolStripButton
            // 
            this._clearToolStripButton.Image = global::DrawingForm.Properties.Resources.cancel;
            this._clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._clearToolStripButton.Name = "_clearToolStripButton";
            this._clearToolStripButton.Size = new System.Drawing.Size(56, 22);
            this._clearToolStripButton.Text = "Clear";
            // 
            // _thirdToolStripSeparator
            // 
            this._thirdToolStripSeparator.Name = "_thirdToolStripSeparator";
            this._thirdToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // _saveToolStripButton
            // 
            this._saveToolStripButton.Image = global::DrawingForm.Properties.Resources.upload;
            this._saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveToolStripButton.Name = "_saveToolStripButton";
            this._saveToolStripButton.Size = new System.Drawing.Size(169, 22);
            this._saveToolStripButton.Text = "Save File to Google Drive";
            // 
            // _fourthToolStripSeparator
            // 
            this._fourthToolStripSeparator.Name = "_fourthToolStripSeparator";
            this._fourthToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // _showColorToolStripButton
            // 
            this._showColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._showColorToolStripButton.Enabled = false;
            this._showColorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_showColorToolStripButton.Image")));
            this._showColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._showColorToolStripButton.Name = "_showColorToolStripButton";
            this._showColorToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._showColorToolStripButton.Text = "    ";
            // 
            // _colorToolStripButton
            // 
            this._colorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._colorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_colorToolStripButton.Image")));
            this._colorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._colorToolStripButton.Name = "_colorToolStripButton";
            this._colorToolStripButton.Size = new System.Drawing.Size(89, 22);
            this._colorToolStripButton.Text = "Change Color";
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(836, 24);
            this._menuStrip.TabIndex = 1;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveToDriveToolStripMenuItem,
            this._exitToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this._fileToolStripMenuItem.Text = "檔案";
            // 
            // _saveToDriveToolStripMenuItem
            // 
            this._saveToDriveToolStripMenuItem.Image = global::DrawingForm.Properties.Resources.upload;
            this._saveToDriveToolStripMenuItem.Name = "_saveToDriveToolStripMenuItem";
            this._saveToDriveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this._saveToDriveToolStripMenuItem.Text = "儲存至Google Drive";
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Image = global::DrawingForm.Properties.Resources.power;
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this._exitToolStripMenuItem.Text = "離開";
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 491);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "DrawingForm";
            this.Text = "DrawAnywhere";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _circleToolStripButton;
        private System.Windows.Forms.ToolStripSeparator _firstToolStripSeparator;
        private System.Windows.Forms.ToolStripButton _clearToolStripButton;
        private System.Windows.Forms.ToolStripSeparator _thirdToolStripSeparator;
        private System.Windows.Forms.ToolStripButton _saveToolStripButton;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveToDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _rectangleToolStripButton;
        private System.Windows.Forms.ToolStripButton _smileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator _secondToolStripSeparator;
        private System.Windows.Forms.ToolStripButton _undoToolStripButton;
        private System.Windows.Forms.ToolStripButton _redoToolStripButton;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator;
        private System.Windows.Forms.ToolStripButton _deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator _fourthToolStripSeparator;
        private System.Windows.Forms.ColorDialog _colorDialog;
        private System.Windows.Forms.ToolStripButton _colorToolStripButton;
        private System.Windows.Forms.ToolStripButton _showColorToolStripButton;
    }
}