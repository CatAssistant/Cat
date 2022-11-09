namespace Cat
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.catLogo = new System.Windows.Forms.PictureBox();
            this.TitleBackground = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SpeechRecognitionBox = new System.Windows.Forms.TextBox();
            this.ListenTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeoutDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.catLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderlessForm
            // 
            this.BorderlessForm.ContainerControl = this;
            this.BorderlessForm.DockIndicatorTransparencyValue = 0.6D;
            this.BorderlessForm.TransparentWhileDrag = true;
            // 
            // catLogo
            // 
            this.catLogo.Image = global::Cat.Properties.Resources.cat_logo_transp;
            this.catLogo.Location = new System.Drawing.Point(83, 67);
            this.catLogo.Name = "catLogo";
            this.catLogo.Size = new System.Drawing.Size(266, 274);
            this.catLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.catLogo.TabIndex = 0;
            this.catLogo.TabStop = false;
            // 
            // TitleBackground
            // 
            this.TitleBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TitleBackground.Location = new System.Drawing.Point(-1, -7);
            this.TitleBackground.Name = "TitleBackground";
            this.TitleBackground.Size = new System.Drawing.Size(444, 38);
            this.TitleBackground.TabIndex = 1;
            this.TitleBackground.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TitleLabel.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(4, 4);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(113, 21);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "CAT | Alpha 0.2";
            // 
            // SpeechRecognitionBox
            // 
            this.SpeechRecognitionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.SpeechRecognitionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpeechRecognitionBox.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeechRecognitionBox.ForeColor = System.Drawing.Color.White;
            this.SpeechRecognitionBox.Location = new System.Drawing.Point(12, 513);
            this.SpeechRecognitionBox.Multiline = true;
            this.SpeechRecognitionBox.Name = "SpeechRecognitionBox";
            this.SpeechRecognitionBox.Size = new System.Drawing.Size(409, 69);
            this.SpeechRecognitionBox.TabIndex = 4;
            this.SpeechRecognitionBox.Text = "Recognized Speech";
            // 
            // ListenTimer
            // 
            this.ListenTimer.Enabled = true;
            this.ListenTimer.Interval = 1000;
            this.ListenTimer.Tick += new System.EventHandler(this.TmrSpeaking_Tick);
            // 
            // TimeoutDisplay
            // 
            this.TimeoutDisplay.AutoSize = true;
            this.TimeoutDisplay.ForeColor = System.Drawing.Color.White;
            this.TimeoutDisplay.Location = new System.Drawing.Point(408, 482);
            this.TimeoutDisplay.Name = "TimeoutDisplay";
            this.TimeoutDisplay.Size = new System.Drawing.Size(13, 13);
            this.TimeoutDisplay.TabIndex = 5;
            this.TimeoutDisplay.Text = "0";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(433, 594);
            this.Controls.Add(this.TimeoutDisplay);
            this.Controls.Add(this.SpeechRecognitionBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleBackground);
            this.Controls.Add(this.catLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Cat!";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.catLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessForm;
        private System.Windows.Forms.PictureBox catLogo;
        private System.Windows.Forms.PictureBox TitleBackground;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox SpeechRecognitionBox;
        private System.Windows.Forms.Timer ListenTimer;
        private System.Windows.Forms.Label TimeoutDisplay;
    }
}

