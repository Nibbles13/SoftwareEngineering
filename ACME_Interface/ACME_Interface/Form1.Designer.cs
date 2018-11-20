namespace ACME_Interface
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
			this.debugInstructionsLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.helloWorldLabel = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// debugInstructionsLabel
			// 
			this.debugInstructionsLabel.AutoSize = true;
			this.debugInstructionsLabel.Location = new System.Drawing.Point(113, 45);
			this.debugInstructionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.debugInstructionsLabel.Name = "debugInstructionsLabel";
			this.debugInstructionsLabel.Size = new System.Drawing.Size(285, 26);
			this.debugInstructionsLabel.TabIndex = 1;
			this.debugInstructionsLabel.Text = "Enter the name of the film you want into the search bar and\r\n      press the butt" +
    "on of the database you want to search";
			this.debugInstructionsLabel.Click += new System.EventHandler(this.debugInstructionsLabel_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(199, 125);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(103, 28);
			this.button1.TabIndex = 2;
			this.button1.Text = "omdbapi.com";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// helloWorldLabel
			// 
			this.helloWorldLabel.AutoSize = true;
			this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helloWorldLabel.Location = new System.Drawing.Point(155, 19);
			this.helloWorldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.helloWorldLabel.Name = "helloWorldLabel";
			this.helloWorldLabel.Size = new System.Drawing.Size(195, 26);
			this.helloWorldLabel.TabIndex = 3;
			this.helloWorldLabel.Text = "Database searcher";
			this.helloWorldLabel.Click += new System.EventHandler(this.helloWorldLabel_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(91, 125);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(103, 28);
			this.button2.TabIndex = 4;
			this.button2.Text = "TheMoviedb.com";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(199, 160);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(103, 28);
			this.button3.TabIndex = 5;
			this.button3.Text = "Wishlist";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(130, 100);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(237, 20);
			this.textBox1.TabIndex = 6;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(308, 126);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(107, 28);
			this.button4.TabIndex = 7;
			this.button4.Text = "Random film";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(160, 75);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(66, 17);
			this.radioButton1.TabIndex = 8;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Film Title";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(274, 75);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(62, 17);
			this.radioButton2.TabIndex = 9;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Imdb ID";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(533, 217);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.helloWorldLabel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.debugInstructionsLabel);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Database searcher";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label debugInstructionsLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label helloWorldLabel;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
	}
}

