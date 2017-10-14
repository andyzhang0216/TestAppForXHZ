using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Base
{
    public partial class Monitor
    {
        public decimal ID { get; set; }
        public string Member { get; set; }
        public Nullable<byte> Remarks { get; set; }
        public Nullable<int> SeeFlag { get; set; }
        public System.DateTime Createtime { get; set; }
        public string Createby { get; set; }
    }

    public class MonitorResult
    {
        public string Member { get; set; }
        public Nullable<byte> Remarks { get; set; }
        public Nullable<int> SeeFlag { get; set; }
        public System.DateTime Createtime { get; set; }
        public double Money { get; set; }
        public double Result { get; set; }
        public string BetType { get; set; } //f_type
        public string GameType { get; set; } //f_typ
        public Nullable<int> Danger { get; set; } //f_peril
        public Nullable<int> GameMode { get; set; } //f_gamemode 真人电子游戏模式值
        public Nullable<System.DateTime> LoginTime { get; set; }//f_enterdate
        public Nullable<System.DateTime> BillTime { get; set; }//f_time
    }

    public class MonitorQueryObj
    {
        public Dictionary<string, string> GameAmountDic { get; set; } = new Dictionary<string, string>() {
            {"l_game_SG", "10000"},
            {"l_game_TB", "10000"},
            {"l_game_XFTB", "10000"},
            {"l_game_LP", "10000"},
            {"l_game_NN", "10000"},
            {"l_game_ZRDZPK", "10000"},
            {"l_game_FT", "10000"},
            {"l_game_21D", "25"},
            {"l_game_ZRLH", "16000"},
            {"l_game_MPBJL", "10000"},
            {"l_game_XFBJL", "10000"},
            {"l_game_YXX", "10000"},
            {"l_game_EBG", "10000"},
            {"l_game_ZRPJ", "15000"}
        };
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class MonitorDetailQueryObj
    {
        public string QueryType { get; set; }
        public string QueryMember { get; set; }
    }
}
