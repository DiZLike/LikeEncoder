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
    public partial class MyButton : UserControl
    {
        private bool entered = false;
        private bool pressed = false;
        private Color defaultColor;

        public string Title
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public MyButton()
        {
            InitializeComponent();
            defaultColor = borderPanel1.BackColor;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if (entered) return;
            entered = !entered;
            borderPanel1.BackColor = Color.FromArgb(0xFF, 0xF3, 0xb3);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (!entered) return;
            entered = !entered;
            borderPanel1.BackColor = defaultColor;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pressed) return;
            pressed = !pressed;
            borderPanel1.BackColor = Color.FromArgb(0xEF, 0xE3, 0xA3);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!pressed) return;
            pressed = !pressed;
            if (!entered)
                borderPanel1.BackColor = defaultColor;
            else
                borderPanel1.BackColor = Color.FromArgb(0xFF, 0xF3, 0xb3);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

    }
}
