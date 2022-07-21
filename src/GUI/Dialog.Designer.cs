namespace Draw.src.GUI
{
    partial class Dialog
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
            this.allValue_label = new System.Windows.Forms.Label();
            this.hight_label = new System.Windows.Forms.Label();
            this.allValue_textBox = new System.Windows.Forms.TextBox();
            this.hight_textBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // allValue_label
            // 
            this.allValue_label.AutoSize = true;
            this.allValue_label.Location = new System.Drawing.Point(133, 97);
            this.allValue_label.Name = "allValue_label";
            this.allValue_label.Size = new System.Drawing.Size(98, 20);
            this.allValue_label.TabIndex = 0;
            this.allValue_label.Text = "BorderWidth";
            // 
            // hight_label
            // 
            this.hight_label.AutoSize = true;
            this.hight_label.Location = new System.Drawing.Point(175, 234);
            this.hight_label.Name = "hight_label";
            this.hight_label.Size = new System.Drawing.Size(56, 20);
            this.hight_label.TabIndex = 1;
            this.hight_label.Text = "Height";
            // 
            // allValue_textBox
            // 
            this.allValue_textBox.Location = new System.Drawing.Point(338, 99);
            this.allValue_textBox.Name = "allValue_textBox";
            this.allValue_textBox.Size = new System.Drawing.Size(100, 26);
            this.allValue_textBox.TabIndex = 2;
            // 
            // hight_textBox
            // 
            this.hight_textBox.Location = new System.Drawing.Point(338, 234);
            this.hight_textBox.Name = "hight_textBox";
            this.hight_textBox.Size = new System.Drawing.Size(100, 26);
            this.hight_textBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(219, 341);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(231, 63);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "READY";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.hight_textBox);
            this.Controls.Add(this.allValue_textBox);
            this.Controls.Add(this.hight_label);
            this.Controls.Add(this.allValue_label);
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label allValue_label;
        private System.Windows.Forms.Label hight_label;
        private System.Windows.Forms.TextBox allValue_textBox;
        private System.Windows.Forms.TextBox hight_textBox;
        private System.Windows.Forms.Button okButton;
    }
}