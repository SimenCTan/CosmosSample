namespace CosmosSample_AzFunctions.ViewModels
{
    public class TokenInfo
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string TokenType { get; set; } = "bearer";

        public string LoginName { get; set; }
    }
}
