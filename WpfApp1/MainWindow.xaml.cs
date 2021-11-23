using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfTextGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*foreach (var file in Directory.GetFiles("Books"))
            {
                var countWords = TextTools.TextTools.TopTenWords(File.ReadAllText(file));
                txbInfo.Text += Path.GetFileName(file) + Environment.NewLine;
                countWords.ToList().ForEach(x => txbInfo.Text += x.Key + " " + x.Value + Environment.NewLine);
            }*/
        }

        private void bLoad_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            txbInfo.Text = "";
            var bigFilesDir = @"C:\Users\czdapla\source\BigFiles";
            foreach (var file in Directory.GetFiles(bigFilesDir))
            {
                var countWords = TextTools.TextTools.TopTenWords(File.ReadAllText(file), Environment.NewLine);
                txbInfo.Text += Environment.NewLine + Path.GetFileName(file) + Environment.NewLine;
                countWords.ToList().ForEach(x => txbInfo.Text += x.Key + " " + x.Value + Environment.NewLine);
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
