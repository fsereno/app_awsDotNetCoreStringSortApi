using Microsoft.AspNetCore.Mvc;
using FabioSereno.App_awsDotNetCoreStringSortApi.Interfaces;
using FabioSereno.App_awsDotNetCoreStringSortApi.Models;

namespace FabioSereno.App_awsDotNetCoreStringSortApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IStringSortUtil _stringSortUtil;
        public ValuesController(IStringSortUtil stringSortUtil)
        {
            _stringSortUtil = stringSortUtil;
        }
        [HttpPost("sort")]
        public SortResult Sort([FromBody] SortRequest request)
        {
            var result = _stringSortUtil.Sort(request.CommaSeperatedString);
            return new SortResult(){ Result = result };
        }
    }
}