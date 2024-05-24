using System.Diagnostics.Metrics;

namespace EShop.Api.Meters
{
    public class SuccessfulApiMeter:Meter
    {
        public const string ServiceName = "eshop-successful-api-meter";
        private const string ServiceVersion = "1.0.0";
        private readonly Dictionary<string, Counter<long>> _successCounters = new Dictionary<string, Counter<long>>();

        public SuccessfulApiMeter() : base(ServiceName, ServiceVersion)
        {
        }
        public void TrackSuccessfulApiRequest(HttpContext httpContext, string apiUrl)
        {
            string counterName = $"successful_api_requests_{apiUrl.Replace("/", "_")}";

            if (!_successCounters.ContainsKey(counterName))
            {
                _successCounters[counterName] = CreateCounter<long>(counterName);
            }

            _successCounters[counterName].Add(1, new KeyValuePair<string, object>("http_method", httpContext.Request.Method));
        }
    }
}
