using System.Data.SqlClient;

namespace WpfCheatSheet
{
    static class Db
    {
        internal static readonly SqlConnectionStringBuilder Sccb;
        internal static readonly string Table;

        static Db()
        {
            Sccb = new SqlConnectionStringBuilder
            {
                DataSource = "Server1",
                InitialCatalog = "Database1",
                UserID = "UserI",
                Password = "Password1"
            };

            Table = "Table1";
        }
    }
}