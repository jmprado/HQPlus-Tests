using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HQPlus.Tests.Task3.RatesFilter;
using HQPlus.Tests.Task3.Api.Model;

namespace HQPlus.Tests.Task3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IRatesFilterOperation _ratesFilterOperation;

        public FilterController(IRatesFilterOperation ratesFilterOperation)
        {
            _ratesFilterOperation = ratesFilterOperation;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromBody]FilterModel filterModel)
        {
            if (ModelState.IsValid)
            {
                if (!filterModel.ArrivalDate.HasValue)
                    return new OkObjectResult(_ratesFilterOperation.Filter(filterModel.HotelId));

                return new OkObjectResult(_ratesFilterOperation.Filter(filterModel.HotelId, filterModel.ArrivalDate.Value, filterModel.Operator));
            }

            return new BadRequestObjectResult("");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
