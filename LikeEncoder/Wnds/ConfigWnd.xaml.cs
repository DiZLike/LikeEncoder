using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using lib;

namespace Liken.Wnds
{
    /// <summary>
    /// Логика взаимодействия для ConfigWnd.xaml
    /// </summary>
    public partial class ConfigWnd : Window
    {
        Cfg app_cfg = new Cfg(Cfg.APP_CFG);

        public ConfigWnd()
        {
            InitializeComponent();
            LoadCores();
            LoadBuffer();
            LoadSaveInfo();
            LoadDyComp();
        }
        private void LoadDyComp()
        {
            dycompen.IsChecked = app_cfg.ReadBool("maximazer", false);
            dycomplevel.SelectedIndex = app_cfg.ReadInt("rms", -12) + 12;
        }

        private void LoadCores()
        {
            for (int i = 1; i <= Environment.ProcessorCount; i++)
                cores.Items.Add(i);
            cores.SelectedIndex = app_cfg.ReadInt("cores", Environment.ProcessorCount - 1);
        }
        private void LoadBuffer()
        {
            int buffer = 8;
            for (int i = 0; buffer < 65536; i++)
            {
                buffer *= 2;
                this.buffer.Items.Add(buffer);
            }
            this.buffer.SelectedIndex = app_cfg.ReadInt("buffer", 6);
        }
        private void LoadSaveInfo()
        {
            saveinfo.IsChecked = app_cfg.ReadBool("saveinfo", true);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            app_cfg.Write("cores", cores.SelectedIndex);
            app_cfg.Write("buffer", buffer.SelectedIndex);
            app_cfg.Write("saveinfo", saveinfo.IsChecked.Value);
            app_cfg.Write("maximazer", dycompen.IsChecked.Value);
            app_cfg.Write("rms", dycomplevel.SelectedIndex - 12);
        }

    }
}
