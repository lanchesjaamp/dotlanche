#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using DotLanches.Domain.Exceptions;

namespace DotLanches.Domain.Entities;

public class Produto
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Categoria Categoria { get; set; }

    private Produto() { }

    public Produto(int id)
    {
        Id = id;
    }

    public Produto(int id,
                   string name,
                   string description,
                   decimal price,
                   Categoria categoria)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Categoria = categoria;

        ValidateEntity();
    }

    private void ValidateEntity()
    {
        if (string.IsNullOrEmpty(Name))
            throw new DomainValidationException(nameof(Name));
        if (string.IsNullOrEmpty(Description))
            throw new DomainValidationException(nameof(Description));
        if (Price <= 0)
            throw new DomainValidationException(nameof(Price));
        if (Categoria is null)
            throw new DomainValidationException(nameof(Categoria));
    }
}