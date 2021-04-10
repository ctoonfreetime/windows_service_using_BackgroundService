using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myService
{
    public class ApiService
    {
        // nothing but the current datetime.
        // in the real case you might want to get data from your database.
        public DateTime GetData() {
            return DateTime.Now;
        }
    }
}
