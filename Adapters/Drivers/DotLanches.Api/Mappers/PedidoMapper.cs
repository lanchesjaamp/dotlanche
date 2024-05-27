using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class PedidoMapper
    {
        public static Pedido ToDomainModel(this PedidoDto pedidoDto, int id = 0)
        {
            var domainModel = new Pedido(id,
                                         DateTime.UtcNow,
                                         pedidoDto.ClienteCpf.Number,
                                         pedidoDto.Combos.Select(c => c.ToDomainModel()).ToList());

            return domainModel;
        }
    }
}
