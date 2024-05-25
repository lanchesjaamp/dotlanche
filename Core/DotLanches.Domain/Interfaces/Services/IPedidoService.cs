using DotLanches.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLanches.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task Add(Pedido pedido);
        Task<IEnumerable<Pedido>> GetAll();
        Task QueueKeyAssignment(Pedido pedido);
    }
}