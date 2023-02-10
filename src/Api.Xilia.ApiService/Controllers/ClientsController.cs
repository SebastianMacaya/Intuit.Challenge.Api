using Api.Intuit.Application.Handlers.Clients;
using Api.Intuit.Application.Models.Clients.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Intuit.ApiService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        //Utilizo patron mediator 
        private readonly IMediator mediator;

        public ClientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostClientRequestModel model)
        {
            var response = await mediator.Send(new PostClientHandlerRequest(model));
            return Ok(response);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
