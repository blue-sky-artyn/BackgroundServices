using KlickbookEcommerceService.Common.Model;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KlickbookEcommerceService.Common;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace KlickbookEcommerceService.Service
{
    public class XcardDataContext : DbContext
    {
        public XcardDataContext(DbContextOptions<XcardDataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<KlickbookEcommerceService.Common.Model.Module>().HasKey(x => new { x.ID });
            //modelBuilder.Entity<KlickbookEcommerceService.Common.Model.Module>().HasAlternateKey(t => new { t.ModuleId });
            //modelBuilder.Entity<KlickbookEcommerceService.Common.Model.Module>().Ignore(x => x.ID);
        }

        public DbSet<ProductsModel> klickbookinvent { get; set; }
        public DbSet<KBcategoryListModel> KlickbookProductCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configuration = ConfigurationManager.GetSection("Connection:DataModel");
            //optionsBuilder.UseMySQL(connectionString ?? throw new NullReferenceException("Empty connection string"));

            // MariaDB 10.1.41
            //optionsBuilder
            //    .UseMySQL(configuration.ToString())
            //    .UseLoggerFactory(LoggerFactory.Create(b => b
            //        .AddConsole()
            //        .AddFilter(level => level >= LogLevel.Information)))
            //    .EnableSensitiveDataLogging();
        }

        public List<T> ExecSQL<T>(string query)
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                Database.OpenConnection();

                List<T> list = new List<T>();
                using (var result = command.ExecuteReader())
                {
                    T obj = default(T);
                    while (result.Read())
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        {
                            if (HasColumn(result, prop.Name) && !object.Equals(result[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, result[prop.Name], null);
                            }
                        }
                        list.Add(obj);
                    }
                }
                Database.CloseConnection();
                return list;
            }
        }

        public static bool HasColumn(System.Data.Common.DbDataReader Reader, string ColumnName)
        {
            foreach (DataRow row in Reader.GetSchemaTable().Rows)
            {
                if (row["ColumnName"].ToString() == ColumnName)
                    return true;
            }
            return false;
        }

    }
}
