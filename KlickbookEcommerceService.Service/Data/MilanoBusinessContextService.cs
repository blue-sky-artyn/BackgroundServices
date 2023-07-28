using KlickbookEcommerceService.Common.Model;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Service
{
    public class MilanoBusinessContextService : DbContext
    {
        //protected readonly IConfiguration _configuration;
        //public MilanoBusinessContextService(IConfiguration configuration)
        //{ 
        //    _configuration = configuration;
        //}
        public MilanoBusinessContextService(DbContextOptions<MilanoBusinessContextService> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleInvoicePaymentReceipt>().Ignore(x => x.ID);
            modelBuilder.Entity<ModuleInvoice>().Ignore(x => x.ID);
            modelBuilder.Entity<ModuleInvoicePaymentOther>().Ignore(x => x.ID);
            modelBuilder.Entity<ModuleInvoiceDetail>().Ignore(x => x.ID);
            modelBuilder.Entity<ModuleValue>().Ignore(x => x.ID);
            modelBuilder.Entity<ModuleValueExtension>().Ignore(x => x.ID);
            modelBuilder.Entity<ModuleInformation>().Ignore(x => x.ID);
            modelBuilder.Entity<KlickbookEcommerceService.Common.Model.Module>().Ignore(x => x.ID);
        }

        public DbSet<KlickbookEcommerceService.Common.Model.Module> Module { get; set; }
        public DbSet<ModuleInvoicePaymentReceipt> ModuleInvoicePaymentReceipt { get; set; }
        public DbSet<ModuleInvoice> ModuleInvoice { get; set; }
        public DbSet<ModuleInvoicePaymentOther> ModuleInvoicePaymentOther { get; set; }
        public DbSet<ModuleInvoiceItemDetail> ModuleInvoiceItemDetail { get; set; }
        public DbSet<ModuleInvoiceDetail> ModuleInvoiceDetail { get; set; }
        public DbSet<KlickbookEcommerceService.Common.Model.ModuleInformation> ModuleInformation { get; set; }
        public DbSet<KlickbookEcommerceService.Common.Model.ModuleValue> ModuleValue { get; set; }
        public DbSet<KlickbookEcommerceService.Common.Model.ModuleValueExtension> ModuleValueExtension { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // in memory database 
            //options.UseInMemoryDatabase("AspCore");
            //var connectionstring = _configuration.GetSection("Connection:DataModel").Value;
            //if (optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseMySQL(connectionstring,
            //     builder => builder.EnableRetryOnFailure());
            //     //.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            //}
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

        public T ExecSQLSingle<T>(string query)
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                Database.OpenConnection();

                T obj = default(T);
                using (var result = command.ExecuteReader())
                {
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
                    }
                }
                Database.CloseConnection();
                return obj;
            }
        }

        public List<T> ExecSQLThread<T>(string query, string connection)
        {
            var conn = new MySqlConnection(connection);
            using (var command = conn.CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                conn.Open();

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
                conn.Close();
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
