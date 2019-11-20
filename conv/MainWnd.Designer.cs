namespace conv
{
    partial class MainWnd
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.borderPanel1 = new uilib.BorderPanel();
            this.myButton2 = new uilib.MyButton();
            this.myButton1 = new uilib.MyButton();
            this.progress1 = new uilib.Progress();
            this.btnTextBox2 = new uilib.BtnTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.borderComboBox1 = new uilib.BorderComboBox();
            this.btnTextBox1 = new uilib.BtnTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.borderPanel2 = new uilib.BorderPanel();
            this.trackPanel1 = new uilib.TrackPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.borderPanel1.SuspendLayout();
            this.borderPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьФайлыToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // добавитьФайлыToolStripMenuItem
            // 
            this.добавитьФайлыToolStripMenuItem.Name = "добавитьФайлыToolStripMenuItem";
            this.добавитьФайлыToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.добавитьФайлыToolStripMenuItem.Text = "Добавить файлы";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(704, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::conv.Properties.Resources.add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // borderPanel1
            // 
            this.borderPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.borderPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.borderPanel1.Controls.Add(this.pictureBox1);
            this.borderPanel1.Controls.Add(this.myButton2);
            this.borderPanel1.Controls.Add(this.myButton1);
            this.borderPanel1.Controls.Add(this.progress1);
            this.borderPanel1.Controls.Add(this.btnTextBox2);
            this.borderPanel1.Controls.Add(this.label2);
            this.borderPanel1.Controls.Add(this.borderComboBox1);
            this.borderPanel1.Controls.Add(this.btnTextBox1);
            this.borderPanel1.Controls.Add(this.label1);
            this.borderPanel1.Controls.Add(this.borderPanel2);
            this.borderPanel1.Location = new System.Drawing.Point(5, 53);
            this.borderPanel1.Name = "borderPanel1";
            this.borderPanel1.Size = new System.Drawing.Size(695, 390);
            this.borderPanel1.TabIndex = 5;
            // 
            // myButton2
            // 
            this.myButton2.Location = new System.Drawing.Point(467, 161);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(83, 26);
            this.myButton2.TabIndex = 10;
            this.myButton2.Title = "MyButton";
            this.myButton2.Click += new System.EventHandler(this.myButton2_Click);
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(467, 76);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(220, 26);
            this.myButton1.TabIndex = 9;
            this.myButton1.Title = "Старт";
            this.myButton1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // progress1
            // 
            this.progress1.BackColor = System.Drawing.Color.White;
            this.progress1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.progress1.Location = new System.Drawing.Point(6, 367);
            this.progress1.Maximum = 100;
            this.progress1.Minimum = 0;
            this.progress1.Name = "progress1";
            this.progress1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.progress1.Size = new System.Drawing.Size(452, 15);
            this.progress1.TabIndex = 8;
            this.progress1.Value = 0;
            // 
            // btnTextBox2
            // 
            this.btnTextBox2.BackColor = System.Drawing.Color.White;
            this.btnTextBox2.Location = new System.Drawing.Point(103, 341);
            this.btnTextBox2.MaximumSize = new System.Drawing.Size(400, 21);
            this.btnTextBox2.Name = "btnTextBox2";
            this.btnTextBox2.Size = new System.Drawing.Size(355, 21);
            this.btnTextBox2.TabIndex = 7;
            this.btnTextBox2.Title = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Конечная папка:";
            // 
            // borderComboBox1
            // 
            this.borderComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.borderComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borderComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderComboBox1.FormattingEnabled = true;
            this.borderComboBox1.Location = new System.Drawing.Point(466, 22);
            this.borderComboBox1.Name = "borderComboBox1";
            this.borderComboBox1.Size = new System.Drawing.Size(221, 21);
            this.borderComboBox1.TabIndex = 4;
            // 
            // btnTextBox1
            // 
            this.btnTextBox1.BackColor = System.Drawing.Color.White;
            this.btnTextBox1.Location = new System.Drawing.Point(467, 49);
            this.btnTextBox1.MaximumSize = new System.Drawing.Size(400, 21);
            this.btnTextBox1.Name = "btnTextBox1";
            this.btnTextBox1.ReadOnly = true;
            this.btnTextBox1.Size = new System.Drawing.Size(220, 21);
            this.btnTextBox1.TabIndex = 3;
            this.btnTextBox1.Title = "";
            this.btnTextBox1.Click += new System.EventHandler(this.btnTextBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Формат:";
            // 
            // borderPanel2
            // 
            this.borderPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.borderPanel2.Controls.Add(this.trackPanel1);
            this.borderPanel2.Location = new System.Drawing.Point(6, 6);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Size = new System.Drawing.Size(452, 329);
            this.borderPanel2.TabIndex = 0;
            // 
            // trackPanel1
            // 
            this.trackPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackPanel1.AutoScroll = true;
            this.trackPanel1.BackColor = System.Drawing.Color.White;
            this.trackPanel1.Location = new System.Drawing.Point(3, 3);
            this.trackPanel1.Name = "trackPanel1";
            this.trackPanel1.Size = new System.Drawing.Size(446, 323);
            this.trackPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(466, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 132);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 447);
            this.Controls.Add(this.borderPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWnd";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.borderPanel1.ResumeLayout(false);
            this.borderPanel1.PerformLayout();
            this.borderPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлыToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private uilib.BorderPanel borderPanel1;
        private uilib.BorderPanel borderPanel2;
        private uilib.TrackPanel trackPanel1;
        private System.Windows.Forms.Label label1;
        private uilib.BtnTextBox btnTextBox1;
        private uilib.BorderComboBox borderComboBox1;
        private System.Windows.Forms.Label label2;
        private uilib.BtnTextBox btnTextBox2;
        private uilib.Progress progress1;
        private uilib.MyButton myButton1;
        private uilib.MyButton myButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

