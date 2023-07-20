using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Anti_MotivationalQuotes.Model;

namespace Anti_MotivationalQuotes.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        AntiMotivationalQuotes Quotes;

        public MainWindow()
        {
            InitializeComponent();

            Quotes = new AntiMotivationalQuotes();
            ReadAllAnti_MotivationalQuotes();

            Quotes.ShowIndex = GetRandomIntValue(0, Quotes.Lines);

            this.Anti_MotivationalQuotesShowBlock.Text = Quotes.QuotesList[Quotes.ShowIndex];
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void WindowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void WindowStateBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    this.WindowStateBtn.Content = "\xeda1";
                    break;

                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    this.WindowStateBtn.Content = "\xeda0";
                    break;

                default:
                    this.WindowState = WindowState.Normal;
                    this.WindowStateBtn.Content = "\xeda1";
                    break;
            }
        }

        private void AnotherBillionBowlsBtn_Click(object sender, RoutedEventArgs e)
        {
            Quotes.Step = GetRandomIntValue(0, Quotes.MAX_STEP);
            Quotes.ShowIndex = (Quotes.ShowIndex + Quotes.Step) % Quotes.Lines;
            this.Anti_MotivationalQuotesShowBlock.Text = Quotes.QuotesList[Quotes.ShowIndex];
        }

        private void ReadAllAnti_MotivationalQuotes()
        {

            try
            {
                string DataPath = "Anti-MotivationalQuotes";

                StreamReader sr = new StreamReader(DataPath);

                string t = sr.ReadToEnd();

                Quotes.QuotesList = t.Split('\n');
                Quotes.Lines = Quotes.QuotesList.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Close();
            }
        }

        private int GetRandomIntValue(int minV, int maxV)
        {
            return (new Random()).Next(minV, maxV); ;
        }
    }
}
