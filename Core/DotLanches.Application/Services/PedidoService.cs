using DotLanches.Domain.Entities;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLanches.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteService _clienteService;

        public PedidoService(IPedidoRepository pedidoRepository, IClienteService clienteService)
        {
            _pedidoRepository = pedidoRepository;
            _clienteService = clienteService;
        }

        public async Task Add(Pedido pedido)
        {
            if (!string.IsNullOrEmpty(pedido.ClienteCPF))
            {
                var clientes = await _clienteService.GetAll();

                if (clientes.FirstOrDefault(c => c.Cpf == pedido.ClienteCPF) == null)
                {
                    throw new ArgumentException("O CPF do cliente especificado no pedido não existe.");
                }
            }

            foreach (var combo in pedido.Combos)
            {
                if (combo.LancheId is null && combo.AcompanhamentoId is null && combo.BebidaId is null && combo.SobremesaId is null)
                {
                    throw new ArgumentException("Pelo menos um item do combo deve ser preenchido.");
                }
            }

            await _pedidoRepository.Add(pedido);
        }

        public async Task<IEnumerable<Pedido>> GetAll() => await _pedidoRepository.GetAll();
    }
}
