namespace GPS
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
            this.tbData = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.guglemap = new System.Windows.Forms.Button();
            this.GoogleMapstxt = new System.Windows.Forms.TextBox();
            this.btnColors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbData
            // 
            this.tbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbData.Location = new System.Drawing.Point(41, 163);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbData.Size = new System.Drawing.Size(431, 258);
            this.tbData.TabIndex = 14;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(41, 25);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 23);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "Start listening";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(41, 68);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(85, 23);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop listening";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // guglemap
            // 
            this.guglemap.Location = new System.Drawing.Point(373, 25);
            this.guglemap.Name = "guglemap";
            this.guglemap.Size = new System.Drawing.Size(75, 23);
            this.guglemap.TabIndex = 17;
            this.guglemap.Text = "Google Map";
            this.guglemap.UseVisualStyleBackColor = true;
            this.guglemap.Click += new System.EventHandler(this.button1_Click);
            // 
            // GoogleMapstxt
            // 
            this.GoogleMapstxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GoogleMapstxt.Location = new System.Drawing.Point(249, 68);
            this.GoogleMapstxt.Multiline = true;
            this.GoogleMapstxt.Name = "GoogleMapstxt";
            this.GoogleMapstxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GoogleMapstxt.Size = new System.Drawing.Size(223, 49);
            this.GoogleMapstxt.TabIndex = 18;
            // 
            // btnColors
            // 
            this.btnColors.Location = new System.Drawing.Point(208, 25);
            this.btnColors.Name = "btnColors";
            this.btnColors.Size = new System.Drawing.Size(75, 23);
            this.btnColors.TabIndex = 19;
            this.btnColors.Text = "OK?";
            this.btnColors.UseVisualStyleBackColor = true;
            this.btnColors.Click += new System.EventHandler(this.btnColors_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 474);
            this.Controls.Add(this.btnColors);
            this.Controls.Add(this.GoogleMapstxt);
            this.Controls.Add(this.guglemap);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button guglemap;
        private System.Windows.Forms.TextBox GoogleMapstxt;
        private System.Windows.Forms.Button btnColors;
    }
}

