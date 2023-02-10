using Api.Intuit.Application.Handlers.Clients.Services;
using Api.Intuit.Application.Models.Clients.Request;
using Api.Intuit.Application.Models.Clients.Response;
using Api.Intuit.Domain;
using Api.Intuit.Domain.BdIntuitClientes;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Api.Intuit.Infrastructure.Data.Contracts;
using MediatR;
using System.Text.RegularExpressions;

namespace Api.Intuit.Application.Handlers.Clients
{
    public class PostClientHandlerRequest : IRequest<PostClientHandlerResponse>
    {
        //pasar request model
        public PostClientHandlerRequest(PostClientRequestModel model)
        {
            //valido espacios y guardo formateado
            this.name = Regex.Replace(model.name, @"\s+", " ").Trim().ToLower();
            this.surname = Regex.Replace(model.surname, @"\s+", " ").Trim().ToLower();
            this.birthdate = model.birthdate;
            this.cuit = Regex.Replace(model.cuit, @"\s+", " ").Trim().ToLower().Replace("-", string.Empty);
            this.address = model.address;
            this.phone = model.phone;
            this.email = model.email;


        }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string cuit { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class PostClientHandlerResponse
    {
        public PostClientHandlerResponse(PostClientResponseModel response)
        {
            Response =response;
        }
        public PostClientResponseModel Response { get; }
    }


    public class PostClientHandler: IRequestHandler<PostClientHandlerRequest, PostClientHandlerResponse>
    {
        private readonly IUnitOfWork<ClientesDbContex,Cliente> unitOfWorkClient;
        //Inyeccion del servicio para validaciones logicas
        private readonly IPostClientHandlerValidateService postClientHandlerValidateService;

        public PostClientHandler(IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkClient, IPostClientHandlerValidateService postClientHandlerValidateService)
        {
            this.unitOfWorkClient = unitOfWorkClient;
            this.postClientHandlerValidateService = postClientHandlerValidateService;
        }
        

        public async Task<PostClientHandlerResponse>Handle(PostClientHandlerRequest request,CancellationToken cancellationToken)
        {
            await postClientHandlerValidateService.IsDataClientValidate(request);
            var client = new Cliente();
            client.name = request.name;
            client.surname = request.surname;
            client.birthdate = request.birthdate;
            client.cuit = request.cuit;
            client.address = request.address;
            client.phone = request.phone;
            client.email = request.email;


            unitOfWorkClient.RepositoryCommand.Create(client);
            await unitOfWorkClient.SaveChangesAsync();

            var answer = new PostClientResponseModel()
            {
                message = "Cliente Creado",
                id = client.ID,
            };
            return new PostClientHandlerResponse(answer);
        }
    }
}
