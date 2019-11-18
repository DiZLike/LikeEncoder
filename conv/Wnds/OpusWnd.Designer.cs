namespace conv.Wnds
{
    partial class OpusWnd
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
            this.borderPanel1 = new uilib.BorderPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.quality = new uilib.BorderComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.frame = new uilib.BorderComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bitrate = new uilib.BorderComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.channel = new uilib.BorderComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.frequency = new uilib.BorderComboBox();
            this.myButton1 = new uilib.MyButton();
            this.borderPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderPanel1
            // 
            this.borderPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.borderPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.borderPanel1.Controls.Add(this.label5);
            this.borderPanel1.Controls.Add(this.quality);
            this.borderPanel1.Controls.Add(this.label4);
            this.borderPanel1.Controls.Add(this.frame);
            this.borderPanel1.Controls.Add(this.label3);
            this.borderPanel1.Controls.Add(this.bitrate);
            this.borderPanel1.Controls.Add(this.label2);
            this.borderPanel1.Controls.Add(this.channel);
            this.borderPanel1.Controls.Add(this.label1);
            this.borderPanel1.Controls.Add(this.frequency);
            this.borderPanel1.Location = new System.Drawing.Point(5, 5);
            this.borderPanel1.Name = "borderPanel1";
            this.borderPanel1.Size = new System.Drawing.Size(203, 148);
            this.borderPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Качество:";
            // 
            // quality
            // 
            this.quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quality.FormattingEnabled = true;
            this.quality.Items.AddRange(new object[] {
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.quality.Location = new System.Drawing.Point(71, 88);
            this.quality.Name = "quality";
            this.quality.Size = new System.Drawing.Size(121, 21);
            this.quality.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Фрейм:";
            // 
            // frame
            // 
            this.frame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frame.FormattingEnabled = true;
            this.frame.Items.AddRange(new object[] {
            "2.5",
            "5",
            "10",
            "20",
            "40",
            "60"});
            this.frame.Location = new System.Drawing.Point(71, 61);
            this.frame.Name = "frame";
            this.frame.Size = new System.Drawing.Size(121, 21);
            this.frame.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Битрейт:";
            // 
            // bitrate
            // 
            this.bitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bitrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bitrate.FormattingEnabled = true;
            this.bitrate.Items.AddRange(new object[] {
            "8",
            "16",
            "24",
            "32",
            "40",
            "48",
            "56",
            "64",
            "80",
            "96",
            "112",
            "128",
            "160",
            "192",
            "224",
            "256",
            "320",
            "360",
            "420",
            "510"});
            this.bitrate.Location = new System.Drawing.Point(71, 34);
            this.bitrate.Name = "bitrate";
            this.bitrate.Size = new System.Drawing.Size(121, 21);
            this.bitrate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Каналы:";
            // 
            // channel
            // 
            this.channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.channel.FormattingEnabled = true;
            this.channel.Items.AddRange(new object[] {
            "Стерео",
            "Моно"});
            this.channel.Location = new System.Drawing.Point(71, 115);
            this.channel.Name = "channel";
            this.channel.Size = new System.Drawing.Size(121, 21);
            this.channel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Частота:";
            // 
            // frequency
            // 
            this.frequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frequency.FormattingEnabled = true;
            this.frequency.Items.AddRange(new object[] {
            "48000"});
            this.frequency.Location = new System.Drawing.Point(71, 7);
            this.frequency.Name = "frequency";
            this.frequency.Size = new System.Drawing.Size(121, 21);
            this.frequency.TabIndex = 0;
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(65, 159);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(83, 26);
            this.myButton1.TabIndex = 1;
            this.myButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpusWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 194);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.borderPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpusWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opus";
            this.borderPanel1.ResumeLayout(false);
            this.borderPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private uilib.BorderPanel borderPanel1;
        private System.Windows.Forms.Label label1;
        private uilib.BorderComboBox frequency;
        private System.Windows.Forms.Label label5;
        private uilib.BorderComboBox quality;
        private System.Windows.Forms.Label label4;
        private uilib.BorderComboBox frame;
        private System.Windows.Forms.Label label3;
        private uilib.BorderComboBox bitrate;
        private System.Windows.Forms.Label label2;
        private uilib.BorderComboBox channel;
        private uilib.MyButton myButton1;
    }
}