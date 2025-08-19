using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigEditor.Utils
{
    public static class ConnectionStringBuilder
    {
        public static string Build(string server, string database, string userId, string password)
        {
            return $"Server={server};Database={database};User Id={userId};Password={password};TrustServerCertificate=True;";
        }
    }

}
