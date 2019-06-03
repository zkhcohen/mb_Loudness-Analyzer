namespace MusicBeePlugin
{
    partial class SettingsPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ILbox = new System.Windows.Forms.ComboBox();
            this.LRTbox = new System.Windows.Forms.ComboBox();
            this.LRALbox = new System.Windows.Forms.ComboBox();
            this.LRAHbox = new System.Windows.Forms.ComboBox();
            this.Pbox = new System.Windows.Forms.ComboBox();
            this.DRbox = new System.Windows.Forms.ComboBox();
            this.ILTbox = new System.Windows.Forms.ComboBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.ALbox = new System.Windows.Forms.ComboBox();
            this.CLbox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "[I] Integrated Loudness (LUFS):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Threshold (LUFS):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "[LRA] Dynamic Range (LU):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Threshold (LUFS):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(288, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "[LRA Low] Minimum Dynamic Range (LUFS):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "[LRA High] Maximum Dynamic Range (LUFS):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 453);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "[Peak] Peak Loudness (dBFS):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Integrated Loudness";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Loudness Range";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 409);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "True Peak";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(479, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Associated Variable";
            // 
            // ILbox
            // 
            this.ILbox.FormattingEnabled = true;
            this.ILbox.Location = new System.Drawing.Point(404, 70);
            this.ILbox.Name = "ILbox";
            this.ILbox.Size = new System.Drawing.Size(281, 24);
            this.ILbox.TabIndex = 19;
            this.ILbox.SelectedIndexChanged += new System.EventHandler(this.ILbox_SelectedIndexChanged);
            // 
            // LRTbox
            // 
            this.LRTbox.FormattingEnabled = true;
            this.LRTbox.Location = new System.Drawing.Point(404, 259);
            this.LRTbox.Name = "LRTbox";
            this.LRTbox.Size = new System.Drawing.Size(281, 24);
            this.LRTbox.TabIndex = 21;
            this.LRTbox.SelectedIndexChanged += new System.EventHandler(this.LRTbox_SelectedIndexChanged);
            // 
            // LRALbox
            // 
            this.LRALbox.FormattingEnabled = true;
            this.LRALbox.Location = new System.Drawing.Point(404, 303);
            this.LRALbox.Name = "LRALbox";
            this.LRALbox.Size = new System.Drawing.Size(281, 24);
            this.LRALbox.TabIndex = 22;
            this.LRALbox.SelectedIndexChanged += new System.EventHandler(this.LRALbox_SelectedIndexChanged);
            // 
            // LRAHbox
            // 
            this.LRAHbox.FormattingEnabled = true;
            this.LRAHbox.Location = new System.Drawing.Point(404, 350);
            this.LRAHbox.Name = "LRAHbox";
            this.LRAHbox.Size = new System.Drawing.Size(281, 24);
            this.LRAHbox.TabIndex = 23;
            this.LRAHbox.SelectedIndexChanged += new System.EventHandler(this.LRAHbox_SelectedIndexChanged);
            // 
            // Pbox
            // 
            this.Pbox.FormattingEnabled = true;
            this.Pbox.Location = new System.Drawing.Point(404, 446);
            this.Pbox.Name = "Pbox";
            this.Pbox.Size = new System.Drawing.Size(281, 24);
            this.Pbox.TabIndex = 24;
            this.Pbox.SelectedIndexChanged += new System.EventHandler(this.Pbox_SelectedIndexChanged);
            // 
            // DRbox
            // 
            this.DRbox.FormattingEnabled = true;
            this.DRbox.Location = new System.Drawing.Point(404, 216);
            this.DRbox.Name = "DRbox";
            this.DRbox.Size = new System.Drawing.Size(281, 24);
            this.DRbox.TabIndex = 25;
            this.DRbox.SelectedIndexChanged += new System.EventHandler(this.DRbox_SelectedIndexChanged);
            // 
            // ILTbox
            // 
            this.ILTbox.FormattingEnabled = true;
            this.ILTbox.Location = new System.Drawing.Point(404, 117);
            this.ILTbox.Name = "ILTbox";
            this.ILTbox.Size = new System.Drawing.Size(281, 24);
            this.ILTbox.TabIndex = 26;
            this.ILTbox.SelectedIndexChanged += new System.EventHandler(this.ILTbox_SelectedIndexChanged);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(34, 633);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(651, 62);
            this.saveSettingsButton.TabIndex = 27;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // ALbox
            // 
            this.ALbox.FormattingEnabled = true;
            this.ALbox.Location = new System.Drawing.Point(404, 516);
            this.ALbox.Name = "ALbox";
            this.ALbox.Size = new System.Drawing.Size(281, 24);
            this.ALbox.TabIndex = 28;
            // 
            // CLbox
            // 
            this.CLbox.FormattingEnabled = true;
            this.CLbox.Location = new System.Drawing.Point(404, 561);
            this.CLbox.Name = "CLbox";
            this.CLbox.Size = new System.Drawing.Size(281, 24);
            this.CLbox.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 523);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(234, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Average Integration Loudness (LU):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 568);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(283, 17);
            this.label13.TabIndex = 31;
            this.label13.Text = "[IL + Track Gain] Current Loudness (LUFS):";
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 724);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CLbox);
            this.Controls.Add(this.ALbox);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.ILTbox);
            this.Controls.Add(this.DRbox);
            this.Controls.Add(this.Pbox);
            this.Controls.Add(this.LRAHbox);
            this.Controls.Add(this.LRALbox);
            this.Controls.Add(this.LRTbox);
            this.Controls.Add(this.ILbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsPanel";
            this.Text = "EBU R128 Loudness Analyzer Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ILbox;
        private System.Windows.Forms.ComboBox LRTbox;
        private System.Windows.Forms.ComboBox LRALbox;
        private System.Windows.Forms.ComboBox LRAHbox;
        private System.Windows.Forms.ComboBox Pbox;
        private System.Windows.Forms.ComboBox DRbox;
        private System.Windows.Forms.ComboBox ILTbox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.ComboBox ALbox;
        private System.Windows.Forms.ComboBox CLbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
    }
}