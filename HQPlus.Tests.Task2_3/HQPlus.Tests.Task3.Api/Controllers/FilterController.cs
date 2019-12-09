using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HQPlus.Tests.Task3.RatesFilter;
using HQPlus.Tests.Task2.Model;
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
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
