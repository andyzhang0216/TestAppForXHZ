using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Online
{
    public partial class Online
    {
        public string Account { get; set; }
        public Nullable<int> Catagory { get; set; }
        public string SignInIp { get; set; }
        public Nullable<System.DateTime> SignInTime { get; set; }
        public Nullable<System.DateTime> BetTime { get; set; }
        public Nullable<System.DateTime> TimeNow { get; set; }
        public string SPAccessToken { get; set; }
        public Nullable<System.DateTime> SportTime { get; set; }
    }
}
