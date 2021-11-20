using System.Text.RegularExpressions;

namespace Restaurante.Domain.Helpers
{
    public static class ValidatorsHelper
    {
        public static bool ValidCPF(this string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int sumOf = 0;

            for (int i = 0; i < 9; i++)
                sumOf += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remain = sumOf % 11;
            if (remain < 2)
                remain = 0;
            else
                remain = 11 - remain;

            string digito = remain.ToString();
            tempCpf = tempCpf + digito;
            sumOf = 0;
            for (int i = 0; i < 10; i++)
                sumOf += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remain = sumOf % 11;
            if (remain < 2)
                remain = 0;
            else
                remain = 11 - remain;

            digito += remain.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool ValidEmail(this string email)
        {
            var regexEmail = new Regex(RegexHelpers.RegexEmail);

            return regexEmail.IsMatch(email);
        }

        public static bool ValidPassword(this string password)
        {
            var regexPassword = new Regex(RegexHelpers.RegexStrongPassword);

            return regexPassword.IsMatch(password);
        }
    }
}
