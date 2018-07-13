using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebAPI.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly GaTracker _tracker;

        public ValuesController(GaTracker tracker)
        {
            _tracker = tracker;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            await PageViewHitHelper.SendAsync(_tracker, "api/values");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            await PageViewHitHelper.SendAsync(_tracker, $"api/values/{id}");
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] string value)
        {
            await EventHitHelper.SendAsync(_tracker, "Values", "Post", "recieved");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] string value)
        {
            await EventHitHelper.SendAsync(_tracker, "Values", $"Post/{id}", "recieved");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await EventHitHelper.SendAsync(_tracker, "Values", $"delete/{id}", "recieved");
            await ExceptionHitHelper.SendAsync(_tracker, "Failed to delete", true);

        }
    }
}
