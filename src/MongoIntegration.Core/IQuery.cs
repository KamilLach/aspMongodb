namespace MongoIntegration.Core
{
    public interface IQuery<out TResult>
    {
        TResult Execute();
    }
}