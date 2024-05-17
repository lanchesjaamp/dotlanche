using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente ToDomainModel(this ClienteDto clienteDto)
        {
            var domainModel = new Cliente()
            {
                Id = clienteDto.Id,
                Name = clienteDto.Name,
                Cpf = clienteDto.Cpf,
            };

            return domainModel;
        }
    }
}