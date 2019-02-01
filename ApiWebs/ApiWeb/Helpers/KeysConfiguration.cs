using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ApiWeb.Helpers
{
    public static class KeysConfiguration
    {
        public const string ErrorServiceSecureHttps = "REQUIRE_HTTPS";
        public const string ErrorAuthentication = "AUTHENTICATION_ERROR";
        public const string ErrorAuthorization = "AUTHORIZATION_ERROR";
        public const string ErrorBusinessException = "BUSINESS_EXCEPTION";
        public const string ErrorDataAcessException = "DATAACESS_EXCEPTION";
        public const string ErrorFrameworkException = "FRAMEWORK_EXCEPTION";
        public const string ErrorBusinessValidation = "BUSINESS_VALIDATION";
        public const string ErrorBusinessExternalExcep = "BUSINESS_EXTERNAL_EXCEPTION";

        public static int KeyAccessTokenExpireMin
        {
            get
            {
                int value = 15;
                var llave = ConfigurationManager.AppSettings["KeyAccessTokenExpireMin"];
                if (string.IsNullOrEmpty(llave))
                    return value;

                int.TryParse(llave, out value);
                return value;
            }
        }


        public static string KeyTokenUrl
        {
            get
            {
                var llave = ConfigurationManager.AppSettings["Token.Url"];
                if (string.IsNullOrEmpty(llave))
                    throw new ConfigurationErrorsException("Llave de Web.config: Token.Url");
                return llave;
            }
        }

        public static string KeyBaseUrl
        {
            get
            {
                var llave = ConfigurationManager.AppSettings["Base.Url"];
                if (string.IsNullOrEmpty(llave))
                    throw new ConfigurationErrorsException("Llave de Web.config: Base.Url");
                return llave;
            }
        }

        public static int KeyRefreshTokenExpireHours
        {
            get
            {
                int value = 4;
                var llave = ConfigurationManager.AppSettings["RefreshTokenExpireHours"];
                if (string.IsNullOrEmpty(llave))
                    return value;

                int.TryParse(llave, out value);
                return value;
            }
        }

    }
}