using Api.Intuit.Application.Models.Clients.Request;
using Api.Intuit.Application.Models.Clients.Response;
using Api.Intuit.Domain.BdIntuitClientes;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Api.Intuit.Infrastructure.Data.Contracts;
using Api.Intuit.Infrastructure.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Api.Intuit.Application.Handlers.Clients
{

    public class PutByIdClientHandler : IRequest<Unit>
    {
    
    }



}
