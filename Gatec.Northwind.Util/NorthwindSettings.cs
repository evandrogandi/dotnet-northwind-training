using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Gatec.Northwind.Util
{
    public static class NorthwindSetting
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString; }
        }
    }
}
