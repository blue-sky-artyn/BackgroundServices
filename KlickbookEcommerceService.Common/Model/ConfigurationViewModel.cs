using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace KlickbookEcommerceService.Common.Model
{ 
    public class ServiceSettings
    {
        public string externalapi { get; set; }
        public string externalurl { get; set; }
    }

    public class JwtSettings
    {
        public string issuer { get; set; }
        public string audience { get; set; }
        public string publickey { get; set; }
        public string privatekey { get; set; }
        public string privateolbkey { get; set; }
        public string publicolbkey { get; set; }
    }
    public class ConfigurationViewModel
    {
        public EngineSettingsViewModel middleware { get; set; }
        public EngineSettingsViewModel saasengine { get; set; }
        public EngineSettingsViewModel bireader { get; set; }
        public EngineSettingsViewModel booking { get; set; }
        public EngineSettingsViewModel fileupload { get; set; }
        public EngineSettingsViewModel filedownload { get; set; }
        public EngineSettingsViewModel eventbus { get; set; }
        public EngineSettingsViewModel masterdata { get; set; }
        public EngineSettingsViewModel crmengine { get; set; }
        public EngineSettingsViewModel modulecore { get; set; }
        public EngineSettingsViewModel integration { get; set; }
        public EngineSettingsViewModel reportengine { get; set; }
        public EngineSettingsViewModel journal { get; set; }
        public MongoConnectionSettings mongoconnection { get; set; }
        public JwtSettings jwtsettings { get; set; }
        public ServiceSettings servicesettings { get; set; }

    }
    public class EngineSettingsViewModel
    {
        public string port { get; set; }
        public string sslport { get; set; }
        public string protocol { get; set; }
        public string server { get; set; }
        public string instancename { get; set; }
    }

    public class MongoConnectionSettings
    {
        public string ip { get; set; }
        public string port { get; set; }
        public string collection { get; set; }
        public string security { get; set; }
        public string password { get; set; }
        public string username { get; set; }

    }
    public class SAASHeader
    {
        [FromHeader]
        public string tenant { get; set; }

        [FromHeader]
        public string useraccesskey { get; set; }

        [FromHeader]
        public string profilekey { get; set; }

        [FromHeader]
        public string Authorization { get; set; }
    }
}
