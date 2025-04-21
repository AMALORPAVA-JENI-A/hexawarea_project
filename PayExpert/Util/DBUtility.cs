using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace PayExpert.Util
{
    internal class DBUtility
    {
        const string connectionString = @"Server =LAPTOP-8EEUCOL7\SQLEXPRESS ; Database = payexpert ; Integrated Security =True ; MultipleActiveResultSets=true;";
        
        public static SqlConnection GetConnection()
        {
            SqlConnection connectionObject = new SqlConnection(connectionString);
            try
            {
                connectionObject.Open();
                return connectionObject;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error opening the Connection:{e.Message}");
                return null;
            }
        }
        public static void CloseDbConnection(SqlConnection connectionObject)
        {
            if (connectionObject != null)
            {
                try
                {
                    if (connectionObject.State != ConnectionState.Open)
                    {
                        connectionObject.Close();
                        connectionObject.Dispose();
                        Console.WriteLine("connection closed.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error closingconnection{e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Connection is already null");
            }
        }
    }
}

