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
        BroadCast.Reciever bc;
        public MainWindow()
        {
            InitializeComponent();
            
            bc = new BroadCast.Reciever(1111, AddLog);
            bc.StartRecieve();

            //bc.Recieve(1111,AddLog);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        public void AddLog(string str)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                TextLog.Text = TextLog.Text + str + "\n";
                bc.StopRecieve();
            }); // получение доступа к потоку UI
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bc.StartRecieve();
        }
    }
}
