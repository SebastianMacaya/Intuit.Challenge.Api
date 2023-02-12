using Api.Intuit.Application.Models.Clients.Response;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Api.Intuit.Domain.BdIntuitClientes;
using Api.Intuit.Infrastructure.Data.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Intuit.Application.Handlers.Clients
{
    public class GetAllClientsHandlerRequest : IRequest<IEnumerable<GetAllClientsResponseModel>>
    {
        public GetAllClientsHandlerRequest()
        {

        }
    }

    public class GetAllClientsHandler : IRequestHandler<GetAllClientsHandlerRequest, IEnumerable<GetAllClientsResponseModel>>
    {
        private readonly IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkClient;
        private readonly IMapper mapper;

        public GetAllClientsHandler(IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkClient, IMapper mapper)
        {
            this.unitOfWorkClient = unitOfWorkClient;
            this.mapper = mapper;

        }
        public async Task<IEnumerable<GetAllClientsResponseModel>> Handle(GetAllClientsHandlerRequest request, CancellationToken cancellationToken)
        {
            var clients = await unitOfWorkClient.RepositoryQuery.GetAllAsync();
     
            var result = mapper.Map<IEnumerable<GetAllClientsResponseModel>>(clients);

            return result;
        }
    }
}
