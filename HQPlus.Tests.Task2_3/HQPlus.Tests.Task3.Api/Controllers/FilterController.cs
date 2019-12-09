using Microsoft.AspNetCore.Mvc;
using HQPlus.Tests.Task3.RatesFilter;
using HQPlus.Tests.Task3.Api.Model;
using Microsoft.AspNetCore.Http;
using HQPlus.Tests.Task2.Model;
using System.Collections.Generic;

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

        /// <summary>
        /// Load hotelrates.json and filter it contents
        /// </summary>
        /// <param name="filterModel"></param>
        /// <returns>IEnumerable<HotelRates></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]
        [Produces(typeof(List<HotelRates>))]
        public IActionResult Get([FromBody]FilterModel filterModel)
        {
            if (ModelState.IsValid)
            {
                if (!filterModel.ArrivalDate.HasValue)
                    return new OkObjectResult(_ratesFilterOperation.Filter(filterModel.HotelId));

                return new OkObjectResult(_ratesFilterOperation.Filter(filterModel.HotelId, filterModel.ArrivalDate.Value, filterModel.Operator));
            }

            return BadRequest();
        }
    }
}
