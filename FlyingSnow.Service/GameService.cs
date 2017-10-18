using FlyingSnow.Contract.Base;
using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class GameService
    {
        public void GetGames()
        {
            //SELECT a.*,(CASE WHEN f_xh = 666 THEN 0  WHEN f_xh = 667 THEN 1 WHEN f_xh = 668 THEN 2 WHEN f_xh = 669 THEN 3 else 4 end) as sp1 from(select * FROM dbo.[t_newbaseball_a] with(nolock)  where f_sfds = 0)a order by sp1, f_order, f_xh, f_alliance, f_playid, f_date, f_numbera, f_gamedate, f_gpdm, a.id OFFSET 0 ROWS FETCH NEXT 15 ROWS ONLY

            try
            {
                List<NewGame> results = null;
                using (var ctx = new BossBallEntities())
                {
                    var query = ctx.t_newbaseball_a.Where(g => g.MovedFlag == 0)
                        .OrderBy(g => g.Orderd).ThenBy(g => g.AllienceNumber).ThenBy(g => g.AllianceName).ThenBy(g => g.PlayId)
                        .ThenBy(g => g.TransferDate).ThenBy(g => g.GameNumA).ThenBy(g => g.GameDate).ThenBy(g => g.FollowFlag).ThenBy(g => g.Id);
                    results = query.ToList();
                }

                //List<BallCountry> ballCountries = null;
                //using (var ctx = new BaseDBContext())
                //{
                //    ballCountries = ctx.BallCountries.ToList();
                //}

                // list = list
                // .GroupJoin(BallCountryList, b => b.f_ballid, l => l.f_mainid, (s, b) =>
                // {
                //     var obj = b.FirstOrDefault();
                //     bool isnull = obj == null;
                //     s.sp5 = isnull ? "||||" : obj.f_title.ToString();
                //     s.sp4 = isnull ? "0" : obj.f_sort.ToString();
                //     return s;
                // })
                //.GroupJoin(BallCountryList, inew => inew.f_countryid, m => m.f_mainid, (s, b) =>
                //{
                //    var obj = b.FirstOrDefault();
                //    s.sp3 = obj == null ? "||||" : obj.f_title.ToString();
                //    return s;
                //})
                //.ToList();
                //results.GroupJoin(ballCountries, )
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime? GetDate()
        {
            try
            {
                //select distinct f_date from t_newbaseball_a with (nolock) where f_sfds=0 order by f_date asc
                using (var ctx = new BossBallEntities())
                {
                    var result = ctx.t_newbaseball_a.Select(g => g.TransferDate).Distinct().FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
