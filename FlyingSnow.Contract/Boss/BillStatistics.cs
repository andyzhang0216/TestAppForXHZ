using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Boss
{
    public partial class BillStatistics
    {
        public int Id { get; set; }
        public Nullable<byte> SiteNumber { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Account { get; set; }
        public string BillInfo { get; set; }
    }
}
