namespace MongoIntegration.WebApi.Bootstrap
{
    public class DocumentStoreSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public bool ForceSsl { get; set; }
    }
}