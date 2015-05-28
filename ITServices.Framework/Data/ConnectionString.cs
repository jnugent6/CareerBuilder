using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml.Serialization.Configuration;
//using ITServices.Framework.Configurations;
using ITServices.Framework.Data.Models;
using Newtonsoft.Json;

namespace ITServices.Framework.Data
{
    public class ConnectionString
    {
     
        public static string GetConnnectionString()
        {
            var jsonConnection = ReadJsonConnectionString();
            var connection = SetConnection(jsonConnection);

            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = connection.Server,
                InitialCatalog = connection.Database,
                UserID = connection.UserID,
                Password = connection.Password
            };

            return sqlBuilder.ToString();
        }
        private static Connection SetConnection(JSONConnection jsonConnection)
        {
            //var env = ITServicesConfig.RunMode;
            var connection = new Connection();

            //if (env == ITServicesConfig.Env.Development.ToString() || env == null)
            //    connection = GetDevelopmentConnection(jsonConnection);
            //else if (env == ITServicesConfig.Env.Test.ToString() )
            //    connection = GetDevelopmentConnection(jsonConnection);
            //else if (env == ITServicesConfig.Env.Production.ToString())
            //    connection = GetProductionConnection(jsonConnection);
            return connection;
        }
        private static Connection GetDevelopmentConnection(JSONConnection jsonConnection)
        {
            var dev = new Connection
            {
                Server = jsonConnection.Connections.Development.Server,
                Database = jsonConnection.Connections.Development.Database,
                UserID = jsonConnection.Connections.Development.UserID
            };

            dev.Password = Decrypt(jsonConnection.Connections.Development.Password);
            return dev;
        }
        private static Connection GetProductionConnection(JSONConnection jsonConnection)
        {
            var dev = new Connection
            {
                Server = jsonConnection.Connections.Production.Server,
                Database = jsonConnection.Connections.Production.Database,
                UserID = jsonConnection.Connections.Production.UserID
            };

            dev.Password = Decrypt(jsonConnection.Connections.Production.Password);
            return dev;
        }
        private static string Decrypt(string encryptedPassword)
        {
            var base64 = Convert.FromBase64String(encryptedPassword);
            return Encoding.ASCII.GetString(base64);
        }
        private static JSONConnection ReadJsonConnectionString()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return JsonConvert.DeserializeObject<JSONConnection>(File.ReadAllText(path + @"..\..\" + "Connections.json"));
        }
    }
}