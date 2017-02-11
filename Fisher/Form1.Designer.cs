namespace Fisher
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtLogi = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtSystem = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtxtWynik = new System.Windows.Forms.RichTextBox();
            this.btnWczytaj = new System.Windows.Forms.Button();
            this.btnWyjscie = new System.Windows.Forms.Button();
            this.btnLicz = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtLogi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logi:";
            // 
            // rtxtLogi
            // 
            this.rtxtLogi.Location = new System.Drawing.Point(6, 21);
            this.rtxtLogi.Name = "rtxtLogi";
            this.rtxtLogi.Size = new System.Drawing.Size(484, 95);
            this.rtxtLogi.TabIndex = 0;
            this.rtxtLogi.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtSystem);
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 203);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Decyzyjny:";
            // 
            // rtxtSystem
            // 
            this.rtxtSystem.Location = new System.Drawing.Point(6, 21);
            this.rtxtSystem.Name = "rtxtSystem";
            this.rtxtSystem.Size = new System.Drawing.Size(297, 176);
            this.rtxtSystem.TabIndex = 0;
            this.rtxtSystem.Text = "";
            this.rtxtSystem.TextChanged += new System.EventHandler(this.rtxtSystem_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtxtWynik);
            this.groupBox3.Location = new System.Drawing.Point(327, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 203);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wynik";
            // 
            // rtxtWynik
            // 
            this.rtxtWynik.Location = new System.Drawing.Point(6, 21);
            this.rtxtWynik.Name = "rtxtWynik";
            this.rtxtWynik.Size = new System.Drawing.Size(303, 176);
            this.rtxtWynik.TabIndex = 0;
            this.rtxtWynik.Text = "";
            this.rtxtWynik.Visible = false;
            // 
            // btnWczytaj
            // 
            this.btnWczytaj.Location = new System.Drawing.Point(514, 14);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(128, 36);
            this.btnWczytaj.TabIndex = 3;
            this.btnWczytaj.Text = "Wczytaj";
            this.btnWczytaj.UseVisualStyleBackColor = true;
            this.btnWczytaj.Click += new System.EventHandler(this.btnWczytaj_Click);
            // 
            // btnWyjscie
            // 
            this.btnWyjscie.Location = new System.Drawing.Point(514, 98);
            this.btnWyjscie.Name = "btnWyjscie";
            this.btnWyjscie.Size = new System.Drawing.Size(128, 36);
            this.btnWyjscie.TabIndex = 4;
            this.btnWyjscie.Text = "Wyjście";
            this.btnWyjscie.UseVisualStyleBackColor = true;
            this.btnWyjscie.Click += new System.EventHandler(this.btnWyjscie_Click);
            // 
            // btnLicz
            // 
            this.btnLicz.Enabled = false;
            this.btnLicz.Location = new System.Drawing.Point(514, 56);
            this.btnLicz.Name = "btnLicz";
            this.btnLicz.Size = new System.Drawing.Size(128, 36);
            this.btnLicz.TabIndex = 5;
            this.btnLicz.Text = "Licz";
            this.btnLicz.UseVisualStyleBackColor = true;
            this.btnLicz.Click += new System.EventHandler(this.btnLicz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 355);
            this.Controls.Add(this.btnLicz);
            this.Controls.Add(this.btnWyjscie);
            this.Controls.Add(this.btnWczytaj);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Fisher - Damian Likszo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtxtLogi;
        private System.Windows.Forms.RichTextBox rtxtSystem;
        private System.Windows.Forms.RichTextBox rtxtWynik;
        private System.Windows.Forms.Button btnWczytaj;
        private System.Windows.Forms.Button btnWyjscie;
        private System.Windows.Forms.Button btnLicz;
    }
}

