using Library.DataAccess.SqlServer;
using Library.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Library
{
    public partial class App : Application
    {
        public static IUnitOfWork Db;
        public App()
        {

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "STHQ0127-11";
            sqlConnectionStringBuilder.InitialCatalog = "Library";
            // sqlConnectionStringBuilder.IntegratedSecurity = true;
            sqlConnectionStringBuilder.UserID = "admin";
            sqlConnectionStringBuilder.Password = "admin";
            Db = new SqlUnitOfWork(sqlConnectionStringBuilder.ToString());
        }


    }
}
