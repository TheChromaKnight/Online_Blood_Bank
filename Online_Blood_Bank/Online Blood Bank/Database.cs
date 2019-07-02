﻿using System;
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
        protected DataTable Dt;
        protected MySqlDataAdapter Adapter;

        protected DatabaseConn()
        {
           string ServerName = "localhost";
           string DbName = "online_blood_bank";
            
           string UserName = "root";
           string ConnectionString = "server=" + ServerName + "; User Id=" + UserName + "; database=" + DbName;

           SqlConn = new MySqlConnection(ConnectionString);
        }
         
        protected void OpenConnection()
        {
            if(SqlConn != null && SqlConn.State == ConnectionState.Closed)
            {
                SqlConn.Open();
            }
        }

        protected void CloseConnection()
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
            const int Error = -1;
            const int NoUserFound = 0;
            const int UserIsAdmin = 1;
            const int UserIsReceptionist = 2;
            const int UserIsMember = 3;

            //Database gives back strings, so we first need to store in in the StrUserId variable then convert it to int.
            //Before converting we need to check if the value is larger than 0
            string StrUserId;

    

            try
            {
                SqlConn.Open();

                string Sql = "SELECT Count(user_id), user_id, user_rank_id FROM user WHERE user_name = '" + Name + "' AND user_password= '" + Password + "' ";
                Dt = new DataTable();
                Adapter = new MySqlDataAdapter(Sql, SqlConn);
                Adapter.Fill(Dt);


                //We store the data, then convert it into int and it is now stored in the public member
               
              
               
               

                //We need to check if the dataTable actually has rows
                if (Dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(Dt.Rows[0][0]) != 0)
                    {
                        StrUserId = Dt.Rows[0][1].ToString();
                        UserId = Convert.ToInt32(StrUserId);
                    }
                  

                    if (Dt.Rows[0][0].ToString() == "1" && Dt.Rows[0][2].ToString() == "1")
                    {
                        return UserIsAdmin;
                    }
                    else if (Dt.Rows[0][0].ToString() == "1" && Dt.Rows[0][2].ToString() == "2")
                    {
                        return UserIsReceptionist;
                    }
                    else if (Dt.Rows[0][0].ToString() == "1" && Dt.Rows[0][2].ToString() == "3")
                    {
                        return UserIsMember;
                    }
                    else
                        return NoUserFound;
                }
                else
                    return Error;

            }
            catch(MySqlException e)
            {
                e.GetType();
                return Error;
                
            }
            finally
            {
                SqlConn.Close();
            }
           

        }
        //UserId field
        public int ReturnUserId()
        {
            return UserId;
        }

        //Calculate the days since the last login, we need the parameter because we can't get the field's value from here (I believe)
        public int LastLoginCalculator(int UniqueUserId)
        {
            
            
            const int Error = -1;
            string Result;
            int DayNumber;
            
            
            try
            {
                OpenConnection();

                //With the help of DATEDIFF function we get the actual day since the last login
                string Sql = "SELECT DATEDIFF(NOW(), user_last_login) FROM user WHERE user_id = " + UniqueUserId+" ";

                Adapter = new MySqlDataAdapter(Sql, SqlConn);
                Dt = new DataTable();   
                Adapter.Fill(Dt);

                //We need to check if the dataTable actually has rows
                if (Dt.Rows.Count > 0)
                {
                    Result = Dt.Rows[0][0].ToString();

                    DayNumber = Convert.ToInt32(Result);
                    return DayNumber;
                }
                else return Error ;
                    
      
            }
            catch(Exception e)
            {
                return Error;
            }
            finally
            {
                CloseConnection();
            }
        
        }

        public void UpdateLastLogin(int UniqueUserId)
        {
            try
            {
                OpenConnection();

                string Sql = "Update user SET user_last_login = CURDATE() WHERE user_id = "+UniqueUserId+"";

                SqlCmd = new MySqlCommand(Sql,SqlConn);

                SqlCmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                e.GetType();
            }
            finally
            {
                CloseConnection();
            }
        }
    }


    
   
}
