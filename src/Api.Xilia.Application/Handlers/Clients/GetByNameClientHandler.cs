using Api.Intuit.Application.Models.Clients.Request;
using Api.Intuit.Domain.BdIntuitClientes;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Api.Intuit.Infrastructure.Data.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Intuit.Application.Handlers.Clients
{
    public class GetByNameClientHandlerRequest : IRequest<GetByNameClientHandlerResponse>
    {
        public GetByNameClientHandlerRequest(GetByNameClientRequestModel model)
        {
            Model = model;
        }
        public GetByNameClientRequestModel Model { get; set; }
    }
    public class GetByNameClientHandlerResponse
    {
        public GetByNameClientHandlerResponse(Cliente model)
        {
            Model = model;
        }

        public Cliente Model { get; set; }
    }
    public class GetByNameClientHandler: IRequestHandler<GetByNameClientHandlerRequest, GetByNameClientHandlerResponse>
    {
        private readonly IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkCliente;
        
        public GetByNameClientHandler(IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkCliente)
        {
            this.unitOfWorkCliente = unitOfWorkCliente;
        }
        public async Task<GetByNameClientHandlerResponse> Handle(GetByNameClientHandlerRequest request, CancellationToken cancellationToken)
        {
            var cliente = await unitOfWorkCliente.RepositoryQuery.GetFirstOrDefaultAsync(cliente => cliente.name ==request.Model.name );
            if (cliente is null)
            {
            }
            return new GetByNameClientHandlerResponse(cliente);




        }
    }
}
