using System.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace HealthNautica.DataAccess
{
    public static class DbFactory
    {
        public static string GetConnection(string dbName, string entity)
        {
            string connection = null;
            switch (entity)
            {
                case "Practice":
                    connection = GetConnectionString(dbName, Constants.PracticeMetadata, "PracticeEntities");
                    break;
                case "EOrder":
                    connection = GetConnectionString(dbName, Constants.EORderMetadata, "EORderEntities");
                    break;
            }

            return connection;

        }

        private static string GetConnectionString(string dbName, string metadata, string connection)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
            System.Data.SqlClient.SqlConnectionStringBuilder scsb = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString.Replace("dbname", dbName));

            return (new EntityConnectionStringBuilder
            {
                Metadata = metadata,
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = scsb.ConnectionString
            }).ConnectionString;
        }
    }

    public class Constants
    {
        public const string CommonMetadata = @"res://*/DbContexts.Common.csdl|res://*/DbContexts.Common.ssdl|res://*/DbContexts.Common.msl";
        public const string PracticeMetadata = @"res://*/DbContexts.Practice.csdl|res://*/DbContexts.Practice.ssdl|res://*/DbContexts.Practice.msl";
        public const string EORderMetadata = @"res://*/DbContexts.EOrder.csdl|res://*/DbContexts.EOrder.ssdl|res://*/DbContexts.EOrder.msl";

    }
}
