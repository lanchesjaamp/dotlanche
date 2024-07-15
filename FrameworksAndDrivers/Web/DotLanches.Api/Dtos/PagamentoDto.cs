namespace DotLanches.Api.Dtos
{
    public class PagamentoDto
    {
        public bool? IsAccepted { get; set; }

        public DateTime? RegisteredAt { get; set; }

        public int QueueKey { get; set; } 
    }
}
