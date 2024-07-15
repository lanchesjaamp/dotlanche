using DotLanches.Presenters.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Presenters.Mappers
{
    public static class PagamentoDtoMapper
    {
        public static PagamentoDto ToDtoModel(this Pagamento pagamento, int queueKey = 0)
        {
            var dtoModel = new PagamentoDto()
            {
                IsAccepted = pagamento.IsAccepted,
                RegisteredAt = pagamento.RegisteredAt,
                QueueKey = queueKey
            };

            return dtoModel;
        }
    }
}
