using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSimulator.Controllers
{
    public static class AllowedPhone
    {
        public static IList<string> Statuses = new List<string>
        {
            "NEW",
            "GOOD",
            "BAD"
        };
    }
}
