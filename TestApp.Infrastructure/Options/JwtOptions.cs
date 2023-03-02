namespace TestApp.Infrastructure.Options
{
    public class JwtOptions
    {
        public const string Jwt = "Jwt";

        public string? SecurityKey { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}