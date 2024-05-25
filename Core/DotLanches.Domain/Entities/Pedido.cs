#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using DotLanches.Domain.Exceptions;

namespace DotLanches.Domain.Entities;

public enum StatusPedido
{
    Confirmado = 1,
    Recebido = 2,
    EmPreparacao = 3,
    Pronto = 4,
    Finalizado = 5,
    Cancelado = 6,
}

public class Pedido
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? ClienteCpf { get; set; }
    public int StatusId { get; set; }
    public decimal TotalPrice { get; set; }
    public IEnumerable<Combo> Combos { get; set; }

    private Pedido()
    { }

    public Pedido(int id,
                  DateTime createdAt,
                  string? clienteCpf,
                  IEnumerable<Combo> combos)
    {
        Id = id;
        CreatedAt = createdAt;
        ClienteCpf = clienteCpf;
        Combos = combos;
        StatusId = (int)StatusPedido.Confirmado;

        ValidateEntity();
    }

    private void ValidateEntity()
    {
        if (Combos is null)
            throw new DomainValidationException(nameof(Combos));
    }

    public void CalculateTotalPrice()
    {
        TotalPrice = Combos.Sum(c => c.Price);

        if (TotalPrice <= 0)
            throw new DomainValidationException(nameof(TotalPrice));
    }
}