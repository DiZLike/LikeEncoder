namespace uilib
{
    partial class Track
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lTitle = new System.Windows.Forms.Label();
            this.lFormat = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.PictureBox();
            this.progress = new uilib.Progress();
            ((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(3, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(67, 13);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Artist - Track";
            // 
            // lFormat
            // 
            this.lFormat.AutoSize = true;
            this.lFormat.Location = new System.Drawing.Point(3, 17);
            this.lFormat.Name = "lFormat";
            this.lFormat.Size = new System.Drawing.Size(211, 13);
            this.lFormat.TabIndex = 1;
            this.lFormat.Text = "OPUS | 48000 kHz | 128 kBit | 60 framesize";
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.status.Image = global::uilib.Properties.Resources.agt_action_success;
            this.status.Location = new System.Drawing.Point(273, 3);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(24, 24);
            this.status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.status.TabIndex = 3;
            this.status.TabStop = false;
            this.status.Visible = false;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.BackColor = System.Drawing.Color.White;
            this.progress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.progress.Location = new System.Drawing.Point(6, 32);
            this.progress.Maximum = 100;
            this.progress.Minimum = 0;
            this.progress.Name = "progress";
            this.progress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.progress.Size = new System.Drawing.Size(291, 10);
            this.progress.TabIndex = 4;
            this.progress.Value = 0;
            // 
            // Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.progress);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lFormat);
            this.Controls.Add(this.lTitle);
            this.Name = "Track";
            this.Size = new System.Drawing.Size(300, 45);
            ((System.ComponentModel.ISupportInitialize)(this.status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lFormat;
        private System.Windows.Forms.PictureBox status;
        private Progress progress;
    }
}
