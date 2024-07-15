﻿using DotLanches.Application.UseCases;
using DotLanches.Domain.Interfaces.ExternalInterfaces;
using DotLanches.Domain.Interfaces.Repositories;
using DotLanches.Gateways;
using DotLanches.Presenters.Dtos;
using DotLanches.Presenters.Mappers;

namespace DotLanches.Controllers
{
    public class AdapterPagamentoController
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICheckout _checkout;

        public AdapterPagamentoController(IPagamentoRepository pagamentoRepository, IPedidoRepository pedidoRepository, ICheckout checkout)
        {
            _pagamentoRepository = pagamentoRepository;
            _pedidoRepository = pedidoRepository;
            _checkout = checkout;
        }

        public async Task<PagamentoDto?> ProcessPagamento(int idPedido, int queueKey)
        {
            var pedidoGateway = new PedidoGateway(_pedidoRepository);
            var pagamentoGateway = new PagamentoGateway(_pagamentoRepository);
            var payResponse = await PagamentoUseCases.ProcessPagamento(idPedido, pedidoGateway, pagamentoGateway, _checkout);
            var dto = payResponse.ToDtoModel(queueKey);
            return dto;
        }

    }
}