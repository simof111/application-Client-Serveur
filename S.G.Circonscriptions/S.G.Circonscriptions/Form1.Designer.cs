namespace S.G.Circonscriptions
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condidatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circonscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tranchAgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regionToolStripMenuItem,
            this.partiToolStripMenuItem,
            this.condidatToolStripMenuItem,
            this.circonscriptionToolStripMenuItem,
            this.provinceToolStripMenuItem,
            this.tranchAgeToolStripMenuItem});
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.goToToolStripMenuItem.Text = "Go to";
            // 
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.regionToolStripMenuItem.Text = "Region";
            this.regionToolStripMenuItem.Click += new System.EventHandler(this.regionToolStripMenuItem_Click);
            // 
            // partiToolStripMenuItem
            // 
            this.partiToolStripMenuItem.Name = "partiToolStripMenuItem";
            this.partiToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.partiToolStripMenuItem.Text = "Parti";
            this.partiToolStripMenuItem.Click += new System.EventHandler(this.partiToolStripMenuItem_Click);
            // 
            // condidatToolStripMenuItem
            // 
            this.condidatToolStripMenuItem.Name = "condidatToolStripMenuItem";
            this.condidatToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.condidatToolStripMenuItem.Text = "Condidat";
            this.condidatToolStripMenuItem.Click += new System.EventHandler(this.condidatToolStripMenuItem_Click);
            // 
            // circonscriptionToolStripMenuItem
            // 
            this.circonscriptionToolStripMenuItem.Name = "circonscriptionToolStripMenuItem";
            this.circonscriptionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.circonscriptionToolStripMenuItem.Text = "Circonscription";
            this.circonscriptionToolStripMenuItem.Click += new System.EventHandler(this.circonscriptionToolStripMenuItem_Click);
            // 
            // provinceToolStripMenuItem
            // 
            this.provinceToolStripMenuItem.Name = "provinceToolStripMenuItem";
            this.provinceToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.provinceToolStripMenuItem.Text = "Province";
            this.provinceToolStripMenuItem.Click += new System.EventHandler(this.provinceToolStripMenuItem_Click);
            // 
            // tranchAgeToolStripMenuItem
            // 
            this.tranchAgeToolStripMenuItem.Name = "tranchAgeToolStripMenuItem";
            this.tranchAgeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tranchAgeToolStripMenuItem.Text = "Tranch_Age";
            this.tranchAgeToolStripMenuItem.Click += new System.EventHandler(this.tranchAgeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 571);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condidatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circonscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tranchAgeToolStripMenuItem;
    }
}

