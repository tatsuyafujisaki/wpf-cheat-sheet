using System.Configuration;

namespace WpfUtil
{
    static class Db
    {
        internal static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        internal static readonly string PackageTable = ConfigurationManager.AppSettings["Table1"];

    }
}
