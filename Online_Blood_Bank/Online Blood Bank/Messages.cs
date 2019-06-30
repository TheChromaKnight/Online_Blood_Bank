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
            MessageBox.Show("Succesful Login");
        }
    }
}
