#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;

namespace DotLanches.Application.UseCases
{
    public static class PedidoUseCases
    {
        public static async Task Add(Pedido pedido, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            foreach (var combo in pedido.Combos)
            {
                combo.Lanche = await produtoRepository.GetById(combo.Lanche.Id);
                combo.Acompanhamento = await produtoRepository.GetById(combo.Acompanhamento.Id);
                combo.Bebida = await produtoRepository.GetById(combo.Bebida.Id);
                combo.Sobremesa = await produtoRepository.GetById(combo.Sobremesa.Id);

                combo.CalculatePrice();
            }

            pedido.CalculateTotalPrice();

            await pedidoRepository.Add(pedido);
        }

        public static async Task<IEnumerable<Pedido>> GetAll(IPedidoRepository pedidoRepository)
        {
            var pedidos = await pedidoRepository.GetAll();

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
        public static async Task<int> QueueKeyAssignment(int idPedido, IPedidoRepository pedidoRepository) => await pedidoRepository.AssignKey(idPedido);
    }
}
