using Nthware.SDS.Debugging;

namespace Nthware.SDS
{
    public class SDSConsts
    {
        public const string LocalizationSourceName = "SDS";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "59a00ae3cbcf460c8f286dc31cd47b91";
    }
}
