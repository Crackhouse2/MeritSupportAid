namespace MeritSupportAid
{
    partial class MSA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSA));
            this.MMT = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersLoggedOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MMT.SuspendLayout();
            this.SuspendLayout();
            // 
            // MMT
            // 
            this.MMT.BackColor = System.Drawing.Color.Transparent;
            this.MMT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.employeesToolStripMenuItem});
            this.MMT.Location = new System.Drawing.Point(0, 0);
            this.MMT.Name = "MMT";
            this.MMT.Size = new System.Drawing.Size(620, 24);
            this.MMT.TabIndex = 0;
            this.MMT.Text = "MMT";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersLoggedOnToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownClosed += new System.EventHandler(this.MenuClear);
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.ResetTextBox); //Add this to all primary source trees
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.MenuDrop);
            // 
            // usersLoggedOnToolStripMenuItem
            // 
            this.usersLoggedOnToolStripMenuItem.Name = "usersLoggedOnToolStripMenuItem";
            this.usersLoggedOnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usersLoggedOnToolStripMenuItem.Text = "Users Logged On";
            this.usersLoggedOnToolStripMenuItem.DropDownClosed += new System.EventHandler(this.MenuClear);
            this.usersLoggedOnToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            //this.usersLoggedOnToolStripMenuItem.Click += new System.EventHandler(this.MenuDrop);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.DropDownClosed += new System.EventHandler(this.MenuClear);
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuDrop);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewEmployeeToolStripMenuItem});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // viewEmployeeToolStripMenuItem
            // 
            this.viewEmployeeToolStripMenuItem.Name = "viewEmployeeToolStripMenuItem";
            this.viewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.viewEmployeeToolStripMenuItem.Text = "View Employee";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(396, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 1;
            // 
            // MSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(620, 140);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MMT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MMT;
            this.MaximizeBox = false;
            this.Name = "MSA";
            this.Text = "MSA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MMT.ResumeLayout(false);
            this.MMT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MMT;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersLoggedOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEmployeeToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

