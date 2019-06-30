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

         public DatabaseConn()
        {
            string ServerName = "localhost";
            string DbName = "online_blood_bank";
            
            string UserName = "root";
            string ConnectionString = "server=" + ServerName + "; User Id=" + UserName + "; database=" + DbName;

            SqlConn = new MySqlConnection(ConnectionString);
        }



    }
    //All the Methods and the functions are in this section, Inherits DataBaseConn class
    class Functions:DatabaseConn
    {
        //Login function 
        //There's only one user with xxx name and xxx password so the given result of the record can be 0 or 1
        public bool Login(string Name, string Password)
        {
            try
            {
                string sql = "SELECT Count(user_id), user_id FROM user WHERE user_name = '" + Name + "' AND user_password= '" + Password + "' ";
                dt = new DataTable();
                adapter = new MySqlDataAdapter(sql, SqlConn);
                adapter.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                    

                }
                else
                    return false;
            }
            catch(MySqlException e)
            {
                e.GetType();
                return false;
                
            }
           
        }
    }
   
}
