using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ConsoleUI
{
    class Ado
    {

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        static void Main2(string[] args)
        {

            string vConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection vConn = new SqlConnection(vConnStr);
            string vSql = "select * from Customers";
            SqlCommand sqlCommand  = new SqlCommand(vSql,vConn);

            try
            {
                vConn.Open();
                Console.WriteLine("Bağlantı OK");

                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                var list = DataReaderMapToList<Customers>(sqlDataReader);

                foreach (var item in list)
                {
                    Console.WriteLine(item.CustomerId + " " + item.CompanyName);
                }

                
                while(sqlDataReader.Read())
                {
                    Console.WriteLine(sqlDataReader["ContactName"]);
                    break;
                }
                
                
                vConn.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Bağlantı Olmadı" + e.Message);
            }

            
        }
    }

    class Customers
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }

    }
}
