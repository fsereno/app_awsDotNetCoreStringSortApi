using Microsoft.AspNetCore.Mvc;
using Interfaces;
using Models;

namespace aws.Controllers
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