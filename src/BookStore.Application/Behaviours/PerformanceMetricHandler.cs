using System.Diagnostics.Metrics;

namespace BookStore.Application.Behaviours
{
    internal sealed class PerformanceMetricHandler
    {
        private readonly Counter<long> milliSecondsElapsed;
        public PerformanceMetricHandler(IMeterFactory meterFactory)
        {
            var meter = meterFactory.Create("BookStore");

            milliSecondsElapsed = meter.CreateCounter<long>("bookstore.milliseconds-elapsed");
        }

        public void AddMilliSecondsElapsed(long millisecondsElapsed)
        {
            milliSecondsElapsed.Add(millisecondsElapsed);
        }
    }
}
