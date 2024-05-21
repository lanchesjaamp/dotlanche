using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class PedidoMapper
    {
        public static Pedido ToDomainModel(this PedidoDto pedidoDto)
        {
            var domainModel = new Pedido
            {
                ClienteCPF = pedidoDto.ClienteCPF,
                Combos = pedidoDto.Combos.Select(x => new Combo
                {
                    LancheId = x.LancheId == 0 ? null : x.LancheId,
                    AcompanhamentoId = x.AcompanhamentoId == 0 ? null : x.AcompanhamentoId,
                    BebidaId = x.BebidaId == 0 ? null : x.BebidaId,
                    SobremesaId = x.SobremesaId == 0 ? null : x.SobremesaId,
                    Price = x.Price
                }).ToList(),
                TotalPrice = pedidoDto.Combos.Sum(x => x.Price),
            };

            return domainModel;
        }
    }
}
