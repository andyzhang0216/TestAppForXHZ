using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Base
{
    public partial class BallTeam
    {
        public int Id { get; set; }
        public Nullable<int> Type { get; set; }
        public string TeamName { get; set; }
        public string AllianceName { get; set; }
        public string TeamNameMore { get; set; }
        public Nullable<int> MainId { get; set; }
        public string ImgName { get; set; }
        public Nullable<byte> ImgOpen { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<byte> Source { get; set; }
    }
}
