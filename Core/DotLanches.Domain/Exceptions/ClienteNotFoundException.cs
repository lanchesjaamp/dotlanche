namespace DotLanches.Domain.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        private const string MessageTemplate = "cliente with cpf {0} was not found.";

        public ClienteNotFoundException(string propertyName) : base(string.Format(MessageTemplate, propertyName))
        {
        }
    }
}
