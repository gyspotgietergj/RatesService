using Newtonsoft.Json;
using RatesService.Context;
using RatesService.Models;
using RatesService.Models.RequestResults;
using System.Net;
using System.Web;

namespace RatesService
{
    public class CoinMarketCapBusinessLogic : IBusinessLogic
    {
        IConfiguration _configuration;
        RatesContext _ratesContext;
        public CoinMarketCapBusinessLogic(IConfiguration configuration, RatesContext context)
        {
            _configuration = configuration;
            _ratesContext = context;    
        }
        public Tuple<List<FiatType>, string> PopulateAllFiatTypes()
        {
            try
            {
                var URL = new UriBuilder(_configuration.GetConnectionString("CoinMarketCap") + "fiat/map");
                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", _configuration.GetValue<string>("APIKey"));
                client.Headers.Add("Accepts", "application/json");
                var result = client.DownloadString(URL.ToString());
                var baseRequestResultsList = JsonConvert.DeserializeObject<BaseRequestResultsList<FiatType>>(result);

                if (baseRequestResultsList == null)
                {
                    return new Tuple<List<FiatType>, string>(null, baseRequestResultsList.Status.Error_Message);
                }

                foreach (var item in baseRequestResultsList.Data)
                {
                    _ratesContext.FiatTypes.Add(item);
                }

                _ratesContext.SaveChanges();

                return new Tuple<List<FiatType>, string>(baseRequestResultsList.Data, "");
            }
            catch (Exception ex)
            {
                return new Tuple<List<FiatType>, string>(null, ex.Message);
            }
        }
    }
}
