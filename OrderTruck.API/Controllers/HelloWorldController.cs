namespace Microsoft.Examples.Controllers
{
    using AspNetCore.Mvc.Routing;
    using AspNetCore.Routing;
    using Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class HelloWorldController : Controller
    {
        // GET api/v{version}/helloworld
        [HttpGet]
        public IActionResult Get() => Ok(
           new
           {
               id = 1,
               name = "test"
           }

            );

        // GET api/v{version}/helloworld/{id}
        [HttpGet("{id:int}", Name = "GetMessageById")]
        public IActionResult Get(int id) => Ok(new { Controller = GetType().Name, Id = id, Version = HttpContext.GetRequestedApiVersion().ToString() });

        // POST api/v{version}/helloworld
        [HttpPost]
        public IActionResult Post() => CreatedAtRoute("GetMessageById", new { id = 42 }, null);
    }
}