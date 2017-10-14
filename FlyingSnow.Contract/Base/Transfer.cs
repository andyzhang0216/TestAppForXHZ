using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Base
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Transfer
    {
        public decimal Id { get; set; }
        /// <summary>
        /// 账务日期 f_date
        /// </summary>
        public Nullable<System.DateTime> Date { get; set; }
        /// <summary>
        /// 过账时间 f_time
        /// </summary>
        public Nullable<System.DateTime> TransferTime { get; set; }
        /// <summary>
        /// 未使用 f_baktime
        /// </summary>
        public Nullable<System.DateTime> Baktime { get; set; }
        /// <summary>
        /// 过账秒数 f_gzseconds
        /// </summary>
        public Nullable<short> TransferSecond { get; set; }
    }
}
