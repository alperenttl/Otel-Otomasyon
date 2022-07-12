using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu
{
    public static class DataRepo
    {
        public static SqlConnection bag = new SqlConnection("server=DESKTOP-UEUSQKP\\SQLEXPRESS;initial catalog = otel; integrated security=true;multipleactiveresultsets=true;");
        public static int il {get;set;}
        public static int ilce {get;set;}
        public static int oda { get; set; }
    }
}
