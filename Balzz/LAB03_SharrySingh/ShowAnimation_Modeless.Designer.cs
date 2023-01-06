namespace Balzz
{
    partial class ShowAnimation_Modeless
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
            this.UI_animation_trackbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_animation_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_animation_trackbar
            // 
            this.UI_animation_trackbar.Location = new System.Drawing.Point(12, 39);
            this.UI_animation_trackbar.Maximum = 200;
            this.UI_animation_trackbar.Minimum = 10;
            this.UI_animation_trackbar.Name = "UI_animation_trackbar";
            this.UI_animation_trackbar.Size = new System.Drawing.Size(440, 56);
            this.UI_animation_trackbar.TabIndex = 0;
            this.UI_animation_trackbar.TickFrequency = 10;
            this.UI_animation_trackbar.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "10 ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "200 ms";
            // 
            // ShowAnimation_Modeless
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 122);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_animation_trackbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ShowAnimation_Modeless";
            this.Text = "Animation Speed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowAnimation_Modeless_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.UI_animation_trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar UI_animation_trackbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}