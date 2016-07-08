namespace MongoIntegration.Core
{
    public interface IParametrizedCommand<in TParam>
    {
        void Execute(TParam param);
    }
}