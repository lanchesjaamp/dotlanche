using System.Text.Json.Serialization;

namespace DotLanches.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? ClienteCPF { get; set; }
    public decimal TotalPrice { get; set; }
    public IEnumerable<Combo> Combos { get; set; }
    [JsonIgnore]
    public Cliente? Cliente { get; set; }
}