namespace MongoIntegration.Framework
{
    public interface IQueryExecutor
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}