namespace Control_Proc
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
            this.rbsection = new System.Windows.Forms.RadioButton();
            this.rbajout = new System.Windows.Forms.RadioButton();
            this.rbmodifstag = new System.Windows.Forms.RadioButton();
            this.rbmodifnot = new System.Windows.Forms.RadioButton();
            this.cmbsupprimer = new System.Windows.Forms.ComboBox();
            this.cmbajout = new System.Windows.Forms.ComboBox();
            this.cmbmodifstag = new System.Windows.Forms.ComboBox();
            this.cmbmodifnote = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbsection
            // 
            this.rbsection.AutoSize = true;
            this.rbsection.Location = new System.Drawing.Point(244, 99);
            this.rbsection.Name = "rbsection";
            this.rbsection.Size = new System.Drawing.Size(111, 17);
            this.rbsection.TabIndex = 0;
            this.rbsection.TabStop = true;
            this.rbsection.Text = "Supprimer Section";
            this.rbsection.UseVisualStyleBackColor = true;
            // 
            // rbajout
            // 
            this.rbajout.AutoSize = true;
            this.rbajout.Location = new System.Drawing.Point(392, 99);
            this.rbajout.Name = "rbajout";
            this.rbajout.Size = new System.Drawing.Size(84, 17);
            this.rbajout.TabIndex = 1;
            this.rbajout.TabStop = true;
            this.rbajout.Text = "Ajouter Note";
            this.rbajout.UseVisualStyleBackColor = true;
            // 
            // rbmodifstag
            // 
            this.rbmodifstag.AutoSize = true;
            this.rbmodifstag.Location = new System.Drawing.Point(681, 99);
            this.rbmodifstag.Name = "rbmodifstag";
            this.rbmodifstag.Size = new System.Drawing.Size(106, 17);
            this.rbmodifstag.TabIndex = 3;
            this.rbmodifstag.TabStop = true;
            this.rbmodifstag.Text = "Modifier Stagiaire";
            this.rbmodifstag.UseVisualStyleBackColor = true;
            // 
            // rbmodifnot
            // 
            this.rbmodifnot.AutoSize = true;
            this.rbmodifnot.Location = new System.Drawing.Point(533, 99);
            this.rbmodifnot.Name = "rbmodifnot";
            this.rbmodifnot.Size = new System.Drawing.Size(88, 17);
            this.rbmodifnot.TabIndex = 2;
            this.rbmodifnot.TabStop = true;
            this.rbmodifnot.Text = "Modifier Note";
            this.rbmodifnot.UseVisualStyleBackColor = true;
            // 
            // cmbsupprimer
            // 
            this.cmbsupprimer.FormattingEnabled = true;
            this.cmbsupprimer.Location = new System.Drawing.Point(244, 143);
            this.cmbsupprimer.Name = "cmbsupprimer";
            this.cmbsupprimer.Size = new System.Drawing.Size(116, 21);
            this.cmbsupprimer.TabIndex = 4;
            this.cmbsupprimer.SelectedIndexChanged += new System.EventHandler(this.cmbsupprimer_SelectedIndexChanged);
            // 
            // cmbajout
            // 
            this.cmbajout.FormattingEnabled = true;
            this.cmbajout.Location = new System.Drawing.Point(392, 143);
            this.cmbajout.Name = "cmbajout";
            this.cmbajout.Size = new System.Drawing.Size(116, 21);
            this.cmbajout.TabIndex = 5;
            // 
            // cmbmodifstag
            // 
            this.cmbmodifstag.FormattingEnabled = true;
            this.cmbmodifstag.Location = new System.Drawing.Point(681, 143);
            this.cmbmodifstag.Name = "cmbmodifstag";
            this.cmbmodifstag.Size = new System.Drawing.Size(116, 21);
            this.cmbmodifstag.TabIndex = 7;
            // 
            // cmbmodifnote
            // 
            this.cmbmodifnote.FormattingEnabled = true;
            this.cmbmodifnote.Location = new System.Drawing.Point(533, 143);
            this.cmbmodifnote.Name = "cmbmodifnote";
            this.cmbmodifnote.Size = new System.Drawing.Size(116, 21);
            this.cmbmodifnote.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(244, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(553, 235);
            this.dataGridView1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 601);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbmodifstag);
            this.Controls.Add(this.cmbmodifnote);
            this.Controls.Add(this.cmbajout);
            this.Controls.Add(this.cmbsupprimer);
            this.Controls.Add(this.rbmodifstag);
            this.Controls.Add(this.rbmodifnot);
            this.Controls.Add(this.rbajout);
            this.Controls.Add(this.rbsection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbsection;
        private System.Windows.Forms.RadioButton rbajout;
        private System.Windows.Forms.RadioButton rbmodifstag;
        private System.Windows.Forms.RadioButton rbmodifnot;
        private System.Windows.Forms.ComboBox cmbsupprimer;
        private System.Windows.Forms.ComboBox cmbajout;
        private System.Windows.Forms.ComboBox cmbmodifstag;
        private System.Windows.Forms.ComboBox cmbmodifnote;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

