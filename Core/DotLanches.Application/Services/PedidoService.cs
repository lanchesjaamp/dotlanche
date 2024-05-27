#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Interfaces.Services;

namespace DotLanches.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task Add(Pedido pedido)
        {
            foreach (var combo in pedido.Combos)
            {
                combo.Lanche = await _produtoRepository.GetById(combo.Lanche.Id);
                combo.Acompanhamento = await _produtoRepository.GetById(combo.Acompanhamento.Id);
                combo.Bebida = await _produtoRepository.GetById(combo.Bebida.Id);
                combo.Sobremesa = await _produtoRepository.GetById(combo.Sobremesa.Id);

                combo.CalculatePrice();
            }

            pedido.CalculateTotalPrice();

            await _pedidoRepository.Add(pedido);
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            var pedidos = await _pedidoRepository.GetAll();

            foreach (var pedido in pedidos)
            {
                foreach (var combo in pedido.Combos)
                {
                    combo.CalculatePrice();
                }
                pedido.CalculateTotalPrice();
            }

            return pedidos;
        } 
        public async Task<int> QueueKeyAssignment(Pedido pedido) => await _pedidoRepository.AssignKey(pedido);
    }
}
