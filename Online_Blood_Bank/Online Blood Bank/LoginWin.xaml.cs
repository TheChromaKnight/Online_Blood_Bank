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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseMethods;
using ErrorMessages;

namespace Online_Blood_Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        Functions db = new Functions();
        
        public LoginWin()
        {
            InitializeComponent();
           
            
        }
         
        //Login
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Name;
            string Password;
            int errors = 0;

    
            if(errors == 0)
            { 
               if (PwdLogin.Password.Length > 16)
               {
                   Messages.InvalidPasswordForm();
                    errors = 1;
               }
            }
            if(errors == 0)
            {
               if (TbUsername.Text.Length > 30)
               {
                   Messages.InvalidUserNameForm();
                    errors = 1;
               }
            }
            if(errors ==0)
            {
                //We cut out the extra white space characters with Trim()
                Name = TbUsername.Text.Trim();
                Password = PwdLogin.Password.Trim();

                if (Password != "" && Name != "")
                {
                    if (db.Login(Name, Password) == true)
                    {
                        Messages.SuccessfulLogin();
                        this.Close();


                        //We have to create the new window here, otherwise it will not close itself upon closing this window
                        UpdateWin upwin = new UpdateWin();
                        upwin.Close();
                    }
                    else if(db.Login(Name, Password) == false)
                    {
                        Messages.WrongPasswordOrName();
                    }
                    
                }
                else
                    Messages.EmptyFields();
 
            }
         
            
        }
    }
}
