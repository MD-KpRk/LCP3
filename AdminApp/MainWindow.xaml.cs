using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LCPLIB;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //BroadCast bc = new BroadCast();
            //bc.Send(1111);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // старт серв
        { 
            LCPLIB.TCP.Server server = new LCPLIB.TCP.Server();
            server.Start();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // отправить
        {
            LCPLIB.TCP.Client client = new LCPLIB.TCP.Client();
            client.Start();
        }
    }
}
