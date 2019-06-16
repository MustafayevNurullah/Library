using Library.DataAccess.SqlServer;
using Library.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using System.Windows;

namespace Library
{
    public partial class App : Application
    {
        public static IUnitOfWork Db;
        public App()
        {
       
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr");
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-A8D17ST";
            sqlConnectionStringBuilder.InitialCatalog = "Library";
             sqlConnectionStringBuilder.IntegratedSecurity = true;
            //sqlConnectionStringBuilder.UserID = "admin";
            //sqlConnectionStringBuilder.Password = "admin";
            Db = new SqlUnitOfWork(sqlConnectionStringBuilder.ToString());
        }


    }
}
