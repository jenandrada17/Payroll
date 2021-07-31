using FirebirdSql.Data.FirebirdClient;

using System.Data;

namespace DBConnect.Helper
{
    public class ConnectionHelper
    {
        public FbConnection Con;

        public ConnectionHelper(string connectionString)
        {
            Con = new FbConnection(connectionString);
        }

        public bool IsConnected
        {
            get
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                return true;
            }
        }
    }
}