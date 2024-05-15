namespace DotLanches.Infra.Exceptions
{
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("entity not found!")
        {
        }
    }
}