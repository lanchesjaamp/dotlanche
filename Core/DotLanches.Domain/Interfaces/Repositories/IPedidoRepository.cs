using DotLanches.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLanches.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task Add(Pedido pedido);
        Task<IEnumerable<Pedido>> GetAll();
        Task AssignKey(Pedido pedido);
    }
}