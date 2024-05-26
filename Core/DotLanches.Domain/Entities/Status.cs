#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DotLanches.Domain.Entities
{
    public record Status
    {
        private Status(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public static Status Confirmado() => new(1, "Confirmado");
        public static Status Recebido() => new(2, "Recebido");
        public static Status EmPreparacao() => new(3, "EmPreparacao");
        public static Status Pronto() => new(4, "Pronto");
        public static Status Finalizado() => new(5, "Finalizado");
        public static Status Cancelado() => new(6, "Cancelado");
    }
}