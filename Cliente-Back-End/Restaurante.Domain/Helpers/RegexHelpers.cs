namespace Restaurante.Domain.Helpers
{
    public static class RegexHelpers
    {
        public const string RegexEmail = @"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$";
        public const string RegexStrongPassword = "(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])";
    }
}
