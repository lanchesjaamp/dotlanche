#nullable enable
using System;
using System.Text.RegularExpressions;
using DotLanches.Domain.Exceptions;

namespace DotLanches.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }

        private Cliente() {}

        public Cliente(int id, string name, string cpf, string email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Email = email ?? throw new ArgumentNullException(nameof(email));

            ValidateEntity();
        }
        
        private void ValidateEntity()
        {
            ValidateName();
            ValidateCPF();
            ValidateEmail();
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainValidationException(nameof(Name));
        }
        
        private void ValidateCPF()
        {
            if (string.IsNullOrWhiteSpace(Cpf))
                throw new DomainValidationException(nameof(Cpf));

            Cpf = Cpf.Trim().Replace(".", "").Replace("-", "");

            if (Cpf.Length != 11 || !IsNumeric(Cpf) || IsRepeatedNumberSequence(Cpf))
                throw new DomainValidationException(nameof(Cpf));
        }
        
        private void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
                throw new DomainValidationException(nameof(Email));

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(Email, emailPattern))
                throw new DomainValidationException(nameof(Email));
        }

        private static bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private static bool IsRepeatedNumberSequence(string value)
        {
            for (int i = 1; i < value.Length; i++)
            {
                if (value[i] != value[i - 1])
                    return false;
            }
            return true;
        }
    }
}
