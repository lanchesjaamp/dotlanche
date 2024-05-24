#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using DotLanches.Domain.Exceptions;

namespace DotLanches.Domain.Entities;

public class Combo
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public Produto? Lanche { get; set; }
    public Produto? Acompanhamento { get; set; }
    public Produto? Bebida { get; set; }
    public Produto? Sobremesa { get; set; }
    public decimal Price { get; set; }

    private Combo() { }

    public Combo(int id,
                 int pedidoId,
                 Produto lanche,
                 Produto acompanhamento,
                 Produto bebida,
                 Produto sobremesa)
    {
        Id = id;
        PedidoId = pedidoId;
        Lanche = lanche;
        Acompanhamento = acompanhamento;
        Bebida = bebida;
        Sobremesa = sobremesa;

        ValidateEntity();
    }

    private void ValidateEntity()
    {
        if (Lanche?.Id == 0 && Acompanhamento?.Id == 0 && Bebida?.Id == 0 && Sobremesa?.Id == 0)
            throw new DomainValidationException(nameof(Produto));
    }

    public void CalculatePrice()
    {
        if (Lanche is not null)
            Price += Lanche.Price;
        if (Acompanhamento is not null)
            Price += Acompanhamento.Price;
        if (Bebida is not null)
            Price += Bebida.Price;
        if (Sobremesa is not null)
            Price += Sobremesa.Price;

        if (Price <= 0)
            throw new DomainValidationException(nameof(Price));
    }
}