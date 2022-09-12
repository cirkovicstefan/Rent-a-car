namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string? Secret { get; set; }
        public int AccessTokenExpiration { get; set; }
    }
}
