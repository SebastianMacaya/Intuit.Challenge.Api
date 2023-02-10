using Api.Intuit.Domain;
using Api.Intuit.Domain.BdIntuitClientes;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Api.Intuit.Infrastructure.Data.Contracts;
using Api.Intuit.Infrastructure.Exceptions;
using Api.Intuit.Infrastructure.Services;

namespace Api.Intuit.Application.Handlers.Clients.Services
{
     public interface IPostClientHandlerValidateService
    {
        Task IsDataClientValidate(PostClientHandlerRequest clientRequest);
    }
    public class PostClientHandlerValidateService: IPostClientHandlerValidateService, IService
    {
        private readonly IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkClient;

        public PostClientHandlerValidateService(IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkClient)
        {
            this.unitOfWorkClient = unitOfWorkClient;   
        }

        public async Task IsDataClientValidate(PostClientHandlerRequest clientRequest)
        {
            await CuitExist(clientRequest.cuit.ToLower());

        }

        private async Task CuitExist(string cuit)
        {
           var clientCuit = await unitOfWorkClient.RepositoryQuery.GetFirstOrDefaultAsync(x => x.cuit == cuit);
           if (clientCuit is not null)
            {
                throw new BadRequestProjectException("El CUIT ingresado ya esta en existe  en otro cliente...");

            }
        }
       
    }
}
