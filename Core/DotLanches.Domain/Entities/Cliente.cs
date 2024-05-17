namespace DotLanches.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Cpf { get; set; }
}