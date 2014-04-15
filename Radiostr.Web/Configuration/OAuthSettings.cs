using System.Configuration;

namespace Radiostr.Web.Configuration
{
    /*
        <configuration>
            <configSections>
                <section name="ZzzzzzOAuthSettings" type="Radiostr.Web.Configuration.OAuthSettings,Radiostr.Web" />
            </configSections>
            <ZzzzzzOAuthSettings apiKey="XXXXX" apiSecret="YYYYYY" />
        </configuration>
     */

    // http://haacked.com/archive/2007/03/12/custom-configuration-sections-in-3-easy-steps.aspx/

    public abstract class OAuthSettings : ConfigurationSection
    {
        private const string ApiKeyAttributeName = "apiKey";
        private const string ApiSecretAttributeName = "apiSecret";

        /// <summary>
        /// apiKey
        /// </summary>
        [ConfigurationProperty(ApiKeyAttributeName, IsRequired = false)]
        public string ApiKey
        {
            get { return (string)this[ApiKeyAttributeName]; }
            set { this[ApiKeyAttributeName] = value; }
        }

        /// <summary>
        /// apiSecret
        /// </summary>
        [ConfigurationProperty(ApiSecretAttributeName, IsRequired = false)]
        public string ApiSecret
        {
            get { return (string)this[ApiSecretAttributeName]; }
            set { this[ApiSecretAttributeName] = value; }
        }
    }
}