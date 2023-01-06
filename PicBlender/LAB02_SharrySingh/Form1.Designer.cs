namespace PicBlender
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UI_Noise_Rbn = new System.Windows.Forms.RadioButton();
            this.UI_BlackAndWhite_Rbn = new System.Windows.Forms.RadioButton();
            this.UI_Tint_Rbn = new System.Windows.Forms.RadioButton();
            this.UI_Contrast_Rbn = new System.Windows.Forms.RadioButton();
            this.UI_modification_Tbr = new System.Windows.Forms.TrackBar();
            this.UI_Transform_Btn = new System.Windows.Forms.Button();
            this.UI_LoadPicture_Btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PIctureProgress = new System.Windows.Forms.ProgressBar();
            this.UI_Left_Lbl = new System.Windows.Forms.Label();
            this.UI_Right_Lbl = new System.Windows.Forms.Label();
            this.UI_Center_Lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_modification_Tbr)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(776, 311);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.UI_Noise_Rbn);
            this.groupBox1.Controls.Add(this.UI_BlackAndWhite_Rbn);
            this.groupBox1.Controls.Add(this.UI_Tint_Rbn);
            this.groupBox1.Controls.Add(this.UI_Contrast_Rbn);
            this.groupBox1.Location = new System.Drawing.Point(140, 348);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(277, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modification ";
            // 
            // UI_Noise_Rbn
            // 
            this.UI_Noise_Rbn.AutoSize = true;
            this.UI_Noise_Rbn.Location = new System.Drawing.Point(156, 60);
            this.UI_Noise_Rbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Noise_Rbn.Name = "UI_Noise_Rbn";
            this.UI_Noise_Rbn.Size = new System.Drawing.Size(64, 20);
            this.UI_Noise_Rbn.TabIndex = 3;
            this.UI_Noise_Rbn.Text = "Noise";
            this.UI_Noise_Rbn.UseVisualStyleBackColor = true;
            this.UI_Noise_Rbn.CheckedChanged += new System.EventHandler(this.UI_Rbn_CheckedChange);
            // 
            // UI_BlackAndWhite_Rbn
            // 
            this.UI_BlackAndWhite_Rbn.AutoSize = true;
            this.UI_BlackAndWhite_Rbn.Location = new System.Drawing.Point(7, 60);
            this.UI_BlackAndWhite_Rbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_BlackAndWhite_Rbn.Name = "UI_BlackAndWhite_Rbn";
            this.UI_BlackAndWhite_Rbn.Size = new System.Drawing.Size(125, 20);
            this.UI_BlackAndWhite_Rbn.TabIndex = 2;
            this.UI_BlackAndWhite_Rbn.Text = "Black and White";
            this.UI_BlackAndWhite_Rbn.UseVisualStyleBackColor = true;
            this.UI_BlackAndWhite_Rbn.CheckedChanged += new System.EventHandler(this.UI_Rbn_CheckedChange);
            // 
            // UI_Tint_Rbn
            // 
            this.UI_Tint_Rbn.AutoSize = true;
            this.UI_Tint_Rbn.Location = new System.Drawing.Point(156, 21);
            this.UI_Tint_Rbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Tint_Rbn.Name = "UI_Tint_Rbn";
            this.UI_Tint_Rbn.Size = new System.Drawing.Size(50, 20);
            this.UI_Tint_Rbn.TabIndex = 1;
            this.UI_Tint_Rbn.Text = "Tint";
            this.UI_Tint_Rbn.UseVisualStyleBackColor = true;
            this.UI_Tint_Rbn.CheckedChanged += new System.EventHandler(this.UI_Rbn_CheckedChange);
            // 
            // UI_Contrast_Rbn
            // 
            this.UI_Contrast_Rbn.AutoSize = true;
            this.UI_Contrast_Rbn.Checked = true;
            this.UI_Contrast_Rbn.Location = new System.Drawing.Point(7, 22);
            this.UI_Contrast_Rbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Contrast_Rbn.Name = "UI_Contrast_Rbn";
            this.UI_Contrast_Rbn.Size = new System.Drawing.Size(77, 20);
            this.UI_Contrast_Rbn.TabIndex = 0;
            this.UI_Contrast_Rbn.TabStop = true;
            this.UI_Contrast_Rbn.Text = "Contrast";
            this.UI_Contrast_Rbn.UseVisualStyleBackColor = true;
            this.UI_Contrast_Rbn.CheckedChanged += new System.EventHandler(this.UI_Rbn_CheckedChange);
            // 
            // UI_modification_Tbr
            // 
            this.UI_modification_Tbr.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_modification_Tbr.Location = new System.Drawing.Point(419, 358);
            this.UI_modification_Tbr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_modification_Tbr.Maximum = 100;
            this.UI_modification_Tbr.Name = "UI_modification_Tbr";
            this.UI_modification_Tbr.Size = new System.Drawing.Size(251, 56);
            this.UI_modification_Tbr.TabIndex = 4;
            this.UI_modification_Tbr.TickFrequency = 5;
            this.UI_modification_Tbr.ValueChanged += new System.EventHandler(this.Trackbar_Scroll);
            // 
            // UI_Transform_Btn
            // 
            this.UI_Transform_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_Transform_Btn.Enabled = false;
            this.UI_Transform_Btn.Location = new System.Drawing.Point(699, 358);
            this.UI_Transform_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_Transform_Btn.Name = "UI_Transform_Btn";
            this.UI_Transform_Btn.Size = new System.Drawing.Size(89, 32);
            this.UI_Transform_Btn.TabIndex = 3;
            this.UI_Transform_Btn.Text = "Transform !";
            this.UI_Transform_Btn.UseVisualStyleBackColor = true;
            this.UI_Transform_Btn.Click += new System.EventHandler(this.UI_Transform_Btn_Click);
            // 
            // UI_LoadPicture_Btn
            // 
            this.UI_LoadPicture_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LoadPicture_Btn.Location = new System.Drawing.Point(13, 358);
            this.UI_LoadPicture_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UI_LoadPicture_Btn.Name = "UI_LoadPicture_Btn";
            this.UI_LoadPicture_Btn.Size = new System.Drawing.Size(121, 32);
            this.UI_LoadPicture_Btn.TabIndex = 1;
            this.UI_LoadPicture_Btn.Text = "Load Picture";
            this.UI_LoadPicture_Btn.UseVisualStyleBackColor = true;
            this.UI_LoadPicture_Btn.Click += new System.EventHandler(this.UI_LoadPicture_Btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // PIctureProgress
            // 
            this.PIctureProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PIctureProgress.Location = new System.Drawing.Point(13, 329);
            this.PIctureProgress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PIctureProgress.Name = "PIctureProgress";
            this.PIctureProgress.Size = new System.Drawing.Size(775, 14);
            this.PIctureProgress.Step = 1;
            this.PIctureProgress.TabIndex = 1;
            // 
            // UI_Left_Lbl
            // 
            this.UI_Left_Lbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_Left_Lbl.AutoSize = true;
            this.UI_Left_Lbl.Location = new System.Drawing.Point(423, 398);
            this.UI_Left_Lbl.Name = "UI_Left_Lbl";
            this.UI_Left_Lbl.Size = new System.Drawing.Size(36, 16);
            this.UI_Left_Lbl.TabIndex = 6;
            this.UI_Left_Lbl.Text = "Less";
            // 
            // UI_Right_Lbl
            // 
            this.UI_Right_Lbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_Right_Lbl.AutoSize = true;
            this.UI_Right_Lbl.Location = new System.Drawing.Point(635, 398);
            this.UI_Right_Lbl.Name = "UI_Right_Lbl";
            this.UI_Right_Lbl.Size = new System.Drawing.Size(38, 16);
            this.UI_Right_Lbl.TabIndex = 7;
            this.UI_Right_Lbl.Text = "More";
            // 
            // UI_Center_Lbl
            // 
            this.UI_Center_Lbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_Center_Lbl.AutoSize = true;
            this.UI_Center_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.UI_Center_Lbl.Location = new System.Drawing.Point(539, 398);
            this.UI_Center_Lbl.Name = "UI_Center_Lbl";
            this.UI_Center_Lbl.Size = new System.Drawing.Size(14, 16);
            this.UI_Center_Lbl.TabIndex = 8;
            this.UI_Center_Lbl.Text = "0";
            this.UI_Center_Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_Center_Lbl);
            this.Controls.Add(this.UI_Right_Lbl);
            this.Controls.Add(this.UI_Left_Lbl);
            this.Controls.Add(this.PIctureProgress);
            this.Controls.Add(this.UI_LoadPicture_Btn);
            this.Controls.Add(this.UI_Transform_Btn);
            this.Controls.Add(this.UI_modification_Tbr);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Pic Blender";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_modification_Tbr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton UI_Noise_Rbn;
        private System.Windows.Forms.RadioButton UI_BlackAndWhite_Rbn;
        private System.Windows.Forms.RadioButton UI_Tint_Rbn;
        private System.Windows.Forms.RadioButton UI_Contrast_Rbn;
        private System.Windows.Forms.TrackBar UI_modification_Tbr;
        private System.Windows.Forms.Button UI_Transform_Btn;
        private System.Windows.Forms.Button UI_LoadPicture_Btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar PIctureProgress;
        private System.Windows.Forms.Label UI_Left_Lbl;
        private System.Windows.Forms.Label UI_Right_Lbl;
        private System.Windows.Forms.Label UI_Center_Lbl;
    }
}

