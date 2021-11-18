namespace Restaurante.Infra.Comum.Helpers
{
    public class RegexHelpers
    {
        public const string REGEX_EMAIL = @"(^[a-z0-9.]+@[a-z0-9.]+\.([a-z]+)?)";
        public const string REGEX_STRONG_PASSWORD = @"^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8,}";
    }
}
