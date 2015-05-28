
namespace ITServices.Framework.Configurations
{
    using System;
    using System.Text;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Xml;

    public static class ITServicesConfiguration
    {
        private const string ConfigFilePath = @"D:\ITServices\Configurations\ITServices.config";
        private const string ApiBaseUrisSection = "apiBaseUris";
        private const string DbConnectionStringsSection = "dbConnectionStrings";
        private const string EnvironmentSection = "environment";
        public static string BaseUri
        {
            get;
            private set;
        }
        public static string Environment
        {
            get;
            private set;
        }
        public static string ConnectionString
        {
            get;
            private set;
        }
     
        public static void Initialize()
        {
            LoadConfigurationValues();
        }
        private static void LoadConfigurationValues()
        {
            var config = OpenConfigFile();
            ReadEnvironment(config);
            ReadApiBaseUri(config);
            ReadConnectionString(config);
        }

        private static void ReadApiBaseUri(Configuration config)
        {
            var apiBaseUriSection = GetSection(config, ApiBaseUrisSection);
            BaseUri = apiBaseUriSection[Environment];
        }

        private static void ReadEnvironment(Configuration config)
        {
            var environmentSection = GetSection(config, EnvironmentSection);
            Environment = environmentSection["Environment"].ToLower();
        }

        private static void ReadConnectionString(Configuration config)
        {
            var dbconnectionStringsSection = GetSection(config, DbConnectionStringsSection);
            ConnectionString = dbconnectionStringsSection[Environment];
            var encryptedpassword = GetEncryptedPassword();
            var decryptedpassword = Decrypt(encryptedpassword);

            ConnectionString = ConnectionString.Replace(encryptedpassword, "'" + decryptedpassword + "'");
        }

        private static Configuration OpenConfigFile()
        {
            var configMap = new ExeConfigurationFileMap {ExeConfigFilename = ConfigFilePath};
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config;
        }

        private static string GetEncryptedPassword()
        {
            const string lookupKey = "password=";

            var startIndex = ConnectionString.IndexOf(lookupKey, StringComparison.Ordinal) + lookupKey.Length;
            var length = ConnectionString.Length - startIndex - 1;
            var encryptedpassword = ConnectionString.Substring(startIndex, length);
            return encryptedpassword;
        }

        private  static NameValueCollection GetSection(Configuration config, string sectionName)
        {
            string section = config.GetSection(sectionName).SectionInformation.GetRawXml();
            var collection = HandlerCreatedCollection(section);
            return collection;
        }
        private static NameValueCollection HandlerCreatedCollection(string myParamsSectionRawXml)
        {
            var sectionXmlDoc = new XmlDocument();
            sectionXmlDoc.Load(new StringReader(myParamsSectionRawXml));
            var handler = new NameValueSectionHandler();

            var handlerCreatedCollection =
                handler.Create(null, null, sectionXmlDoc.DocumentElement) as NameValueCollection;
            return handlerCreatedCollection;
        }
        private static string Decrypt(string encryptedPassword)
        {
            var base64 = Convert.FromBase64String(encryptedPassword);
            return Encoding.ASCII.GetString(base64);
        }

    }
}