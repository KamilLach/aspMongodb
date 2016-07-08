using System.Security.Authentication;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoIntegration.WebApi.Bootstrap
{
    public class DocumentDbContextProvider : IDocumentDbContextProvider
    {
        private readonly IOptions<DocumentStoreSettings> _settings;

        public DocumentDbContextProvider(IOptions<DocumentStoreSettings> settings)
        {
            _settings = settings;
        }

        public IMongoDatabase CreateContext()
        {
            var clientSettings = new MongoClientSettings()
            {
                Server = new MongoServerAddress(_settings.Value.Host, _settings.Value.Port),
                UseSsl = _settings.Value.ForceSsl,
                SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 }
            };
            
            var client = new MongoClient(clientSettings);
            return client.GetDatabase(_settings.Value.Database);
        }
    }
}