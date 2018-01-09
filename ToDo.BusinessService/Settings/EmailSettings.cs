using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BusinessService.Settings
{
    public class EmailSettings : ConfigurationSection
    {
        const string customerEmailSettings = "emailSettings";

        private EmailSettings()
        {

        }
        static EmailSettings settings;

        public static EmailSettings GetSettings()
        {

            if (settings == null)
            {
                settings = (EmailSettings)ConfigurationManager.GetSection(customerEmailSettings);
            }
            return settings;

        }
      

        [ConfigurationProperty("applicationName", DefaultValue = "MillenicomTR", IsRequired = true)]
        public string ApplicationName
        {
            get
            {
                return (string)this["applicationName"];
            }
            set
            {
                this["applicationName"] = value;
            }
        }

        [ConfigurationProperty("displayName", DefaultValue = "Millenicom", IsRequired = true)]
        public string DisplayName
        {
            get
            {
                return (string)this["displayName"];
            }
            set
            {
                this["displayName"] = value;
            }
        }


        [ConfigurationProperty("fromEmail", DefaultValue = "", IsRequired = true)]
        public string FromEmail
        {
            get
            {
                return (string)this["fromEmail"];
            }
            set
            {
                this["fromEmail"] = value;
            }
        }

        [ConfigurationProperty("emailUser", DefaultValue = "", IsRequired = true)]
        public string EmailUser
        {
            get
            {
                return (string)this["emailUser"];
            }
            set
            {
                this["emailUser"] = value;
            }
        }
        [ConfigurationProperty("emailPassword", DefaultValue = "", IsRequired = true)]
        public string EmailPassword
        {
            get
            {
                return (string)this["emailPassword"];
            }
            set
            {
                this["emailPassword"] = value;
            }
        }


        [ConfigurationProperty("SMTPServer", DefaultValue = "", IsRequired = true)]
        public string SMTPServer
        {
            get
            {
                return (string)this["SMTPServer"];
            }
            set
            {
                this["SMTPServer"] = value;
            }
        }
        [ConfigurationProperty("SMTPPort", DefaultValue = "587", IsRequired = true)]
        public int SMTPPort
        {
            get
            {
                return (int)this["SMTPPort"];
            }
            set
            {
                this["SMTPPort"] = value;
            }
        }
        [ConfigurationProperty("useSSL", DefaultValue = "true", IsRequired = true)]
        public bool UseSSL
        {
            get
            {
                return (bool)this["useSSL"];
            }
            set
            {
                this["useSSL"] = value;
            }
        }
    }
}
