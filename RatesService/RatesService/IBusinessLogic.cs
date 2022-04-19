using RatesService.Models;

namespace RatesService
{
    public interface IBusinessLogic
    {
        Tuple<List<FiatType>,string> PopulateAllFiatTypes();
        Tuple<List<FiatType>,string> GetAllFiatTypes();
    }
}
