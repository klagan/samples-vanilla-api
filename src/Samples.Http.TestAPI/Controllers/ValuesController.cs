namespace Samples.Http.TestAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Samples.Http.Core;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("getPerson/{firstName}")]
        public IActionResult GetPerson(string firstName)
        {
            try
            {
                if (firstName == "throw")
                {
                    throw new Exception("test path");
                }

                if (firstName == "none")
                {
                    return new NotFoundObjectResult(new Person());
                }

                return new OkObjectResult(new Person {FirstName = firstName, LastName = "Test!"});
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new {name = nameof(firstName), value = firstName, body = ex.Message});
            }
        }

        // GET api/values
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            return new OkObjectResult (new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/get/{id}")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult("value");
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
        [Route("api/{id}")]
        public void Delete(int id)
        {
        }
    }
}
