using System;

namespace MongoIntegration.Framework.Implementation
{
    public class DefaultQueryExecutor : IQueryExecutor
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultQueryExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {

            var handlerType = typeof (IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof (TResult));
            dynamic handler = _serviceProvider.GetService(handlerType);
            return handler.Handle((dynamic)query);
        }
    }
}