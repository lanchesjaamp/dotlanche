#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Gateways;

namespace DotLanches.Application.UseCases
{
    public static class PedidoUseCases
    {
        public static async Task Add(Pedido pedido, IProdutoGateway produtoGateway, IPedidoGateway pedidoGateway)
        {
            foreach (var combo in pedido.Combos)
            {
                combo.Lanche = await produtoGateway.GetById(combo.Lanche.Id);
                combo.Acompanhamento = await produtoGateway.GetById(combo.Acompanhamento.Id);
                combo.Bebida = await produtoGateway.GetById(combo.Bebida.Id);
                combo.Sobremesa = await produtoGateway.GetById(combo.Sobremesa.Id);

                combo.CalculatePrice();
            }

            pedido.CalculateTotalPrice();

            await pedidoGateway.Add(pedido);
        }

        public static async Task<IEnumerable<Pedido>> GetPedidosQueue(IPedidoGateway pedidoGateway)
        {
            var pedidos = await pedidoGateway.GetPedidosQueue();

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

    }
}
