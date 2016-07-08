using MongoDB.Driver;

namespace MongoIntegration.WebApi.Bootstrap
{
    public interface IDocumentDbContextProvider
    {
        IMongoDatabase CreateContext();
    }
}