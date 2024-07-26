using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Dtos
{
    public class StatusDto
    {
        [Required]
        public int StatusId { get; set; }
    }
}
