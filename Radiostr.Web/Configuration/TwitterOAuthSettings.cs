using System.Configuration;

namespace Radiostr.Web.Configuration
{
    public class TwitterOAuthSettings : OAuthSettings
    {
        public static readonly TwitterOAuthSettings Settings =
            ConfigurationManager.GetSection("TwitterOAuthSettings") as TwitterOAuthSettings;
    }
}