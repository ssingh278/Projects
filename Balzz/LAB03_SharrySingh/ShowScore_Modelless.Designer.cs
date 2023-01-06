namespace Balzz
{
    partial class ShowScore_Modelless
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
            this.UI_Score_lbl = new System.Windows.Forms.Label();
            this.UI_TotalScore_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_Score_lbl
            // 
            this.UI_Score_lbl.AutoSize = true;
            this.UI_Score_lbl.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Score_lbl.Location = new System.Drawing.Point(75, 86);
            this.UI_Score_lbl.Name = "UI_Score_lbl";
            this.UI_Score_lbl.Size = new System.Drawing.Size(69, 26);
            this.UI_Score_lbl.TabIndex = 0;
            this.UI_Score_lbl.Text = "Score:";
            // 
            // UI_TotalScore_Label
            // 
            this.UI_TotalScore_Label.AutoSize = true;
            this.UI_TotalScore_Label.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_TotalScore_Label.Location = new System.Drawing.Point(254, 86);
            this.UI_TotalScore_Label.Name = "UI_TotalScore_Label";
            this.UI_TotalScore_Label.Size = new System.Drawing.Size(60, 26);
            this.UI_TotalScore_Label.TabIndex = 1;
            this.UI_TotalScore_Label.Text = "0000";
            // 
            // ShowScore_Modelless
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 209);
            this.Controls.Add(this.UI_TotalScore_Label);
            this.Controls.Add(this.UI_Score_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ShowScore_Modelless";
            this.Text = "Score";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowScore_Modelless_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_Score_lbl;
        private System.Windows.Forms.Label UI_TotalScore_Label;
    }
}