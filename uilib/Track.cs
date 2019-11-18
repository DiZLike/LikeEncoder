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
    public partial class Track : UserControl
    {
        // - вниз
        // + вверх
        public int SizeY = 45;

        public string Title
        {
            get { return lTitle.Text; }
            set { lTitle.Text = value; }
        }
        public string Format
        {
            get { return lFormat.Text; }
            set { lFormat.Text = value; }
        }
        public int EncodingProgress
        {
            get { return progress.Value; }
            set 
            { 
                progress.Value = value;
                if (progress.Value > 99)
                    Complete = true;
            }
        }
        public bool Complete
        {
            get { return status.Visible; }
            set { status.Visible = value; }
        }
        public string Path { get; set; }
        public Track()
        {
            InitializeComponent();
            //this.MouseWheel += new MouseEventHandler(Track_MouseWheel);
        }

        void Track_MouseWheel(object sender, MouseEventArgs e)
        {
            OnMouseWheel(e);
        }
    }
}
