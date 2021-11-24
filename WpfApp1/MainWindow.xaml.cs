using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        string _bigFilesDir = @"C:\Users\czdapla\source\BigFiles";

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

        private async void bLoad_Click(object sender, RoutedEventArgs e)
        {
            var stopWatch = Stopwatch.StartNew();
            Mouse.OverrideCursor = Cursors.Wait;
            pbLoadStatus.Visibility = Visibility.Visible;
            txbInfo.Text = "";

            int fileCount = Directory.GetFiles(_bigFilesDir).Count();
            double fileOrder = 1;
            foreach (var file in Directory.GetFiles(_bigFilesDir))
            {
                var progValue = (fileOrder / fileCount) * 100;
                pbLoadStatus.Value = progValue;
                var fileContent = await File.ReadAllTextAsync(file);
                var countWords = await TextTools.TextTools.TopTenWordsAsync(fileContent, Environment.NewLine);
                txbInfo.Text += Environment.NewLine + Path.GetFileName(file) + Environment.NewLine;
                countWords.ToList().ForEach(x => txbInfo.Text += x.Key + " " + x.Value + Environment.NewLine);
                fileOrder++;
            }
            stopWatch.Stop();
            pbLoadStatus.Visibility = Visibility.Hidden;
            txbTimeInfo.Text = "Elapsed: " + stopWatch.ElapsedMilliseconds.ToString() + " ms";
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private async void bLoadAll_Click(object sender, RoutedEventArgs e)
        {
            txbInfo.Text = "";
            var stopWatch = Stopwatch.StartNew();
            Mouse.OverrideCursor = Cursors.Wait;
            string joinAll = "";
            foreach (var file in Directory.GetFiles(_bigFilesDir))
            {
                joinAll += await File.ReadAllTextAsync(file);
            }

            var countWords = TextTools.TextTools.TopTenWords(joinAll, Environment.NewLine);
            countWords.ToList().ForEach(x => txbInfo.Text += x.Key + " " + x.Value + Environment.NewLine);
            txbTimeInfo.Text = "Elapsed: " + stopWatch.ElapsedMilliseconds.ToString() + " ms";
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void bLoadAllParalel_Click1(object sender, RoutedEventArgs e)
        {
            txbInfo.Text = "";
            var stopWatch = Stopwatch.StartNew();

            ConcurrentDictionary<string, int> dict = new();

            Parallel.ForEach(Directory.GetFiles(_bigFilesDir), file =>
             {
                 foreach (var word in File.ReadAllLines(file))
                 {
                     dict.AddOrUpdate(word,1, (key, oldvalue) => oldvalue + 1);
                 }

             });

            foreach (var kv in dict.OrderByDescending(x => x.Value).Take(10))
            {
                txbInfo.Text += kv.Key + " " + kv.Value + Environment.NewLine;
            }

            txbTimeInfo.Text = "Elapsed: " + stopWatch.ElapsedMilliseconds.ToString() + " ms";
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private async void bLoadAllParalel_Click(object sender, RoutedEventArgs e)
        {

            var urls = new List<string>()
            {
                "https://www.gutenberg.org/cache/epub/2036/pg2036.txt",
                "https://www.gutenberg.org/files/16749/16749-0.txt",
                "https://www.gutenberg.org/cache/epub/19694/pg19694.txt"
            };
            // stahnete texty z techto tri adres a paralelne provedte textovou analyzu
            // a vypiste vysledky - kazdou knihu samostatne

            HttpClient httpClient = new HttpClient();

            txbInfo.Text = "";
            var stopWatch = Stopwatch.StartNew();

            ConcurrentDictionary<string, int> dict = new();

            Parallel.ForEach(urls, url =>
            {

                var res = httpClient.GetStringAsync(url).Result;


                foreach (var word in res.Split(" "))
                {
                    dict.AddOrUpdate(word, 1, (key, oldvalue) => oldvalue + 1);
                }

            });

            foreach (var kv in dict.OrderByDescending(x => x.Value).Take(10))
            {
                txbInfo.Text += kv.Key + " " + kv.Value + Environment.NewLine;
            }

            txbTimeInfo.Text = "Elapsed: " + stopWatch.ElapsedMilliseconds.ToString() + " ms";
            Mouse.OverrideCursor = Cursors.Arrow;
        }


    }
}
