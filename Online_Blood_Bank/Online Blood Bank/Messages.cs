using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ErrorMessages
{
    static class Messages
    {
        public static void InvalidPasswordForm()
        {
            MessageBox.Show("The password cannot be longer than 16 characters!");
        }
        public static void InvalidUserNameForm()
        {
            MessageBox.Show("The username field cannot contain more than 30 characters");
        }

        public static void WrongPasswordOrName()
        {
            MessageBox.Show("Wrong password or username!");
        }
        public static void EmptyFields()
        {
            MessageBox.Show("Empty field(s)!");
        }
        public static void SuccessfulLogin()
        {
            MessageBox.Show("Succesful Login!");
        }
        public static void ConnectionError()
        {
            MessageBox.Show("A connection problem has occured. Please contact an admin!");
        }
        public static void SomethingWentWrong()
        {
            MessageBox.Show("Something Went Wrong!");
        }
        public static void WelcomeBack(int days)
        {
            MessageBox.Show("Welcome back! " + days + " days have passed since your last login. ");
        }
        public static void FirstLogin()
        {
            MessageBox.Show("Hello! We see that this is your first login, we would like to thank you for donating your blood. Click ok to receive our thanks :)");
        }

    }
}
