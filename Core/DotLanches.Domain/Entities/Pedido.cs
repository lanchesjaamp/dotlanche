namespace DotLanches.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? ClienteCpf { get; set; }
    public Status? Status { get; set; }
    public decimal TotalPrice { get; set; }
    public int QueueKey { get; set; }
}