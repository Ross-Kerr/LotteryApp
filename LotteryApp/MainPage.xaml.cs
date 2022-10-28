using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LotteryApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void CreateTicket(object sender, RoutedEventArgs e)
        {
            Ticket thisTicket = new Ticket();
            thisTicket.Name = NameText.Text;
            thisTicket.Phone = PhoneText.Text;

            thisTicket.balls.Add( Ball1.Text );
            thisTicket.balls.Add( Ball2.Text );
            thisTicket.balls.Add( Ball3.Text );
            thisTicket.balls.Add( Ball4.Text );
            thisTicket.balls.Add( Ball5.Text );
            thisTicket.balls.Add( Ball6.Text );

            var msg = new MessageDialog("Ticket Created", thisTicket.ToString()).ShowAsync();   

        }
        
    }
}
