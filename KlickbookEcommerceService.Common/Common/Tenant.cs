using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common
{
    public class Tenant
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string key { get; set; }
        public string companykey { get; set; }
        public string mastertenantkey { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public List<Address> address { get; set; } = new List<Address>();
        public List<Contact> contact { get; set; } = new List<Contact>();
        public StoreSettings settings { get; set; } = new StoreSettings();
        public ClassicSettings classicsettings { get; set; } = new ClassicSettings();
        public HeadOffice headoffice { get; set; } = new HeadOffice();
        public MFA mfa { get; set; } = new MFA();
        public bool storesetup { get; set; } = false;
        public bool active { get; set; }
        public long created { get; set; }

    }

    public class MFA
    {
        public bool emailenabled { get; set; } = false;
        public bool phoneenabled { get; set; } = false;
    }

    public class HeadOfficeTenant
    {
        public string name { get; set; }
        public string code { get; set; }
        public string key { get; set; }
    }

    public class HeadOffice
    {
        public List<HeadOfficeTenant> tenants { get; set; } = new List<HeadOfficeTenant>();
        public bool enabled { get; set; } = false;
    }

    public class ClassicSettings
    {
        public string url { get; set; }
        public string storekey { get; set; }
        public string? hostby { get; set; }
        public bool enabled { get; set; } = false;
    }
    public class StoreSettings
    {
        public string? icon { get; set; }
        public string? logo { get; set; }
        public string? storeimage { get; set; }
        public int? openbuffer { get; set; }
        public int? closebuffer { get; set; }
        public string? fontfamily { get; set; }
        public string? primarycolor { get; set; }
        public string? secondarycolor { get; set; }
        public string? language { get; set; }
        public string? name { get; set; }
        public StoreHours[]? operationalhours { get; set; }
        public StoreHours[]? holidayhours { get; set; }
        public List<string>? registrationfields { get; set; }
        public List<Address> address { get; set; } = new List<Address>();
        public List<Contact> contact { get; set; } = new List<Contact>();
        public List<ValidationSettings>? validation { get; set; }
        public TimeZoneModel? timezone { get; set; }
        public ApiVersionControl? apiversion { get; set; }
        public CashOutSetting? cashout { get; set; }
    }
    public class ApiVersionControl
    {
        public string defaulturl { get; set; } = "API";
        public List<ApiVersions> apicontrol { get; set; } = new List<ApiVersions>();
    }
    public class ApiVersions
    {
        public string method { get; set; }
        public string url { get; set; }
    }
    public class TimeZoneModel
    {
        public string TimeZoneId { get; set; }
        public string DisplayName { get; set; }
        public TimeSpan BaseUTCOffset { get; set; }
    }

    public class StoreHours
    {
        public string day { get; set; }
        public string open { get; set; }
        public string close { get; set; }
    }
  
    public class CashOutSetting
    {
        public bool taxbeforediscount { get; set; } = false;
    }

    public class Address
    {
        public string address { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }

    public class Contact
    {
        public string? value { get; set; }
        public string? type { get; set; }
    }

    public class ValidationSettings
    {
        public string modulename { get; set; }
        public List<ValidationModule> validationrules { get; set; }
    }

    public class ValidationModule
    {
        public string fieldname { get; set; }
        public List<FieldRules> rules { get; set; }
    }

    public class FieldRules
    {
        public string operation { get; set; }
        public string rule { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public string responsecode { get; set; }
    }
}
