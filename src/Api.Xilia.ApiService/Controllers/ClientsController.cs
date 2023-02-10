using Api.Intuit.Application.Handlers;
using Api.Intuit.Application.Handlers.Clients;
using Api.Intuit.Application.Models.Clients.Request;
using Api.Intuit.Application.Models.Clients.Response;
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
        [ProducesResponseType(typeof(IEnumerable<GetAllClientsResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get()
        {
            var result = await mediator.Send(new GetAllClientsHandlerRequest());

            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await mediator.Send(new GetByIdClientHandlerRequest(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
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
        public async Task<ActionResult<PutClientResponseModel>> Put(Guid id, [FromBody] PutClientHandlerRequestModel request)
        {
            request.Id = id;
            var response = await mediator.Send(new PutClientHandlerRequestModel(request));
            return Ok(response);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
