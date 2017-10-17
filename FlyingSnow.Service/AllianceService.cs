using FlyingSnow.Contract.Base;
using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class AllianceService
    {
        public List<Alliance> GetAlliances(AllianceQueryObj queryObj)
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    var predicate = PredicateBuilder.True<Alliance>();
                    if (queryObj.BallType != null)
                    {
                        predicate = predicate.And(p => p.BallType.Equals(Convert.ToInt32(queryObj.BallType)));
                    }
                    if (!string.IsNullOrEmpty(queryObj.SearchStr))
                    {
                        predicate = predicate.And(p => p.AllianceName.Contains(queryObj.SearchStr));
                    }
                    Func<Alliance, bool> query = predicate.Compile();
                    var result = ctx.Alliances.Where(query).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BallCountry> GetBallCountrys(AllianceQueryObj queryObj)
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    return ctx.BallCountries.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetZeroScore(int id, bool flag)
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    var alliance = ctx.Alliances.Where(a => a.Id == id).FirstOrDefault();
                    if (alliance != null)
                    {
                        alliance.ZeroScore = Convert.ToByte(flag);
                        ctx.SaveChanges();
                    }
                    //else
                    //{
                    //    throw new Exception("Not Fount!");
                    //}
                }

                //update sub site
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class AllianceQueryObj
    {
        public BallTypes? BallType { get; set; }

        public string SearchStr { get; set; }
    }

    public enum BallTypes
    {
        Null = 0,
        AmericanBaseball = 2,
        JapaneseBaseball = 3,
        TaiwaneseBaseball = 6,
        KoreanBaseball = 9,

        Hockey = 10,//冰球
        Basketball = 1,
        ColorBall = 11,
        AmericanFootball = 5,
        tennis = 8,
        Football = 4,

        NewIndex = 7,//指数
        HorseRace = 12,
        Other = 20
    }
}
