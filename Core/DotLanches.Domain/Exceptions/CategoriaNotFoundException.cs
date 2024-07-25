namespace DotLanches.Domain.Exceptions;

public class CategoriaNotFoundException : Exception
{
    private const string MessageTemplate = "categoria was not found.";

    public CategoriaNotFoundException() : base(string.Format(MessageTemplate))
    {
    }
}
