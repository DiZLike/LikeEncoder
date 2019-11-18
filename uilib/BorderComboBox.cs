using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace uilib
{
    public class BorderComboBox : ComboBox
    {
        [DefaultValue(typeof(Color), "Gray")]
        public Color BorderColor { get; set; }

        private const int WM_PAINT = 0xF;
        private bool entered = false;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    using (var p = new Pen(this.BorderColor, 1))
                    {
                        g.DrawRectangle(p, 1, 1, Width - 2, Height - 2);
                    }
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (entered) return;
            entered = !entered;
            Cursor = Cursors.Hand;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (entered) return;
            entered = !entered;
            Cursor = Cursors.Default;
        }
        public BorderComboBox()
        {
            BorderColor = Color.Gray;
            FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }
    }
}
