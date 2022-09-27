using LCPLIB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BroadCast bc = new BroadCast();
        public MainWindow()
        {
            InitializeComponent();
            bc.Recieve(1111,AddLog);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        public void AddLog(string str)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                TextLog.Text = TextLog.Text + str + "\n";
            }); // получение доступа к потоку UI
        }
    }
}
