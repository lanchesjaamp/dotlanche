using DotLanches.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace DotLanches.Domain.ValueObjects
{
    public class Cpf
    {
        public string Number { get; private set; }

        public Cpf(string number)
        {
            var cpf = ValidateAndFormatCpf(number);
            Number = number;
        }

        public static string ValidateAndFormatCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new DomainValidationException(nameof(cpf));

            cpf = Regex.Replace(cpf, @"[^\d]", "");

            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
                throw new DomainValidationException(nameof(cpf));

            if (!IsValidCpf(cpf))
                throw new DomainValidationException(nameof(cpf));

            return cpf;
        }

        private static bool IsValidCpf(string cpf)
        {
            int[] multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplier2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            var tempCpf = cpf.Substring(0, 9);
            var digit = CalculateDigit(tempCpf, multiplier1).ToString();
            tempCpf += digit;
            digit += CalculateDigit(tempCpf, multiplier2).ToString();

            return cpf.EndsWith(digit);
        }

        private static int CalculateDigit(string cpf, int[] multipliers)
        {
            var sum = multipliers.Select((t, i) => int.Parse(cpf[i].ToString()) * t).Sum();

            var remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
