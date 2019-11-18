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
    public partial class BtnTextBox : UserControl
    {
        [DefaultValue(typeof(bool), "false")]
        public bool ReadOnly { get; set; }

        private Color defaultColor;

        private bool mouseEntered = false;

        public BtnTextBox()
        {
            InitializeComponent();
            defaultColor = panel1.BackColor;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if (mouseEntered) return;
            mouseEntered = !mouseEntered;
            Cursor = Cursors.Hand;
            panel1.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (!mouseEntered) return;
            mouseEntered = !mouseEntered;
            Cursor = Cursors.Default;
            panel1.BackColor = defaultColor;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ReadOnly)
                e.Handled = true;
        }
    }
}
