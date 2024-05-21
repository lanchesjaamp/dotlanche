using System.Text.Json.Serialization;

namespace DotLanches.Domain.Entities;

public class Combo
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int? LancheId { get; set; }
    public string? LancheName { get; set; }
    public int? AcompanhamentoId { get; set; }
    public string? AcompanhamentoName { get; set; }
    public int? BebidaId { get; set; }
    public string? BebidaName { get; set; }
    public int? SobremesaId { get; set; }
    public string? SobremesaName { get; set; }
    public decimal Price { get; set; }

    [JsonIgnore]
    public Pedido? Pedido { get; set; }
    [JsonIgnore]
    public Produto? Lanche { get; set; }
    [JsonIgnore]
    public Produto? Acompanhamento { get; set; }
    [JsonIgnore]
    public Produto? Bebida { get; set; }
    [JsonIgnore]
    public Produto? Sobremesa { get; set; }
}