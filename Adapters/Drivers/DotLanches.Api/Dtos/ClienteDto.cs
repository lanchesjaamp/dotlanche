#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;

namespace DotLanches.Api.Dtos
{
    public class ClienteDto
    {  
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}