using FlyingSnow.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class TeamService
    {
        public List<BallTeam> GetBallTeam()
        {
            //SELECT* FROM dbo.[t_ball] with(nolock)  WHERE f_source> 0  and f_alliance = 'MLB 美國職棒-季後賽(國聯)||MLB 美国职棒-季後赛(国联)||MLB - Postseason (National League)||MLB - Postseason (National League)'  ORDER BY  (case when(dbo.Get_StrArrayStrOfIndex(f_ball, '||', 1) = '' or dbo.Get_StrArrayStrOfIndex(f_ball, '||', 2) = ''
            //                 or dbo.Get_StrArrayStrOfIndex(f_ball, '||', 3) = '' or dbo.Get_StrArrayStrOfIndex(f_ball, '||', 4) = '')
            //         then 0 else 1 end) ASC , f_ball ASC
            return null;
        }
    }
}
