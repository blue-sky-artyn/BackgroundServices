using KlickbookEcommerceService.Common;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Service
{
    public interface ITenantService
    {
        IList<Tenant> List(string companykey);
        Tenant Find(string key);
        ReplaceOneResult Replace(Tenant data);
        bool Delete();
        Tenant Create(Tenant tenant);
        Tenant FindCode(string code);
        IList<Tenant> ListAll();
        UpdateResult UpdateSetup(string tenant);
        UpdateResult UpdateTimeZone(string tenant, TimeZoneModel timeZone);
        TimeZoneInfo TenantTimezoneInfo(string tenant);
        Tuple<DateTime, DateTime, TimeZoneInfo> GetTenantDateRange(string tenant, string startDateString = null, string endDateString = null);
        DateTime ConvertToTenantTimezone(string tenant, DateTime Daterequest);
    }

    public class TenantService : ITenantService
    {
        protected IMongoCollection<Tenant> _db;
        public TenantService(IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase("SAASv2");
            _db = db.GetCollection<Tenant>("tenant");
        }

        public Tenant Create(Tenant tenant)
        {
            _db.InsertOneAsync(tenant).Wait();
            return _db.Find(x => x.key == tenant.key && x.active == true).SingleOrDefault();
        }
        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public Tenant Find(string key)
        {
            return _db.Find(x => x.key == key && x.active == true).SingleOrDefault();
        }

        public Tenant FindCode(string code)
        {
            return _db.Find(x => x.code == code && x.active == true).SingleOrDefault();
        }

        public IList<Tenant> List(string companykey)
        {
            return _db.Find(x => x.companykey == companykey && x.active == true).ToList();
        }

        public IList<Tenant> ListAll()
        {
            return _db.Find(x => x.active == true).ToList();
        }


        public ReplaceOneResult Replace(Tenant data)
        {
            return _db.ReplaceOne(x => x.id == data.id && x.active == true, data);
        }

        public UpdateResult UpdateTimeZone(string tenant, TimeZoneModel timeZone)
        {
            return _db.UpdateOne(x => x.key == tenant, new UpdateDefinitionBuilder<Tenant>().Set(x => x.settings.timezone, timeZone));
        }

        public UpdateResult UpdateSetup(string tenant)
        {
            return _db.UpdateOne(x => x.key == tenant, new UpdateDefinitionBuilder<Tenant>().Set(x => x.storesetup, true));
        }

        public TimeZoneInfo TenantTimezoneInfo(string tenant)
        {
            try
            {
                #region TimeZone
                var tenantSettings = Find(tenant);
                TimeZoneInfo tenantTimeZone = null;
                if (tenantSettings.settings.timezone != null)
                {
                    try
                    {
                        tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById(tenantSettings.settings.timezone.TimeZoneId);
                    }
                    catch (Exception ex)
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                        }
                        else
                        {
                            tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Toronto");
                        }

                    }

                }
                else
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    }
                    else
                    {
                        tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Toronto");
                    }
                }

                //DateTime startDate = Convert.ToDateTime(request.PStartDate);
                //DateTime endDate = Convert.ToDateTime(request.PEndDate).AddHours(23).AddMinutes(59).AddSeconds(59);
                //var offset = tenantTimeZone.BaseUtcOffset;

                //if (offset.TotalMinutes != 0)
                //{
                //    startDate = startDate.Add((offset * -1));
                //    endDate = endDate.Add((offset * -1));
                //}
                #endregion

                return tenantTimeZone;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Tuple<DateTime, DateTime, TimeZoneInfo> GetTenantDateRange(string tenant, string startDateString = null, string endDateString = null)
        {
            var tenantSettings = Find(tenant);
            TimeZoneInfo tenantTimeZone = null;
            if (tenantSettings.settings.timezone != null)
            {
                try
                {
                    tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById(tenantSettings.settings.timezone.TimeZoneId);
                }
                catch (Exception ex)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    }
                    else
                    {
                        tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Toronto");
                    }

                }

            }
            else
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                }
                else
                {
                    tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Toronto");
                }
            }
            DateTime startDate = Convert.ToDateTime(startDateString);
            DateTime endDate = Convert.ToDateTime(endDateString).AddHours(23).AddMinutes(59).AddSeconds(59);
            var offset = tenantTimeZone.BaseUtcOffset;

            if (offset.TotalMinutes != 0)
            {
                startDate = startDate.Add((offset * -1));
                endDate = endDate.Add((offset * -1));
            }
            return new Tuple<DateTime, DateTime, TimeZoneInfo>(startDate, endDate, tenantTimeZone);
        }

        public DateTime ConvertToTenantTimezone(string tenant, DateTime Daterequest)
        {
            var tenantSettings = Find(tenant);
            TimeZoneInfo tenantTimeZone = null;
            if (tenantSettings.settings.timezone != null)
            {
                try
                {
                    tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById(tenantSettings.settings.timezone.TimeZoneId);
                }
                catch (Exception ex)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    }
                    else
                    {
                        tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Toronto");
                    }

                }

            }
            else
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                }
                else
                {
                    tenantTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Toronto");
                }
            }

            var offset = tenantTimeZone.GetUtcOffset(Daterequest); //TIP
            DateTime timereponse = new DateTime();
            if (offset.TotalMinutes != 0)
            {
                timereponse = Daterequest.Add(offset);
            }
            return timereponse;
        }
    }
}
