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

        ArrayList myWinningTickets = new ArrayList();
        ObservableCollection<String> myWinningTicketList = new ObservableCollection<String>();

        LottoDraw NewDraw;

        LottoFiles filesfunctions = new LottoFiles();


        public MainPage()
        {
            this.InitializeComponent();
            tickets = filesfunctions.readTicketsFromFile();
            foreach(Ticket t in tickets)
            {
                ticketlist.Add(t.ToString());
            }
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

        private void createNewDraw(object sender, RoutedEventArgs e)
        {
            //create a new draw
            NewDraw = new LottoDraw();

            //display draw
            drawball1text.Text = NewDraw.drawballs[0].ToString();
            drawball2text.Text = NewDraw.drawballs[1].ToString();
            drawball3text.Text = NewDraw.drawballs[1].ToString();
            drawball4text.Text = NewDraw.drawballs[1].ToString();
            drawball5text.Text = NewDraw.drawballs[1].ToString();
            drawball6text.Text = NewDraw.drawballs[1].ToString(); 
            bonusballtext.Text = NewDraw.bonusBall.ToString();

            //stop new tickets being generated
            NameText.IsEnabled = false;
            PhoneText.IsEnabled = false;
            Ball1.IsEnabled = false;
            Ball2.IsEnabled = false;
            Ball3.IsEnabled = false;
            Ball4.IsEnabled = false;
            Ball5.IsEnabled = false;
            Ball6.IsEnabled = false;

            //check for winning ticket
            foreach (Ticket t in tickets)
            {
                int win = NewDraw.CheckTicket(t);

                if (win > 0)
                {
                    myWinningTickets.Add(t);

                    switch (win)
                    {
                        case 1:
                        case 2:
                            myWinningTicketList.Add(t.ToString() + " - Win free draw");
                            break;
                        case 3:
                            myWinningTicketList.Add(t.ToString() + " - £10 win!");
                            break ;
                            case 4:
                            myWinningTicketList.Add(t.ToString() + " - £100 win!");
                            break;
                        case 5:
                            myWinningTicketList.Add(t.ToString() + " - £1000 win!");
                            break;
                        case 6:
                            myWinningTicketList.Add(t.ToString() + " - Jackpot win!");
                            break;
                        case 7:
                            myWinningTicketList.Add(t.ToString() + " - Bonus ball win!");
                            break;  

                            default:
                            break;

                    }
                }
            }
        }

        private void exitProgram(object sender, RoutedEventArgs e)
        {
            filesfunctions.writeTickets(tickets);
            Application.Current.Exit();

        }
    }
}