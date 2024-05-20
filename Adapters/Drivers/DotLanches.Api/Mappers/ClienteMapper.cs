using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente ToDomainModel(this ClienteDto clienteDto, int id = 0)
        {
            var domainModel = new Cliente(id, clienteDto.Name, clienteDto.Cpf, clienteDto.Email);

            return domainModel;
        }
    }
}