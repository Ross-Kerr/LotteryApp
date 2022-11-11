using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        ArrayList tickets = new ArrayList();
        ObservableCollection<String> ticketlist = new ObservableCollection<String>();

        public MainPage()
        {
            this.InitializeComponent();
        }


        private void CreateTicket(object sender, RoutedEventArgs e)
        {
            try
            {

                Ticket thisTicket = new Ticket();
                

                thisTicket.Name = NameText.Text;
                thisTicket.Phone = PhoneText.Text;

                ArrayList ballList = new ArrayList();
                ballList.Add(Ball1.Text);
                ballList.Add(Ball2.Text);
                ballList.Add(Ball3.Text);
                ballList.Add(Ball4.Text);
                ballList.Add(Ball5.Text);
                ballList.Add(Ball6.Text);

                thisTicket.balls = ballList;

                //add to arraylist
                tickets.Add(thisTicket);
                ticketlist.Add(thisTicket.ToString());


                var msg = new MessageDialog("Ticket Created", thisTicket.ToString()).ShowAsync();

            }
            catch (Exception ex)
            { var msg = new MessageDialog("Error!", ex.Message).ShowAsync(); }
        }

        private void LuckyDip(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket ticket = new Ticket();
                ticket.Name = NameText.Text;
                ticket.Phone = PhoneText.Text;
                ticket.LuckyDipGenerator();
                var msg = new MessageDialog("Lucky Dip Created!", ticket.ToString()).ShowAsync();
                tickets.Add(ticket);
                ticketlist.Add(ticket.ToString());
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error", ex.Message).ShowAsync();
            }
        }

        private void ticketlistview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            currenttickettext.Text = tickets[listView.SelectedIndex].ToString();
        }

        private void SearchButton(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket();
            for (int i = 0; i < tickets.Count; i++)
            {
                ticket = (Ticket)tickets[i];
                if (searchtext.Text.Equals(ticket.Phone))
                {
                    var msg = new MessageDialog("Found", ticket.Phone).ShowAsync();
                    ticketlistview.SelectedIndex = i;
                    ticketlistview.ScrollIntoView(ticketlist[i]);
                }
            }
        }
    }
}