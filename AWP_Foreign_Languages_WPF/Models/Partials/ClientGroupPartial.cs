using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.Models
{
    partial class ClientGroup
    {
        public string FullName
        {
            get
            {
                return Client.FullName;
            }
        }
    }
}
