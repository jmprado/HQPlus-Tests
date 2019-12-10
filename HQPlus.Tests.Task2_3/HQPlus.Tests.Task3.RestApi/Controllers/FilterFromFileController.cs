using Microsoft.AspNetCore.Mvc;
using HQPlus.Tests.Task3.RatesFilter;
using HQPlus.Tests.Task3.RestApi.Model;
using Microsoft.AspNetCore.Http;
using HQPlus.Tests.Task2.Model;
using System.Collections.Generic;
using System.IO;

namespace HQPlus.Tests.Task3.RestApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class FilterFromStreamController : ControllerBase
    {
        private readonly IRatesFilterOperation _ratesFilterOperation;

        public FilterFromStreamController()
        {
            string webRootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string folder = Path.Combine(webRootPath, "wwwroot/json");
            string fileName = "task3.json";

            var fileStream = new FileStream(Path.Combine(folder, fileName), FileMode.Open, FileAccess.Read);
            _ratesFilterOperation = new RatesFilterOperation(fileStream);
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
                var filterResult = _ratesFilterOperation.Filter(filterModel.HotelId, filterModel.ArrivalDate.Value, filterModel.Operator);
                return new OkObjectResult(filterResult);
            }

            return BadRequest();
        }
    }
}
