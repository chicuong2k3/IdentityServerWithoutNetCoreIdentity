using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BookStore.Application.Behaviours
{
    internal sealed class PerformanceMetricBehaviour<TRequest, TResponse>(
        PerformanceMetricHandler performanceMetricHandler,
        Stopwatch timer)
         : IPipelineBehavior<TRequest, TResponse>
         where TRequest : class
         where TResponse : Result
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            timer.Start();  
            var response = await next();
            timer.Stop();

            performanceMetricHandler.AddMilliSecondsElapsed(timer.ElapsedMilliseconds);

            return response;
        }
    }
}
