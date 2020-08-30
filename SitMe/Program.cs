using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;


namespace SitMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var serviceScope = host.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ISqlDataAccess>();

            if (String.IsNullOrEmpty(context.ConnectionString) || !context.ConnectionAvailable)
            {

                //SqlConnection myConn = new SqlConnection("Server=localhost;Integrated Security=SSPI;database=master");
                //SqlConnection myConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlConnection myConn = new SqlConnection("Data Source=.\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                try
                {
                    myConn.Open();
                    // TODO
                    // Fix hardcoded filename (including file path) in SitMeDatabase.sql
                    SqlCommand myCommand = new SqlCommand(File.ReadAllText("SitMeDatabase.sql", Encoding.UTF8), myConn);
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("DataBase is Created Successfully");
                } catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                } finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        SqlCommand schemaPreSetup = new SqlCommand("USE[SitMeScriptCreated]", myConn);
                        schemaPreSetup.ExecuteNonQuery();

                        SqlCommand schema1 = new SqlCommand("CREATE SCHEMA[Admin]", myConn);
                        schema1.ExecuteNonQuery();
                        SqlCommand schema2 = new SqlCommand("CREATE SCHEMA[Client]", myConn);
                        schema2.ExecuteNonQuery();
                        SqlCommand schema3 = new SqlCommand("CREATE SCHEMA[Manager]", myConn);
                        schema3.ExecuteNonQuery();

                        SqlCommand tables = new SqlCommand(File.ReadAllText("CreateDBtables.sql", Encoding.UTF8), myConn);
                        tables.ExecuteNonQuery();

                        myConn.Close();
                    }

                    //TODO
                    // Append appsettings.json with Connection string of the newly created DB
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
