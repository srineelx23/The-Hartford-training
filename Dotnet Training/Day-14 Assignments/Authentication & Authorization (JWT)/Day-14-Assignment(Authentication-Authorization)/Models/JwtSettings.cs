namespace Day_14_Assignment_Authentication_Authorization_.Models
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpiryMinutes { get; set; }
    }
}
