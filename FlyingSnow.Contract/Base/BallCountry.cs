using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Base
{
    public partial class BallCountry
    {
        public int Id { get; set; }
        public Nullable<byte> Type { get; set; }
        public string Title { get; set; }
        public Nullable<int> SortValue { get; set; }
        public Nullable<int> MainId { get; set; }
        public string BallFlag { get; set; }
        public string BallType { get; set; }
    }
}
