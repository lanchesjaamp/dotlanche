using DotLanches.Api.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Api.Mappers
{
    public static class ComboMapper
    {
        public static Combo ToDomainModel(this ComboDto comboDto, int id = 0, int pedidoId = 0)
        {
            var domainModel = new Combo(id,
                                        pedidoId,
                                        new Produto(comboDto.LancheId ?? 0),
                                        new Produto(comboDto.AcompanhamentoId ?? 0),
                                        new Produto(comboDto.BebidaId ?? 0),
                                        new Produto(comboDto.SobremesaId ?? 0));

            return domainModel;
        }
    }
}
