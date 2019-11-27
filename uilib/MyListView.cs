using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace uilib
{
    public class MyListView : ListView
    {
        private int w = 0;

        public MyListView()
        {
            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

        }

        public void AddItem(string[] values)
        {
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem lvsi2 = new ListViewItem.ListViewSubItem();

            lvi.Text = values[0];
            lvsi.Text = values[1];
            lvsi2.Text = values[2];
            
            lvi.SubItems.Add(lvsi);
            lvi.SubItems.Add(lvsi2);
            this.Items.Add(lvi);
        }

    }
}
