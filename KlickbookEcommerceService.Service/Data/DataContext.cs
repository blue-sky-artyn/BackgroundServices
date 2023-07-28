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

namespace KlickbookEcommerceService.Data
{
    //public class DataContextService : DbContext
    //{
    //    public DataContextService(DbContextOptions<DataContextService> options) : base(options)
    //    {

    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        //optionsBuilder.UseMySql(@"server=localhost;database=BookStoreDb;uid=root;password=;");
    //    }

    //    //public DbSet<KlickbookEcommerceService.Common.Model.Module> Module { get; set; }
    //    //public DbSet<ModuleInvoicePaymentReceipt> ModuleInvoicePaymentReceipt { get; set; }
    //    //public DbSet<ModuleInvoice> ModuleInvoice { get; set; }
    //    //public DbSet<ModuleInvoicePaymentOther> ModuleInvoicePaymentOther { get; set; }
    //    //public DbSet<ModuleInvoiceItemDetail> ModuleInvoiceItemDetail { get; set; }
    //    //public DbSet<ModuleInvoiceDetail> ModuleInvoiceDetail { get; set; }
    //    //public DbSet<ModuleInformation> ModuleInformation { get; set; }
    //    //public DbSet<ModuleValue> ModuleValue { get; set; }
    //    //public DbSet<ModuleValueExtension> ModuleValueExtension { get; set; }

    //    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    //{
    //    //    modelBuilder.Entity<ModuleInvoicePaymentReceipt>().HasKey(b => b.PaymentReceiptId)
    //    //.HasName("PrimaryKey_PaymentReceiptId");//.Ignore(x => x.ID);
    //    //    modelBuilder.Entity<ModuleInvoice>().HasKey(b => b.ModuleInvoiceId)
    //    //.HasName("PrimaryKey_ModuleInvoiceId");//.Ignore(x => x.ID);
    //    //    modelBuilder.Entity<ModuleInvoicePaymentOther>().HasKey(b => b.ModuleInvoicePaymentOtherId)
    //    //.HasName("PrimaryKey_ModuleInvoicePaymentOtherId");//.Ignore(x => x.ID);
    //    //    modelBuilder.Entity<ModuleInvoiceDetail>().HasKey(b => b.ModuleInvoiceDetailId)
    //    //.HasName("PrimaryKey_ModuleInvoiceDetailId");//.Ignore(x => x.ID);
    //    //    modelBuilder.Entity<ModuleValue>().HasKey(b => b.ModuleValueId)
    //    //.HasName("PrimaryKey_ModuleValueId");//.Ignore(x => x.ID);
    //    //    modelBuilder.Entity<ModuleValueExtension>().HasKey(b => b.ModuleValueExtensionId)
    //    //.HasName("PrimaryKey_ModuleValueExtensionId");//.Ignore(x => x.ID);
    //    //    modelBuilder.Entity<ModuleInformation>().HasKey(b => b.ModuleId)
    //    //.HasName("PrimaryKey_ModuleId");//.Ignore(x => x.ID);
    //    //    modelBuilder.Entity<KlickbookEcommerceService.Common.Model.Module>().HasKey(b => b.ModuleId)
    //    //.HasName("PrimaryKey_ModuleId");//.Ignore(x => x.ID);
    //    //}

    //    public List<T> ExecSQL<T>(string query)
    //    {
    //        using (var command = Database.GetDbConnection().CreateCommand())
    //        {
    //            command.CommandText = query;
    //            command.CommandType = CommandType.Text;
    //            Database.OpenConnection();

    //            List<T> list = new List<T>();
    //            using (var result = command.ExecuteReader())
    //            {
    //                T obj = default(T);
    //                while (result.Read())
    //                {
    //                    obj = Activator.CreateInstance<T>();
    //                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
    //                    {
    //                        if (HasColumn(result, prop.Name) && !object.Equals(result[prop.Name], DBNull.Value))
    //                        {
    //                            prop.SetValue(obj, result[prop.Name], null);
    //                        }
    //                    }
    //                    list.Add(obj);
    //                }
    //            }
    //            Database.CloseConnection();
    //            return list;
    //        }
    //    }

    //    public T ExecSQLSingle<T>(string query)
    //    {
    //        using (var command = Database.GetDbConnection().CreateCommand())
    //        {
    //            command.CommandText = query;
    //            command.CommandType = CommandType.Text;
    //            Database.OpenConnection();

    //            T obj = default(T);
    //            using (var result = command.ExecuteReader())
    //            {
    //                while (result.Read())
    //                {
    //                    obj = Activator.CreateInstance<T>();
    //                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
    //                    {
    //                        if (HasColumn(result, prop.Name) && !object.Equals(result[prop.Name], DBNull.Value))
    //                        {
    //                            prop.SetValue(obj, result[prop.Name], null);
    //                        }
    //                    }
    //                }
    //            }
    //            Database.CloseConnection();
    //            return obj;
    //        }
    //    }

    //    public List<T> ExecSQLThread<T>(string query, string connection)
    //    {
    //        var conn = new MySqlConnection(connection);
    //        using (var command = conn.CreateCommand())
    //        {
    //            command.CommandText = query;
    //            command.CommandType = CommandType.Text;
    //            conn.Open();

    //            List<T> list = new List<T>();
    //            using (var result = command.ExecuteReader())
    //            {
    //                T obj = default(T);
    //                while (result.Read())
    //                {
    //                    obj = Activator.CreateInstance<T>();
    //                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
    //                    {
    //                        if (HasColumn(result, prop.Name) && !object.Equals(result[prop.Name], DBNull.Value))
    //                        {
    //                            prop.SetValue(obj, result[prop.Name], null);
    //                        }
    //                    }
    //                    list.Add(obj);
    //                }
    //            }
    //            conn.Close();
    //            return list;
    //        }
    //    }

    //    public static bool HasColumn(System.Data.Common.DbDataReader Reader, string ColumnName)
    //    {
    //        foreach (DataRow row in Reader.GetSchemaTable().Rows)
    //        {
    //            if (row["ColumnName"].ToString() == ColumnName)
    //                return true;
    //        }
    //        return false;
    //    }

    //}
}
