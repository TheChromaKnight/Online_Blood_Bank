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
using System.Windows.Shapes;



namespace Online_Blood_Bank
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    /// 
    

    public partial class Index : Window
    {
        DatabaseMethods.Functions Db = new DatabaseMethods.Functions();
        int SessionId;

        int UserIsAdmin = 1;
        int UserIsReceptionist = 2;
        int UserIsMember = 3;

        //We need to get the user id from LoginWin.xaml.cs, so we put an int into the constructor
        public Index(int UserId, int SessionId, int UserRank)
        {
            InitializeComponent();
            this.SessionId = SessionId;

            //Fill username and user rank fields
            TbIndexUserName.Text = Db.GetUserName(UserId);
            TbIndexUserRank.Text = Db.GetUserRank(UserId);

            //MessageBox.Show(Convert.ToString(UserRank));

            //Checking the user rank and showing appropriate menu points

            //admin
            if(UserRank == UserIsAdmin)
            {
                BtnNewUser.Margin = new Thickness(0, 142, 0, 0);
                BtnNewUser.IsEnabled = true;
                ImgNewUser.Margin = new Thickness(2, 142, 0, 0);
                ImgNewUser.IsEnabled = true;

                BtnUsers.Margin = new Thickness(0, 202, 0, 0);
                BtnUsers.IsEnabled = true;
                ImgUsers.Margin = new Thickness(2, 202, 0, 0);
                ImgUsers.IsEnabled = true;

                BtnNewOffice.Margin = new Thickness(0, 259, 0, 0);
                BtnNewOffice.IsEnabled = true;
                ImgNewOffice.Margin = new Thickness(2, 259, 0, 0);
                ImgNewOffice.IsEnabled = true;
                
                BtnOffices.Margin = new Thickness(0, 317, 0, 0);
                BtnOffices.IsEnabled = true;
                ImgUsers.Margin = new Thickness(2, 317, 0, 0);
                ImgUsers.IsEnabled = true;

                BtnSessions.Margin = new Thickness(0, 375, 0, 0);
                BtnSessions.IsEnabled = true;
                ImgSessions.Margin = new Thickness(2, 375, 0, 0);
                ImgSessions.IsEnabled = true;


                BtnMyDonations.Visibility = Visibility.Hidden;
                ImgMyDonations.Visibility = Visibility.Hidden;

                BtnHelp.Visibility = Visibility.Hidden;
                ImgHelp.Visibility = Visibility.Hidden;

                BtnNewDonation.Visibility = Visibility.Hidden;
                ImgNewDonation.Visibility = Visibility.Hidden;

                BtnDonations.Visibility = Visibility.Hidden;
                ImgDonations.Visibility = Visibility.Hidden;


                
            }
            //Receptionist
            else if(UserRank == UserIsReceptionist)
            {


                BtnOffices.Margin = new Thickness(0, 142, 0, 0);
                BtnOffices.IsEnabled = true;
                ImgOffices.Margin = new Thickness(2, 143, 0, 0);
                ImgOffices.IsEnabled = true;

                BtnUsers.Margin = new Thickness(0, 202, 0, 0);
                BtnUsers.IsEnabled = true;
                ImgUsers.Margin = new Thickness(2, 202, 0, 0);
                ImgUsers.IsEnabled = true;

                BtnNewUser.Margin = new Thickness(0, 259, 0, 0);
                BtnNewUser.IsEnabled = true;
                ImgNewUser.Margin = new Thickness(2, 259, 0, 0);
                ImgNewUser.IsEnabled = true;

                BtnDonations.Margin = new Thickness(0, 317, 0, 0);
                BtnDonations.IsEnabled = true;
                ImgDonations.Margin = new Thickness(2, 317, 0, 0);
                ImgDonations.IsEnabled = true;

                BtnNewDonation.Margin = new Thickness(0, 375, 0, 0);
                BtnNewDonation.IsEnabled = true;
                ImgNewDonation.Margin = new Thickness(2, 375, 0, 0);
                ImgNewDonation.IsEnabled = true;

                BtnHelp.Margin = new Thickness(0, 434, 0, 0);
                BtnHelp.IsEnabled = true;
                ImgHelp.Margin = new Thickness(2, 434, 0, 0);
                ImgHelp.IsEnabled = true;


                BtnMyDonations.Visibility = Visibility.Hidden;
                ImgMyDonations.Visibility = Visibility.Hidden;

                BtnSessions.Visibility = Visibility.Hidden;
                ImgSessions.Visibility = Visibility.Hidden;

                BtnNewOffice.Visibility = Visibility.Hidden;
                ImgNewOffice.Visibility = Visibility.Hidden;


            }
            //Member
            else if (UserRank == UserIsMember)
            {
                BtnMyDonations.Margin = new Thickness(0, 133, 0, 0);
                BtnMyDonations.IsEnabled = true;
                ImgMyDonations.Margin = new Thickness(2, 133, 0, 0);
                ImgMyDonations.IsEnabled = true;

                BtnOffices.Margin = new Thickness(0, 186, 0, 0);
                BtnOffices.IsEnabled = true;
                ImgOffices.Margin = new Thickness(2, 186, 0, 0);
                ImgOffices.IsEnabled = true;

                BtnHelp.Visibility = Visibility.Hidden;
                ImgHelp.Visibility = Visibility.Hidden;

                BtnUsers.Visibility = Visibility.Hidden;
                ImgUsers.Visibility = Visibility.Hidden;

                BtnNewUser.Visibility = Visibility.Hidden;
                ImgNewUser.Visibility = Visibility.Hidden;

                BtnNewOffice.Visibility = Visibility.Hidden;
                ImgNewOffice.Visibility = Visibility.Hidden;

                BtnSessions.Visibility = Visibility.Hidden;
                ImgSessions.Visibility = Visibility.Hidden;

                BtnNewDonation.Visibility = Visibility.Hidden;
                ImgNewDonation.Visibility = Visibility.Hidden;

                BtnDonations.Visibility = Visibility.Hidden;
                ImgDonations.Visibility = Visibility.Hidden;


            }




        }

        // The usual design for the application is to let the user drag the window by the upper part 
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Upper right corner X icon
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Db.EndSession(SessionId);
            //MessageBox.Show(SessionId.ToString());
            this.Close();
            
        }

        //Upper right corner Maximize icon
        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
           
        }

        //Upper right corner minimize icon
        private void HideWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        //Menu icon
        private void BtnImageMenuIcon_Click(object sender, RoutedEventArgs e)
        {
            Thickness ImageMenuMargin = ImageMenuIcon.Margin;
            
            //When we close the menu, the grids should align to the closed menu size
            void CloseMenu()
            {
               

                ImageMenuMargin.Top = 28;
                ImageMenuMargin.Left = 58;

                BtnImageMenuIcon.Margin = new Thickness(58, 28, 0, 0);
                GridContent.Margin = new Thickness(58, 184, 0, 0);
                GridHeader.Margin = new Thickness(58,105,0,0);
                GridOptions.Margin = new Thickness(58, 10, 0, 0);


                GridMenu.Width = 58;
               

                BtnHome.Visibility = Visibility.Hidden;
                BtnMyDonations.Visibility = Visibility.Hidden;
                BtnOffices.Visibility = Visibility.Hidden;
                BtnHelp.Visibility = Visibility.Hidden;
                BtnUsers.Visibility = Visibility.Hidden;
                BtnNewUser.Visibility = Visibility.Hidden;

                TbIndexUserName.Visibility = Visibility.Hidden;
                TbIndexUserRank.Visibility = Visibility.Hidden;


                
                
            }

            //When we open the menu, we need to give back the base position of the grids
            void OpenMenu()
            {
                
                ImageMenuMargin.Left = 185;
                ImageMenuMargin.Top = 28;

                BtnImageMenuIcon.Margin = new Thickness(187, 28, 0, 0);
                GridContent.Margin = new Thickness(185, 184, 0, 0);
                GridHeader.Margin = new Thickness(185, 105, 0, 0);
                GridOptions.Margin = new Thickness(185, 10, 0, 0);

                GridMenu.Width = 185;

                BtnHome.Visibility = Visibility.Visible;
                BtnMyDonations.Visibility = Visibility.Visible;
                BtnOffices.Visibility = Visibility.Visible;
                BtnHelp.Visibility = Visibility.Visible;
                BtnUsers.Visibility = Visibility.Visible;
                BtnNewUser.Visibility = Visibility.Visible;

                TbIndexUserName.Visibility = Visibility.Visible;
                TbIndexUserRank.Visibility = Visibility.Visible;

            }
            if (BtnHome.Visibility == Visibility.Visible)
            {
                CloseMenu();
            }
            else 
            {
                OpenMenu();

            }
        }

       
    }
}
