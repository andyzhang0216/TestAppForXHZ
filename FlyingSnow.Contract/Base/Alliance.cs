using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Base
{
    public partial class Alliance
    {
        public int Id { get; set; }
        public string AllianceName { get; set; }
        public Nullable<int> BallType { get; set; }
        public Nullable<int> IndexNum { get; set; }
        public Nullable<byte> AllianceLevel { get; set; }
        public Nullable<byte> ZeroScore { get; set; }
        public Nullable<double> SumSpreadOdds { get; set; }
        public Nullable<double> SumScoreOdds { get; set; }
        public Nullable<int> MainId { get; set; }
        public Nullable<int> BallId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string AllianceNameMore { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<byte> CalculateMode { get; set; }
        public Nullable<int> PalyId { get; set; }
        public Nullable<byte> Number { get; set; }
        public Nullable<byte> Source { get; set; }
    }
}
