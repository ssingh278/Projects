namespace Balzz
{
    partial class Select_Difficulty
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
            this.UI_Diificulty_Gbx = new System.Windows.Forms.GroupBox();
            this.UI_Hard_Rbn = new System.Windows.Forms.RadioButton();
            this.UI_Medium_Rbn = new System.Windows.Forms.RadioButton();
            this.UI_Easy_Rbn = new System.Windows.Forms.RadioButton();
            this.UI_OK_btn = new System.Windows.Forms.Button();
            this.UI_Cancel_btn = new System.Windows.Forms.Button();
            this.UI_Diificulty_Gbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_Diificulty_Gbx
            // 
            this.UI_Diificulty_Gbx.Controls.Add(this.UI_Hard_Rbn);
            this.UI_Diificulty_Gbx.Controls.Add(this.UI_Medium_Rbn);
            this.UI_Diificulty_Gbx.Controls.Add(this.UI_Easy_Rbn);
            this.UI_Diificulty_Gbx.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Diificulty_Gbx.Location = new System.Drawing.Point(21, 27);
            this.UI_Diificulty_Gbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Diificulty_Gbx.Name = "UI_Diificulty_Gbx";
            this.UI_Diificulty_Gbx.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Diificulty_Gbx.Size = new System.Drawing.Size(263, 207);
            this.UI_Diificulty_Gbx.TabIndex = 0;
            this.UI_Diificulty_Gbx.TabStop = false;
            this.UI_Diificulty_Gbx.Text = "Difficulty";
            // 
            // UI_Hard_Rbn
            // 
            this.UI_Hard_Rbn.AutoSize = true;
            this.UI_Hard_Rbn.Location = new System.Drawing.Point(19, 158);
            this.UI_Hard_Rbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Hard_Rbn.Name = "UI_Hard_Rbn";
            this.UI_Hard_Rbn.Size = new System.Drawing.Size(68, 26);
            this.UI_Hard_Rbn.TabIndex = 2;
            this.UI_Hard_Rbn.TabStop = true;
            this.UI_Hard_Rbn.Text = "Hard";
            this.UI_Hard_Rbn.UseVisualStyleBackColor = true;
            // 
            // UI_Medium_Rbn
            // 
            this.UI_Medium_Rbn.AutoSize = true;
            this.UI_Medium_Rbn.Location = new System.Drawing.Point(19, 100);
            this.UI_Medium_Rbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Medium_Rbn.Name = "UI_Medium_Rbn";
            this.UI_Medium_Rbn.Size = new System.Drawing.Size(94, 26);
            this.UI_Medium_Rbn.TabIndex = 1;
            this.UI_Medium_Rbn.TabStop = true;
            this.UI_Medium_Rbn.Text = "Medium";
            this.UI_Medium_Rbn.UseVisualStyleBackColor = true;
            // 
            // UI_Easy_Rbn
            // 
            this.UI_Easy_Rbn.AutoSize = true;
            this.UI_Easy_Rbn.Checked = true;
            this.UI_Easy_Rbn.Location = new System.Drawing.Point(19, 42);
            this.UI_Easy_Rbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Easy_Rbn.Name = "UI_Easy_Rbn";
            this.UI_Easy_Rbn.Size = new System.Drawing.Size(64, 26);
            this.UI_Easy_Rbn.TabIndex = 0;
            this.UI_Easy_Rbn.TabStop = true;
            this.UI_Easy_Rbn.Text = "Easy";
            this.UI_Easy_Rbn.UseVisualStyleBackColor = true;
            // 
            // UI_OK_btn
            // 
            this.UI_OK_btn.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_OK_btn.Location = new System.Drawing.Point(21, 250);
            this.UI_OK_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_OK_btn.Name = "UI_OK_btn";
            this.UI_OK_btn.Size = new System.Drawing.Size(117, 34);
            this.UI_OK_btn.TabIndex = 3;
            this.UI_OK_btn.Text = "OK";
            this.UI_OK_btn.UseVisualStyleBackColor = true;
            this.UI_OK_btn.Click += new System.EventHandler(this.UI_OK_btn_Click);
            // 
            // UI_Cancel_btn
            // 
            this.UI_Cancel_btn.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Cancel_btn.Location = new System.Drawing.Point(192, 250);
            this.UI_Cancel_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Cancel_btn.Name = "UI_Cancel_btn";
            this.UI_Cancel_btn.Size = new System.Drawing.Size(119, 34);
            this.UI_Cancel_btn.TabIndex = 4;
            this.UI_Cancel_btn.Text = "Cancel";
            this.UI_Cancel_btn.UseVisualStyleBackColor = true;
            this.UI_Cancel_btn.Click += new System.EventHandler(this.UI_Cancel_btn_Click);
            // 
            // Select_Difficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 306);
            this.Controls.Add(this.UI_OK_btn);
            this.Controls.Add(this.UI_Cancel_btn);
            this.Controls.Add(this.UI_Diificulty_Gbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Select_Difficulty";
            this.Text = "Select Difficulty";
            this.UI_Diificulty_Gbx.ResumeLayout(false);
            this.UI_Diificulty_Gbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UI_Diificulty_Gbx;
        private System.Windows.Forms.RadioButton UI_Hard_Rbn;
        private System.Windows.Forms.RadioButton UI_Medium_Rbn;
        private System.Windows.Forms.RadioButton UI_Easy_Rbn;
        private System.Windows.Forms.Button UI_OK_btn;
        private System.Windows.Forms.Button UI_Cancel_btn;
    }
}