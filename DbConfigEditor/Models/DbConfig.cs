using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigEditor.Models
{
    public class DbConfig
    {
        public DbConfig()
        {
            ConnectionStrings = new Dictionary<string, string>();
        }

        public Dictionary<string, string> ConnectionStrings { get; set; }
    }
}
