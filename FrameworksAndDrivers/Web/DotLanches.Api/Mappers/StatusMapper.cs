using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class StatusMapper
    {
        public static Status ToDomainModel(this StatusDto statusDto)
        {
            return statusDto.StatusId switch
            {
                1 => Status.Confirmado(),
                2 => Status.Recebido(),
                3 => Status.EmPreparacao(),
                4 => Status.Pronto(),
                5 => Status.Finalizado(),
                6 => Status.Cancelado(),
                _ => throw new ArgumentException("Status inválido", nameof(statusDto))
            };
        }
    }
}
