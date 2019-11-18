using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uilib
{
    public partial class Progress : UserControl
    {
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor { get; set; }

        [DefaultValue(1)]
        public int BorderWidth { get; set; }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                int xx = (int)((float)x / (float)max * (float)value);
                Size point = new Size(xx, y);
                panel1.Size = point;
            }
        }
        public int Maximum { get { return max; } set { max = value; } }
        public int Minimum { get { return min; } set { min = value; } }
        public Color ProgressColor
        {
            get
            {
                return progressColor;
            }
            set
            {
                progressColor = value;
            }
        }

        private int value = 0;
        private int min = 0;
        private int max = 100;
        private int x = 0;
        private int y = 0;
        private Color progressColor = Color.FromArgb(0, 0xFF, 0x40);
        public Progress()
        {
            InitializeComponent();
            BorderColor = Color.Black;
            BorderWidth = 1;

            x = this.Size.Width;
            y = this.Size.Height - 2;
            panel1.BackColor = progressColor;
        }
        private void XProgressBar_Resize(object sender, EventArgs e)
        {
            x = this.Size.Width;
            y = this.Size.Height - 2;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var d = BorderWidth / 2;
            using (var pen = new Pen(BorderColor, BorderWidth))
                e.Graphics.DrawRectangle(pen, d, d, Width - 2 * d - 1, Height - 2 * d - 1);
        }

    }
}
