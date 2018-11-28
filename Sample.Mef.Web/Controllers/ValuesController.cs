using Microsoft.AspNetCore.Mvc;
using Sample.Mef.Web.Providers;
using System.Linq;

namespace Sample.Mef.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGiveNumberProvider _giveNumberProvider;

        public ValuesController(IGiveNumberProvider giveNumberProvider)
        {
            _giveNumberProvider = giveNumberProvider;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_giveNumberProvider.GetNumberFromAllFoundServices().ToList().Select(f=> new { f.Id, f.Value }));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
