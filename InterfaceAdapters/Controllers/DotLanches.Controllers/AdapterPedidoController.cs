using DotLanches.Application.UseCases;
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Gateways;

namespace DotLanches.Controllers
{
    public class AdapterPedidoController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public AdapterPedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task Create(Pedido pedido)
        {
            var produtoGateway = new ProdutoGateway(_produtoRepository);
            var pedidoGateway = new PedidoGateway(_pedidoRepository);
            await PedidoUseCases.Add(pedido, produtoGateway, pedidoGateway);
            return;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosQueue()
        {
            var pedidoGateway = new PedidoGateway(_pedidoRepository);
            var pedidoList = await PedidoUseCases.GetPedidosQueue(pedidoGateway);
            return pedidoList;
        }
    }
}
