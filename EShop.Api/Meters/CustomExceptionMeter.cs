using System.Diagnostics.Metrics;

namespace EShop.Api.Meters
{
    public class CustomExceptionMeter :Meter
    {
        public const string ServiceName = "eshop-exception-meter";
        private const string ServiceVersion = "1.0.0";
        public Dictionary<string, Counter<int>> ApiExceptionCounters { get; }
        private readonly Dictionary<string, Counter<long>> _exceptionCounters = new Dictionary<string, Counter<long>>();

        public CustomExceptionMeter() : base(ServiceName, ServiceVersion)
        {
            ApiExceptionCounters = new Dictionary<string, Counter<int>>();
        }


        public void TrackApiException(string apiUrl, Exception ex)
        {
            string counterName = $"api_exception_count_{apiUrl.Replace("/", "_")}";

            if (!_exceptionCounters.ContainsKey(counterName))
            {
                _exceptionCounters[counterName] = CreateCounter<long>(counterName);
            }

            _exceptionCounters[counterName].Add(1, new KeyValuePair<string, object>("exception_type", ex.GetType().Name));
        }
    }
}
