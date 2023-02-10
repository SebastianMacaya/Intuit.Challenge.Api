using Api.Intuit.Application.Models.Clients.Response;
using Api.Intuit.Domain.BdIntuitClientes;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Api.Intuit.Infrastructure.Data.Contracts;
using AutoMapper;
using MediatR;

namespace Api.Intuit.Application.Handlers.Clients
{
    public class GetByIdClientHandlerRequest : IRequest<GetByIdClientResponseModel>
    {    
     public GetByIdClientHandlerRequest(Guid id)
    {
        this.id = id;
    }
    public Guid id {get;set;}
    }




    public class GetByIdClientHandler: IRequestHandler<GetByIdClientHandlerRequest, GetByIdClientResponseModel>
    {
            private readonly IUnitOfWork<ClientesDbContex, Cliente> unitOfWorkClient;
            private readonly IMapper mapper;
            
            public  GetByIdClientHandler(IUnitOfWork<ClientesDbContex,Cliente> unitOfWorkClient, IMapper mapper)
       {
         this.unitOfWorkClient = unitOfWorkClient;
            this.mapper = mapper;

        }

        public async Task<GetByIdClientResponseModel> Handle(GetByIdClientHandlerRequest request, CancellationToken cancellationToken)
            {
            var result = new GetByIdClientResponseModel();
            var client = await unitOfWorkClient.RepositoryQuery.GetFirstOrDefaultAsync(client => client.ID == request.id);

            result = mapper.Map<GetByIdClientResponseModel>(client);
        return result;
        }
    }

}
