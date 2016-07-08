namespace MongoIntegration.Core
{
    public interface IParametrizedQuery<out TResult, in TParam>
    {
        TResult Execute(TParam param);
    }
}