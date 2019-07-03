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

        //We need to get the user id from LoginWin.xaml.cs, so we put an int into the constructor
        public Index(int UserId)
        {
            InitializeComponent();

            //Fill username and user rank fields
            TbIndexUserName.Text = Db.GetUserName(UserId);
            TbIndexUserRank.Text = Db.GetUserRank(UserId);
      

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
