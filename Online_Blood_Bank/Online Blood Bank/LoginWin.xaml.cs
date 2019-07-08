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
        Functions Db = new Functions();
        public int UserId;
       

       
        public LoginWin()
        {
            InitializeComponent();
           
            
        }
         
        //Login
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Name;
            string Password;

            int SessionId;

            //Error variable to stop the program from progressing forward until every data is correct
           
            int Errors = 0;

            
            int DatabaseError = -1;

            //Password can't be longer than 16 chars,
            if (Errors == 0)
            { 
               if (PwdLogin.Password.Length > 16)
               {
                   Messages.InvalidPasswordForm();
                    Errors = 1;
               }
            }
            // username can't be longer than 30 chars
            if (Errors == 0)
            {
               if (TbUsername.Text.Length > 30)
               {
                   Messages.InvalidUserNameForm();
                    Errors = 1;
               }
            }
            if(Errors ==0)
            {
                //We cut out the extra white space characters with Trim()
                Name = TbUsername.Text.Trim();
                Password = PwdLogin.Password.Trim();

                
               
                

                if (Password != "" && Name != "")
                {
                    //Admin
                    if (Db.Login(Name, Password) == 1)
                    {
             
                        UserId = Db.ReturnUserId();

                        Messages.SuccessfulLogin();

                        SessionId = Db.GetSessionId();
                        
                        Db.StartSession(SessionId,  UserId);

                        //We have to create the new window here, otherwise it will not close itself upon closing this window
                        Index indexwin = new Index(UserId, SessionId);
                        indexwin.Show();


                        

                        this.Close();

                        if(Db.LastLoginCalculator(UserId)==DatabaseError)
                        {
                            Messages.SomethingWentWrong();
                        }
                        else
                        {
                            Messages.WelcomeBack(Db.LastLoginCalculator(UserId));
                            Db.UpdateLastLogin(UserId);
                        }
                       

                    }
                    
                    //Receptionist
                    else if(Db.Login(Name, Password) == 2)
                    {
                       
                        UserId = Db.ReturnUserId();
                       
                        Messages.SuccessfulLogin();

                        SessionId = Db.GetSessionId();

                        Db.StartSession(SessionId, UserId);
                       


                        //We have to create the new window here, otherwise it will not close itself upon closing this window
                        Index indexwin = new Index(UserId, SessionId);
                        indexwin.Show();

                        this.Close();

                        if (Db.LastLoginCalculator(UserId) == DatabaseError)
                        {
                            Messages.SomethingWentWrong();
                        }
                        else
                        {
                            Messages.WelcomeBack(Db.LastLoginCalculator(UserId));
                            Db.UpdateLastLogin(UserId);
                        }


                    }
                    //Member
                    else if(Db.Login(Name, Password) == 3)
                    {
                        UserId = Db.ReturnUserId();
                       
                        Messages.SuccessfulLogin();
                        
                        SessionId = Db.GetSessionId();

                     
                        Db.StartSession(SessionId, UserId);
                      

                        //We have to create the new window here, otherwise it will not close itself upon closing this window
                        Index indexwin = new Index(UserId, SessionId);
                        indexwin.Show();

                        this.Close();

                        if (Db.LastLoginCalculator(UserId) == DatabaseError)
                        {
                            Messages.SomethingWentWrong();
                        }
                        else
                        {
                            Messages.WelcomeBack(Db.LastLoginCalculator(UserId));
                            Db.UpdateLastLogin(UserId);
                        }
                    }
                    //No user found
                    else if(Db.Login(Name, Password) == 0)
                    {
                        Messages.WrongPasswordOrName();
                    }
                    //Connection error
                    else if(Db.Login(Name,Password) == 0)
                    {
                        Messages.ConnectionError();

                    }
                    
                }
                else
                    Messages.EmptyFields();
 
            }
            
        }

       
    }
}
