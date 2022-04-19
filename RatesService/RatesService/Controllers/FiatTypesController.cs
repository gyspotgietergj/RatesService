using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RatesService.Models;

namespace RatesService.Controllers
{
    [Route("v1/Fiat")]
    public class FiatTypesController : Controller
    {
        private IBusinessLogic businessLogic;
        public FiatTypesController(IBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
        }

        [HttpGet]
        [Route("pulltypes")]
        public ActionResult<List<FiatType>> PopulateAllTypes()
        {
            //Would normally not use a tuple...usually use an object that maps this error message and result type
            var result = businessLogic.PopulateAllFiatTypes();
            if (result.Item2 != "")
            {
                return BadRequest(result.Item2);
            }
            return Ok(result.Item1);
        }

        [HttpGet]
        public ActionResult<List<FiatType>> GetAllTypes()
        {
            var result = businessLogic.GetAllFiatTypes();
            if (result.Item2 != "")
            {
                return BadRequest(result.Item2);
            }
            return Ok(result.Item1);
        }

    }
}
