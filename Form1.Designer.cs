
namespace CovidApp
{
    partial class Form1
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
            this.registerNewCaseButton = new System.Windows.Forms.Button();
            this.viewAllRegisteredCasesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.searchByNameTextBox = new System.Windows.Forms.TextBox();
            this.seachButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.searchByAgeTextBox = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerNewCaseButton
            // 
            this.helpProvider1.SetHelpKeyword(this.registerNewCaseButton, "register");
            this.registerNewCaseButton.Location = new System.Drawing.Point(32, 25);
            this.registerNewCaseButton.Name = "registerNewCaseButton";
            this.helpProvider1.SetShowHelp(this.registerNewCaseButton, true);
            this.registerNewCaseButton.Size = new System.Drawing.Size(166, 23);
            this.registerNewCaseButton.TabIndex = 0;
            this.registerNewCaseButton.Text = "Register New Case";
            this.registerNewCaseButton.UseVisualStyleBackColor = true;
            this.registerNewCaseButton.Click += new System.EventHandler(this.registerNewCaseButton_Click);
            // 
            // viewAllRegisteredCasesButton
            // 
            this.helpProvider1.SetHelpKeyword(this.viewAllRegisteredCasesButton, "viewall");
            this.viewAllRegisteredCasesButton.Location = new System.Drawing.Point(32, 54);
            this.viewAllRegisteredCasesButton.Name = "viewAllRegisteredCasesButton";
            this.helpProvider1.SetShowHelp(this.viewAllRegisteredCasesButton, true);
            this.viewAllRegisteredCasesButton.Size = new System.Drawing.Size(214, 23);
            this.viewAllRegisteredCasesButton.TabIndex = 1;
            this.viewAllRegisteredCasesButton.Text = "View All Registered Cases";
            this.viewAllRegisteredCasesButton.UseVisualStyleBackColor = true;
            this.viewAllRegisteredCasesButton.Click += new System.EventHandler(this.viewAllRegisteredCasesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Results";
            // 
            // resultsPanel
            // 
            this.resultsPanel.Location = new System.Drawing.Point(35, 150);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(914, 230);
            this.resultsPanel.TabIndex = 4;
            this.resultsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.resultsPanel_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem,
            this.item2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1152, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(113, 450);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.item1ToolStripMenuItem.Text = "Gender Stats";
            this.item1ToolStripMenuItem.Click += new System.EventHandler(this.item1ToolStripMenuItem_Click);
            // 
            // item2ToolStripMenuItem
            // 
            this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
            this.item2ToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.item2ToolStripMenuItem.Text = "Age Stats";
            this.item2ToolStripMenuItem.Click += new System.EventHandler(this.item2ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search By Name";
            // 
            // searchByNameTextBox
            // 
            this.searchByNameTextBox.Location = new System.Drawing.Point(597, 22);
            this.searchByNameTextBox.Name = "searchByNameTextBox";
            this.searchByNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.searchByNameTextBox.TabIndex = 7;
            // 
            // seachButton
            // 
            this.helpProvider1.SetHelpKeyword(this.seachButton, "displaypreferable");
            this.seachButton.Location = new System.Drawing.Point(727, 44);
            this.seachButton.Name = "seachButton";
            this.helpProvider1.SetShowHelp(this.seachButton, true);
            this.seachButton.Size = new System.Drawing.Size(191, 23);
            this.seachButton.TabIndex = 8;
            this.seachButton.Text = "Search and View Results";
            this.seachButton.UseVisualStyleBackColor = true;
            this.seachButton.Click += new System.EventHandler(this.seachButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search By Age";
            // 
            // searchByAgeTextBox
            // 
            this.searchByAgeTextBox.Location = new System.Drawing.Point(597, 69);
            this.searchByAgeTextBox.Name = "searchByAgeTextBox";
            this.searchByAgeTextBox.Size = new System.Drawing.Size(100, 22);
            this.searchByAgeTextBox.TabIndex = 10;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\cp_di\\myWorkspaces\\visualStudioWorkspace\\CovidApp\\bin\\Debug\\covidapp_myh" +
    "elp.chm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 450);
            this.Controls.Add(this.searchByAgeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seachButton);
            this.Controls.Add(this.searchByNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultsPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewAllRegisteredCasesButton);
            this.Controls.Add(this.registerNewCaseButton);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerNewCaseButton;
        private System.Windows.Forms.Button viewAllRegisteredCasesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel resultsPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem item1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item2ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchByNameTextBox;
        private System.Windows.Forms.Button seachButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchByAgeTextBox;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

