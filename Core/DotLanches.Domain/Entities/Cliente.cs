#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using DotLanches.Domain.Exceptions;

namespace DotLanches.Domain.Entities;

public class Cliente
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    
    private Cliente() {}

    public Cliente(int id, string name, string cpf)
    {
        Id = id;
        Name = name;
        Cpf = cpf;
        
        ValidateEntity();
    }
    
    private void ValidateEntity()
    {
        if (string.IsNullOrEmpty(Name))
            throw new DomainValidationException(nameof(Name));
        if (string.IsNullOrEmpty(Cpf))
            throw new DomainValidationException(nameof(Cpf));
    }
}