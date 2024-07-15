using DotLanches.Presenters.Dtos;
using DotLanches.Domain.Entities;

namespace DotLanches.Presenters.Mappers
{
    public static class PagamentoPresenter
    {
        public static PagamentoViewModel GetPagamentoViewModel(Pagamento pagamento, int queueKey = 0)
        {
            var viewModel = new PagamentoViewModel()
            {
                IsAccepted = pagamento.IsAccepted,
                RegisteredAt = pagamento.RegisteredAt,
                QueueKey = queueKey
            };

            return viewModel;
        }
    }
}