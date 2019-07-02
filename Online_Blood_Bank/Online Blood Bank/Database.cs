using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DatabaseMethods
{
    //Connection to database
    class DatabaseConn
    {
        protected MySqlConnection SqlConn;
        protected MySqlCommand SqlCmd;
        protected DataTable dt;
        protected MySqlDataAdapter adapter;

        protected DatabaseConn()
        {
           string ServerName = "localhost";
           string DbName = "online_blood_bank";
            
           string UserName = "root";
           string ConnectionString = "server=" + ServerName + "; User Id=" + UserName + "; database=" + DbName;

           SqlConn = new MySqlConnection(ConnectionString);
        }
         
        protected void OpenConnect()
        {
            if(SqlConn != null && SqlConn.State == ConnectionState.Closed)
            {
                SqlConn.Open();
            }
        }

        protected void CloseConnect()
        {
            if(SqlConn != null && SqlConn.State == ConnectionState.Open)
            {
                SqlConn.Close();
            }
        }

        
    }
    //All the Methods and the functions are in this section, Inherits DataBaseConn class
    class Functions:DatabaseConn
    {
        public int UserId;


        //Login function 
        //There's only one user with xxx name and xxx password so the given result of the record can be 0 or 1
        //However we need the user rank so we cannot just give back a true or false
        public int Login(string Name, string Password)
        {
            int Error = -1;
            int NoUserFound = 0;
            int UserIsAdmin = 1;
            int UserIsReceptionist = 2;
            int UserIsMember = 3;

            //Database gives back strings, so we first need to store in in the StrUserId variable
            string StrUserId;
    

            try
            {
                OpenConnect();

                string sql = "SELECT Count(user_id), user_id, user_rank_id FROM user WHERE user_name = '" + Name + "' AND user_password= '" + Password + "' ";
                dt = new DataTable();
                adapter = new MySqlDataAdapter(sql, SqlConn);
                adapter.Fill(dt);


                //We store the data, then convert it into int and it is now stored in the public member
                StrUserId = dt.Rows[0][1].ToString();
                UserId = Convert.ToInt32(StrUserId);



                if (dt.Rows[0][0].ToString() == "1" && dt.Rows[0][2].ToString() == "1")
                {
                    return UserIsAdmin;
                }
                else if(dt.Rows[0][0].ToString() == "1" && dt.Rows[0][2].ToString() == "2")
                {
                    return UserIsReceptionist;
                }
                else if (dt.Rows[0][0].ToString() == "1" && dt.Rows[0][2].ToString() == "3")
                {
                    return UserIsMember;
                }
                else
                    return NoUserFound;


                

            }
            catch(MySqlException e)
            {
                e.GetType();
                return Error;
                
            }
            finally
            {
                CloseConnect();
            }

        }

        public int ReturnUserId()
        {
            return UserId;
        }


        public string LastLoginCalculator()
        {





            return "";
        }
    }


    
   
}
