#nullable enable
using System.Text.RegularExpressions;
using DotLanches.Domain.Exceptions;
using DotLanches.Domain.ValueObjects;

namespace DotLanches.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string? Name { get; set; }
        public Cpf? Cpf { get; set; }
        public string? Email { get; set; }

        private Cliente() {}

        public Cliente(int id, string name, string cpf, string email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Cpf =  new Cpf(cpf);
            Email = email ?? throw new ArgumentNullException(nameof(email));

            ValidateEntity();
        }
        
        private void ValidateEntity()
        {
            ValidateName();
            ValidateEmail();
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainValidationException(nameof(Name));
        }
        
        private void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
                throw new DomainValidationException(nameof(Email));

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(Email, emailPattern))
                throw new DomainValidationException(nameof(Email));
        }
    }
}
