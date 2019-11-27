using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace uilib
{
    public class BorderPanel : Panel
    {
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor { get; set; }
 
        [DefaultValue(1)]
        public int BorderWidth { get; set; }

        public BorderPanel()
        {
            BorderColor = Color.Black;
            BorderWidth = 1;
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
