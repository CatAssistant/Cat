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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SpeechRecognitionBox = new System.Windows.Forms.TextBox();
            this.ListenTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeoutDisplay = new System.Windows.Forms.Label();
            this.TitleBackground = new System.Windows.Forms.PictureBox();
            this.FadeInTimer = new System.Windows.Forms.Timer(this.components);
            this.FadeOutTimer = new System.Windows.Forms.Timer(this.components);
            this.CatLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderlessForm
            // 
            this.BorderlessForm.ContainerControl = this;
            this.BorderlessForm.DockIndicatorTransparencyValue = 0.6D;
            this.BorderlessForm.TransparentWhileDrag = true;
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
            this.TitleLabel.Text = "CAT | Alpha 0.3";
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
            this.ListenTimer.Tick += new System.EventHandler(this.ListenTimer_Tick);
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
            // TitleBackground
            // 
            this.TitleBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TitleBackground.Location = new System.Drawing.Point(-1, -7);
            this.TitleBackground.Name = "TitleBackground";
            this.TitleBackground.Size = new System.Drawing.Size(444, 38);
            this.TitleBackground.TabIndex = 1;
            this.TitleBackground.TabStop = false;
            // 
            // CatLogo
            // 
            this.CatLogo.BackColor = System.Drawing.Color.Transparent;
            this.CatLogo.Image = global::Cat.Properties.Resources.cat_logo_transp;
            this.CatLogo.Location = new System.Drawing.Point(57, 109);
            this.CatLogo.Name = "CatLogo";
            this.CatLogo.Size = new System.Drawing.Size(319, 319);
            this.CatLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CatLogo.TabIndex = 11;
            this.CatLogo.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(433, 594);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleBackground);
            this.Controls.Add(this.CatLogo);
            this.Controls.Add(this.TimeoutDisplay);
            this.Controls.Add(this.SpeechRecognitionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Cat!";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TitleBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessForm;
        private System.Windows.Forms.PictureBox TitleBackground;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox SpeechRecognitionBox;
        private System.Windows.Forms.Timer ListenTimer;
        private System.Windows.Forms.Label TimeoutDisplay;
        private System.Windows.Forms.Timer FadeInTimer;
        private System.Windows.Forms.Timer FadeOutTimer;
        private System.Windows.Forms.PictureBox CatLogo;
    }
}

