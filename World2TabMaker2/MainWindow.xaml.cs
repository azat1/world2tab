using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using World2TabMaker;

namespace World2TabMaker2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectFile();
        }

        private void SelectFile()
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Multiselect = true;
            // opendialog.AddExtension(".jgw");
            opendialog.Filter = "World files |*.jgw;*.bpw;*.tfw;*.gfw";
            if ((bool) opendialog.ShowDialog(this))
            {
                textBox.Text = opendialog.FileName;
                foreach (string fn in opendialog.FileNames)
                {
                    World2TabConverter.Convert(fn);
                }
                MessageBox.Show("Готово!");
            }
            

       
        }
    }
}
